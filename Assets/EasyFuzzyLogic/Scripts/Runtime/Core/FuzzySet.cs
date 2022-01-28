using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class FuzzySet
    {
        public LinguisticVariable linguisticVariable;
        public IMembershipFunction membershipFunction;

        public FuzzySet(LinguisticVariable variable, IMembershipFunction membershipFunction)
        {
            this.linguisticVariable = variable;
            this.membershipFunction = membershipFunction;
        }
    }
}
