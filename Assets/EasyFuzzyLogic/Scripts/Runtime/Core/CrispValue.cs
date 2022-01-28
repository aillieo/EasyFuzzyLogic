using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public struct CrispValue : IEquatable<CrispValue>
    {
        public string name;
        public float value;

        public CrispValue(string name, float value)
        {
            this.name = name;
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is CrispValue v)
            {
                return Equals(v);
            }

            return false;
        }

        public bool Equals(CrispValue other)
        {
            return name == other.name && value == other.value;
        }

        public override int GetHashCode()
        {
            if (name == null)
            {
                return value.GetHashCode();
            }

            return this.name.GetHashCode() ^ this.value.GetHashCode() << 2;
        }

        public override string ToString()
        {
            return $"<{name}={value}>";
        }
    }
}
