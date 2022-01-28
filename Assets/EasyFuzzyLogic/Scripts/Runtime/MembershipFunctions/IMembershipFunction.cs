using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyFuzzyLogic
{
    public interface IMembershipFunction
    {
        float Fuzzify(float value);
        float LowerBound { get; }
        float UpperBound { get; }
    }
}
