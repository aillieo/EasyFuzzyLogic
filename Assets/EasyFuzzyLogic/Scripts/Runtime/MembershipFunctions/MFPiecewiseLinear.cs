using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class MFPiecewiseLinear : IMembershipFunction
    {
        public MFPiecewiseLinear()
        {

        }

        public float LowerBound => throw new NotImplementedException();

        public float UpperBound => throw new NotImplementedException();

        public float Fuzzify(float value)
        {
            throw new NotImplementedException();
        }
    }
}