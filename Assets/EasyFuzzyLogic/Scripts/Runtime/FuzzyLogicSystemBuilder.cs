using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AillieoUtils.EasyFuzzyLogic
{
    public class FuzzyLogicSystemBuilder
    {
        private Dictionary<string, Dictionary<string, IMembershipFunction>> membershipFunctionsBuilder;
        private List<Rule> rulesBuilder;
        private IDefuzzificater defuzzificaterBuilder;

        public FuzzyLogicSystemBuilder AddLinguisticVariable(string variableName, string fuzzyValue, IMembershipFunction membershipFunction)
        {
            return AddLinguisticVariable(variableName, (fuzzyValue, membershipFunction));
        }

        public FuzzyLogicSystemBuilder AddLinguisticVariable(string variableName, IDictionary<string, IMembershipFunction> membershipFunctions)
        {
            return AddLinguisticVariable(variableName, membershipFunctions.Select(pair => (pair.Key, pair.Value)));
        }

        public FuzzyLogicSystemBuilder AddLinguisticVariable(string variableName, params (string, IMembershipFunction)[] membershipFunctions)
        {
            return AddLinguisticVariable(variableName, (IEnumerable<(string, IMembershipFunction)>)membershipFunctions);
        }

        public FuzzyLogicSystemBuilder AddLinguisticVariable(string variableName, IEnumerable<(string, IMembershipFunction)> membershipFunctions)
        {
            if (!membershipFunctions.Any())
            {
                throw new ArgumentException($"{membershipFunctions} empty");
            }

            if (membershipFunctionsBuilder == null)
            {
                membershipFunctionsBuilder = new Dictionary<string, Dictionary<string, IMembershipFunction>>();
            }

            if (!membershipFunctionsBuilder.TryGetValue(variableName, out Dictionary<string, IMembershipFunction> innerDict))
            {
                innerDict = new Dictionary<string, IMembershipFunction>();
                membershipFunctionsBuilder.Add(variableName, innerDict);
            }

            foreach (var (fuzzyValue, membershipFunc) in membershipFunctions)
            {
                innerDict.Add(fuzzyValue, membershipFunc);
            }

            return this;
        }

        public FuzzyLogicSystemBuilder AddRule(IPremise premise, Conclusion conclusion)
        {
            return AddRule(new Rule(premise, conclusion));
        }

        public FuzzyLogicSystemBuilder AddRule(Rule rule)
        {
            if (rulesBuilder == null)
            {
                rulesBuilder = new List<Rule>();
            }

            rulesBuilder.Add(rule);
            return this;
        }

        public FuzzyLogicSystemBuilder SetDefuzzificater(IDefuzzificater defuzzificater)
        {
            this.defuzzificaterBuilder = defuzzificater;
            return this;
        }

        public FuzzyLogicSystem Build()
        {
            return new FuzzyLogicSystem(membershipFunctionsBuilder, rulesBuilder, defuzzificaterBuilder);
        }
    }
}
