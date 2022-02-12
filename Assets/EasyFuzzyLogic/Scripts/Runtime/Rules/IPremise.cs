using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyFuzzyLogic
{
    public interface IPremise
    {
        bool IsTrueFor(IDictionary<string, IDictionary<string, FuzzyValue>> inputValues, out float degreeOfMembership);
    }
}
