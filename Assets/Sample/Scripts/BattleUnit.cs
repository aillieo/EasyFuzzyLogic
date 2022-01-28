using System.Collections;
using System.Collections.Generic;
using AillieoUtils.EasyFuzzyLogic;
using UnityEngine;

namespace Sample
{
    public class BattleUnit : MonoBehaviour
    {
        public int hp;
        public int hpMax;

        public int mp;
        public int mpMax;

        public int dpa;
        public int heal;

        public FuzzyLogicSystem fuzzyLogicSystem;

        public void OnTick()
        {
            UnityEngine.Debug.Log(fuzzyLogicSystem.Infer(new CrispValue()));
        }
    }
}
