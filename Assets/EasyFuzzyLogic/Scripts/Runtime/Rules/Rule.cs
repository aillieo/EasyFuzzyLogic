using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class Rule
    {
        public IPremise premise;
        public Conclusion conclusion;

        public Rule(IPremise premise, Conclusion conclusion)
        {
            this.premise = premise;
            this.conclusion = conclusion;
        }

        public bool Apply(IDictionary<string, IDictionary<string, FuzzyValue>> input, out FuzzyValue output)
        {
            output = new FuzzyValue()
            {
                name = conclusion.variableName,
            };

            if (premise.IsTrueFor(input, out float degreeOfMembership))
            {
                output.linguisticVariable = conclusion.linguisticVar;
                output.degreeOfMembership = degreeOfMembership;
                return true;
            }

            return false;
        }
    }
}
