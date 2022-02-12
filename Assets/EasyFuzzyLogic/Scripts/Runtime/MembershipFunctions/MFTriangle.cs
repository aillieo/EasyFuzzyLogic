using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class MFTriangle : IMembershipFunction
    {
        private float lowerBound;
        private float upperBound;
        private float topX;
        private float topY;

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

        public float Area => 0.5f * topY * (upperBound - lowerBound);

        public Vector2 Centroid => new Vector2((lowerBound + upperBound + topX) / 3f, topY / 3f);
    }
}
