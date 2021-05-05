using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Units;

namespace DASH._Player
{
    public class Player : MonoBehaviour
    {
        public float currentHP;
        private CharacterStats stats;
        private void Start()
        {
            stats = GetComponent<CharacterStats>();
            currentHP = stats.maxHealth.GetStat();
        }

        public float TakeDamage(float value)
        {
            float damage = value - stats.armor.GetStat();
            currentHP -= damage;
            return damage;
        }
    }
}