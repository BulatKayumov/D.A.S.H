using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Units;

namespace DASH._Player
{
    public class PlayerCombat : MonoBehaviour
    {
        private PlayerAnimator animator;
        private CharacterStats stats;
        float ReloadTimer = 0;
        float ReloadSpeed = 1;
        public bool isAttacking = false;

        string[] attacks = { "Attack1", "Attack2", "Attack3" };

        void Start()
        {
            animator = GetComponent<PlayerAnimator>();
            stats = GetComponent<CharacterStats>();
        }

        void Update()
        {
            ReloadTimer -= Time.deltaTime;
            if(ReloadTimer <= 0)
            {
                isAttacking = false;
            }
        }

        public void Attack()
        {
            if (ReloadTimer <= 0)
            {
                animator.PlayRandomAttackAnimation();
                ReloadTimer = ReloadSpeed;
                isAttacking = true;
            }
        }

        public void Damage(MobController mob)
        {
            float damage = mob.TakeDamage(stats.damage.GetStat());
        }
    }
}