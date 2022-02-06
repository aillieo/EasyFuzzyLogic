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
            hp -= 1;
            hp = Mathf.Clamp(hp, 0, hpMax);
            UnityEngine.Debug.Log(fuzzyLogicSystem.Infer(new CrispValue(){name = "hp", value = hp * 100f / hpMax}));
        }
    }
}
