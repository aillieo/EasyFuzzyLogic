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

        public bool Apply(IDictionary<string, Dictionary<string, FuzzyValue>> input, out FuzzyValue output)
        {
            throw new NotImplementedException();
        }
    }
}
