using System;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Units
{
    [System.Serializable]
    public class Stat
    {
        [SerializeField]
        private float baseValue;

        private List<float> modifiers = new List<float>();

        public void AddModifier(float modifier)
        {
            modifiers.Add(modifier);
        }

        public void RemoveModifier(float modifier)
        {
            modifiers.Remove(modifier);
        }

        public float GetStat()
        {
            float value = baseValue;
            modifiers.ForEach(x => value += x);
            return value;
        }
    }
}
