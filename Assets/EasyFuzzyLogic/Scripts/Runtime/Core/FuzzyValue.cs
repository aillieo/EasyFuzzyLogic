using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public struct FuzzyValue : IEquatable<FuzzyValue>
    {
        public string name;
        public string linguisticVariable;
        public float degreeOfMembership;

        public FuzzyValue(string name, string linguisticVariable, float degreeOfMembership)
        {
            this.name = name;
            this.linguisticVariable = linguisticVariable;
            this.degreeOfMembership = degreeOfMembership;
        }

        public override bool Equals(object obj)
        {
            if (obj is LinguisticVariable v)
            {
                return Equals(v);
            }

            return false;
        }

        public bool Equals(FuzzyValue other)
        {
            return name == other.name && linguisticVariable == other.linguisticVariable && degreeOfMembership == other.degreeOfMembership;
        }

        public override int GetHashCode()
        {
            int nameHash = name == null ? 0 : name.GetHashCode();
            int linguisticVariableHash = linguisticVariable == null ? 0 : linguisticVariable.GetHashCode();
            return nameHash ^ (linguisticVariableHash << 2) ^ (degreeOfMembership.GetHashCode() >> 2);
        }

        public override string ToString()
        {
            return $"{degreeOfMembership} for {linguisticVariable}({name})";
        }
    }
}
