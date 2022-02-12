using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class FuzzyLogicSystem : ISerializationCallbackReceiver
    {
        [SerializeField]
        private Dictionary<string, Dictionary<string, IMembershipFunction>> membershipFunctions;
        [SerializeField]
        private List<Rule> rules;
        [SerializeField]
        private IDefuzzificater defuzzificater;

        [NonSerialized]
        private Dictionary<string, IDictionary<string, FuzzyValue>> fuzzyCache = new Dictionary<string, IDictionary<string, FuzzyValue>>();
        [NonSerialized]
        private List<FuzzyValue> resultCache = new List<FuzzyValue>();

        internal FuzzyLogicSystem(Dictionary<string, Dictionary<string, IMembershipFunction>> membershipFunctions, List<Rule> rules, IDefuzzificater defuzzificater)
        {
            this.membershipFunctions = membershipFunctions;
            this.rules = rules;
            this.defuzzificater = defuzzificater;
        }

        public CrispValue Infer(params CrispValue[] inputVariables)
        {
            return Infer((IEnumerable<CrispValue>)inputVariables);
        }

        public CrispValue Infer(IEnumerable<CrispValue> inputVariables)
        {
            // initialize
            foreach (var pair in fuzzyCache)
            {
                pair.Value.Clear();
            }

            resultCache.Clear();

            // fuzzify
            foreach (var v in inputVariables)
            {
                string variableName = v.name;
                if (membershipFunctions.TryGetValue(variableName, out Dictionary<string, IMembershipFunction> membershipFuncs))
                {
                    foreach (var pair in membershipFuncs)
                    {
                        string linguisticValue = pair.Key;
                        IDictionary<string, FuzzyValue> innerCache = default;
                        if (!fuzzyCache.TryGetValue(variableName, out innerCache))
                        {
                            innerCache = new Dictionary<string, FuzzyValue>();
                            fuzzyCache.Add(variableName, innerCache);
                        }

                        float degreeOfMembership = pair.Value.Fuzzify(v.value);
                        innerCache[linguisticValue] = new FuzzyValue(variableName, linguisticValue, degreeOfMembership);
                    }
                }
                else
                {
                    throw new Exception($"no membership for {v.name}");
                }
            }

            // infer
            string outVariableName = null;
            foreach (var r in rules)
            {
                if (r.Apply(fuzzyCache, out FuzzyValue output))
                {
                    resultCache.Add(output);
                    if (string.IsNullOrEmpty(outVariableName))
                    {
                        outVariableName = output.name;
                    }
                }
            }

            if (string.IsNullOrEmpty(outVariableName))
            {
                throw new Exception("no matching rules for input");
            }

            // defuzzify
            if (membershipFunctions.TryGetValue(outVariableName, out Dictionary<string, IMembershipFunction> membershipFuncsDefuzz))
            {
                float outCrispValue = defuzzificater.Defuzzify(resultCache, membershipFuncsDefuzz);
                return new CrispValue(outVariableName, outCrispValue);
            }
            else
            {
                throw new Exception($"no membership for {outVariableName}");
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            if (fuzzyCache == null)
            {
                fuzzyCache = new Dictionary<string, IDictionary<string, FuzzyValue>>();
            }

            if (resultCache == null)
            {
                resultCache = new List<FuzzyValue>();
            }
        }
    }
}
