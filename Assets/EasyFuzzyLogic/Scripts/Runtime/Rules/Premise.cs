using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class Premise : IPremise
    {
        public LinguisticVariable linguisticVariable;

        public Premise(string name, string linguisticVar)
            : this(new LinguisticVariable(name, linguisticVar))
        {
        }

        public Premise(LinguisticVariable linguisticVariable)
        {
            this.linguisticVariable = linguisticVariable;
        }

        public bool IsTrueFor(IDictionary<string, IDictionary<string, FuzzyValue>> inputValues, out float degreeOfMembership)
        {
            if (inputValues.TryGetValue(linguisticVariable.name, out IDictionary<string, FuzzyValue> fuzzyValues))
            {
                if (fuzzyValues.TryGetValue(linguisticVariable.value, out FuzzyValue fuzzyValue))
                {
                    degreeOfMembership = fuzzyValue.degreeOfMembership;
                    //return degreeOfMembership > 0;
                    return true;
                }
            }

            degreeOfMembership = 0;
            return false;
        }
    }
}
