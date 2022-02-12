using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class MFRectangle : IMembershipFunction
    {
        public MFRectangle(float lowerBound, float upperBound, float topValue)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            this.topValue = topValue;
        }

        public MFRectangle(float lowerBound, float upperBound)
            : this(lowerBound, upperBound, 1)
        {
        }

        private float lowerBound;
        private float upperBound;
        private float topValue;

        public float LowerBound => lowerBound;

        public float UpperBound => upperBound;

        public float Area => topValue * (upperBound - lowerBound);

        public Vector2 Centroid => new Vector2((upperBound + lowerBound) * 0.5f, topValue * 0.5f);

        public float Fuzzify(float value)
        {
            if (value < lowerBound || value > upperBound)
            {
                return 0;
            }

            return topValue;
        }
    }
}
