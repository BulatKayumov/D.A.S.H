using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DASH._Units
{
    public class MobAnimator : MonoBehaviour
    {
        private Animator animator;
        string[] attacks = { "Attack1", "Attack2", "Attack3" };
        float speedPercent;
        CharacterStats stats;
        NavMeshAgent agent;

        private void Start()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            stats = GetComponent<CharacterStats>();
        }

        private void Update()
        {
            speedPercent = agent.velocity.magnitude / stats.speed.GetStat();
            animator.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);
        }

        public void PlayAttackAnimation()
        {
            animator.SetTrigger(attacks[Random.Range(0, 3)]);
        }

        public void PlayDeathAnimation()
        {
            animator.SetTrigger("Dead");
        }
    }
}
