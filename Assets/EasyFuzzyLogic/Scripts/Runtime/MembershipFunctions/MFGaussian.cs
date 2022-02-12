using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class MFGaussian : IMembershipFunction
    {
        public MFGaussian()
        {

        }

        public float LowerBound => throw new NotImplementedException();

        public float UpperBound => throw new NotImplementedException();

        public float Area => throw new NotImplementedException();

        public Vector2 Centroid => throw new NotImplementedException();

        public float Fuzzify(float value)
        {
            throw new NotImplementedException();
        }
    }
}
