using System;
using System.Collections;
using System.Collections.Generic;
using AillieoUtils.EasyFuzzyLogic;
using UnityEngine;

namespace Sample
{
    public class BattleUnit : MonoBehaviour
    {
        public int hp = 100;
        public int hpMax = 100;

        public int mp;
        public int mpMax;

        public int dpa;
        public int heal;

        [NonSerialized]
        public FuzzyLogicSystem fuzzyLogicSystem;

        public void OnTick()
        {
            if (hp <= 0)
            {
                return;
            }

            hp -= 1;
            hp = Mathf.Clamp(hp, 0, hpMax);
            CrispValue result = fuzzyLogicSystem.Infer(new CrispValue() { name = "hp", value = (float)hp / hpMax });
            UnityEngine.Debug.Log($"hp={hp} result={result}");
        }
    }
}
