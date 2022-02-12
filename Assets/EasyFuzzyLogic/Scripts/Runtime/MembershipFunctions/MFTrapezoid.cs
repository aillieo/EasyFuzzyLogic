using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class MFTrapezoid : IMembershipFunction
    {
        public MFTrapezoid(float lowerBound, float topLeft, float topRight, float upperBound, float topValue)
        {
            this.lowerBound = lowerBound;
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.upperBound = upperBound;
            this.topValue = topValue;
        }

        public MFTrapezoid(float lowerBound, float topLeft, float topRight, float upperBound)
            : this(lowerBound, topLeft, topRight, upperBound, 1)
        {
        }

        private float lowerBound;
        private float topLeft;
        private float topRight;
        private float upperBound;
        private float topValue;

        public float LowerBound => lowerBound;

        public float UpperBound => upperBound;

        public float Area => 0.5f * topValue * (upperBound - lowerBound + topRight - topLeft);

        public Vector2 Centroid
        {
            get
            {
                return GeometryUtils.CentroidOfPolygon(new Vector2(lowerBound, 0), new Vector2(upperBound, 0), new Vector2(topRight, topValue), new Vector2(topLeft, topValue));
            }
        }

        public float Fuzzify(float value)
        {
            throw new NotImplementedException();
        }
    }
}
