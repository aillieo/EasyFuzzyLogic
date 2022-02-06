using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class Conclusion
    {
        public string variableName;
        public string linguisticVar;

        public Conclusion(string variableName, string linguisticVar)
        {
            this.variableName = variableName;
            this.linguisticVar = linguisticVar;
        }
    }
}
