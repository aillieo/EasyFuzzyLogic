using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public struct LinguisticVariable : IEquatable<LinguisticVariable>
    {
        public string name;
        public string value;

        public LinguisticVariable(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is LinguisticVariable v)
            {
                return Equals(v);
            }

            return false;
        }

        public bool Equals(LinguisticVariable other)
        {
            return name == other.name && value == other.value;
        }

        public override int GetHashCode()
        {
            int nameHash = name == null ? 0 : name.GetHashCode();
            int fuzzyValueHash = value == null ? 0 : value.GetHashCode();
            return nameHash ^ (fuzzyValueHash << 2);
        }

        public override string ToString()
        {
            return $"{value}({name})";
        }
    }
}
