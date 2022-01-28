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
    }
}
