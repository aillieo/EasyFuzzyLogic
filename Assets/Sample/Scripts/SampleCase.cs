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
                    ("mid", new MFTriangle(0, 1, new Vector2(0.5f, 1))),
                    ("low", new MFTriangle(0, 0.5f, new Vector2(0, 1))))
                .AddLinguisticVariable(
                    "aggressiveness",
                    ("high", new MFTriangle(0, 1, new Vector2(1, 1))),
                    ("low", new MFTriangle(0, 1, new Vector2(0, 1))))
                .AddRule(PremiseComposite.Or(new Premise("hp", "high"), new Premise("hp", "mid")), new Conclusion("aggressiveness", "high"))
                .AddRule(new Premise("hp", "low"), new Conclusion("aggressiveness", "low"))
                .SetDefuzzificater(new DefuzzCenterOfGravity())
                .Build();

            // 序列化暂未完成
            fuzzyLogicSystem0 = fuzzyLogicSystem1;

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
