using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        private PlayerAnimator animator;
        float ReloadTimer = 0;
        float ReloadSpeed = 1;

        string[] attacks = { "Attack1", "Attack2", "Attack3" };

        void Start()
        {
            animator = GetComponent<PlayerAnimator>();
        }

        void Update()
        {
            if (ReloadTimer > 0)
            {
                ReloadTimer -= Time.deltaTime;
            }
        }

        public void Attack()
        {
            if (ReloadTimer <= 0)
            {
                animator.PlayRandomAttackAnimation();
                ReloadTimer = ReloadSpeed;
            }
        }
    }
}