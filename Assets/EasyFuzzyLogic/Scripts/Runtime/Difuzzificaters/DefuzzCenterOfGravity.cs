using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    public class DefuzzCenterOfGravity : IDefuzzificater
    {
        public float Defuzzify(List<FuzzyValue> fuzzyValues, Dictionary<string, IMembershipFunction> membershipFuncs)
        {
            float areaSum = 0f;
            float centerXSum = 0f;

            foreach (FuzzyValue fuzzyValue in fuzzyValues)
            {
                if (membershipFuncs.TryGetValue(fuzzyValue.linguisticVariable, out IMembershipFunction membershipFunction))
                {
                    areaSum += (membershipFunction.Area * fuzzyValue.degreeOfMembership);
                    centerXSum += (membershipFunction.Area * fuzzyValue.degreeOfMembership * membershipFunction.Centroid.x);
                }
                else
                {
                    throw new Exception($"no membership funcs for {fuzzyValue.linguisticVariable}");
                }
            }

            if (areaSum != 0)
            {
                return centerXSum / areaSum;
            }

            return 0f;
        }
    }
}
