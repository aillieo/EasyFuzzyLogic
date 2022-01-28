using System.Collections;
using System.Collections.Generic;
using AillieoUtils.EasyFuzzyLogic;
using UnityEngine;

namespace Sample
{
    public class SampleCase : MonoBehaviour
    {
        [SerializeField]
        FuzzyLogicSystemAsset fuzzyLogicSystemAsset;

        [SerializeField]
        private BattleUnit battleUnit0;
        [SerializeField]
        private BattleUnit battleUnit1;

        private void Start()
        {
            FuzzyLogicSystem fuzzyLogicSystem0 = fuzzyLogicSystemAsset.FLS;
            FuzzyLogicSystem fuzzyLogicSystem1 = new FuzzyLogicSystemBuilder()
                .AddLinguisticVariable(
                    "hp",
                    ("high", new MFTriangle(0.5f, 1, new Vector2(1, 1))),
                    ("mid", new MFTriangle(0.33f, 0.67f, new Vector2(0.5f, 1))),
                    ("low", new MFTriangle(0, 0.5f, new Vector2(0, 1))))
                .AddRule(new Premise("hp", "high"), new Conclusion("state", "attack"))
                .AddRule(new Premise("hp", "low"), new Conclusion("stage", "defence"))
                .Build();

            battleUnit0.fuzzyLogicSystem = fuzzyLogicSystem0;
            battleUnit1.fuzzyLogicSystem = fuzzyLogicSystem1;
        }

        private void Update()
        {
            battleUnit0.OnTick();
            battleUnit1.OnTick();
        }
    }
}
