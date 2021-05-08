using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Player;

namespace DASH._Units
{ 
    public class MobCombat : MonoBehaviour
    {
        private CharacterStats stats;
        private float attackTimer;
        private MobAnimator animator;

        private void Start()
        {
            stats = GetComponent<CharacterStats>();
            animator = GetComponent<MobAnimator>();
            attackTimer = 0f;
        }

        private void Update()
        {
            attackTimer -= Time.deltaTime;
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.GetComponent<Player>())
        //    {
        //        Player player = other.GetComponent<Player>();
        //        Attack(player);
        //    } 
        //}

        public void Attack(Player player)
        {
            if(stats.attackSpeed.GetStat() != 0)
            {
                float reload = 200 / stats.attackSpeed.GetStat();
                if(attackTimer <= 0)
                {
                    float damageDone = player.TakeDamage(stats.damage.GetStat());
                    attackTimer = reload;
                    animator.PlayAttackAnimation();
                    Debug.Log("I dealt " + damageDone + " damage to player, my reload is " + reload);
                }
            }
            else
            {
                Debug.LogError("Division by zero");
            }
        }
    }
}