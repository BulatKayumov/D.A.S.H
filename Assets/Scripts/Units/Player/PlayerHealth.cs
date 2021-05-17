using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Units;
using DASH._UI;
using DASH._Dungeon;

namespace DASH._Player
{
    public class PlayerHealth : MonoBehaviour
    {

        public float currentHP;
        private CharacterStats stats;
        private UIManager ui;
        private PlayerAnimator animator;
        private void Start()
        {
            stats = GetComponent<CharacterStats>();
            animator = GetComponent<PlayerAnimator>();
            ui = UIManager.instance;
            currentHP = stats.maxHealth.GetStat();
            InvokeRepeating("Regenerate", 0, 1);
        }

        public void TakeDamage(float value)
        {
            currentHP -= value;
            currentHP = Mathf.Clamp(currentHP, 0, stats.maxHealth.GetStat());
            if(currentHP == 0)
            {
                StartCoroutine(Dead());
            }
            ui.SetDamageText(value);
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

        private IEnumerator Dead()
        {
            Player.instance.alive = false;
            animator.PlayDeathAnimation();
            yield return new WaitForSeconds(4);
            GameManager.instance.LeaveDungeon();
        }
    }
}