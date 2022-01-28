using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class MFTriangle : IMembershipFunction
    {
        [field: SerializeField]
        public float lowerBound { get; private set; }
        [field: SerializeField]
        public float upperBound { get; private set; }
        [field: SerializeField]
        public float topX { get; private set; }
        [field: SerializeField]
        public float topY { get; private set; }

        public MFTriangle(float lowerBound, float upperBound, Vector2 top)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            this.topX = top.x;
            this.topY = top.y;
        }

        public MFTriangle(float lowerBound, float upperBound, float mid)
            : this(lowerBound, upperBound, new Vector2(mid, 1))
        {
        }

        public float LowerBound => lowerBound;

        public float UpperBound => upperBound;

        public float Fuzzify(float value)
        {
            if (value < lowerBound || value > upperBound)
            {
                return 0;
            }

            if (value < topX)
            {
                return Mathf.Lerp(0, topY, (value - lowerBound) / (topX - lowerBound));
            }
            else
            {
                return Mathf.Lerp(topY, 0, (value - topX) / (upperBound - topX));
            }
        }
    }
}
