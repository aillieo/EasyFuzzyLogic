using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    public interface IMembershipFunction
    {
        float Fuzzify(float value);
        float LowerBound { get; }
        float UpperBound { get; }
        float Area { get; }
        Vector2 Centroid { get; }
    }
}
