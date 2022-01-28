using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    public interface IDifuzzificater
    {
        float Defuzzify(List<FuzzyValue> fuzzyValues, Dictionary<string, IMembershipFunction> membershipFuncs);
    }
}
