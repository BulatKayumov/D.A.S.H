using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Units;
using DASH._UI;

namespace DASH._Player
{
    public class Player : MonoBehaviour
    {
        #region Singleton

        public static Player instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        public float currentHP;
        private CharacterStats stats;
        private UIManager ui;
        private void Start()
        {
            stats = GetComponent<CharacterStats>();
            ui = UIManager.instance;
            currentHP = stats.maxHealth.GetStat();
            InvokeRepeating("Regenerate", 0, 1);
        }

        public float TakeDamage(float value)
        {
            float damage = value - stats.armor.GetStat();
            currentHP -= damage;
            currentHP = Mathf.Clamp(currentHP, 0, stats.maxHealth.GetStat());
            ui.SetDamageText(damage);
            return damage;
        }

        public void Heal(float value)
        {
            currentHP += value;
            currentHP = Mathf.Clamp(currentHP, 0, stats.maxHealth.GetStat());
            ui.SetHealText(value);
        }

        private void Regenerate()
        {
            currentHP += stats.regeneration.GetStat();
            currentHP = Mathf.Clamp(currentHP, 0, stats.maxHealth.GetStat());
        }
    }
}