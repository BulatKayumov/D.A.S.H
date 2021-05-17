using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DASH._Units
{
    public class MobAnimator : MonoBehaviour
    {
        private Animator animator;
        [SerializeField]
        private string[] simpleAttacks;
        [SerializeField]
        private string[] criticalAttacks;
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

        public void PlaySimpleAttackAnimation()
        {
            animator.SetTrigger(simpleAttacks[Random.Range(0, simpleAttacks.Length)]);
        }

        public void PlayCriticalAttackAnimation()
        {
            animator.SetTrigger(criticalAttacks[Random.Range(0, criticalAttacks.Length)]);
        }

        public void PlayDeathAnimation()
        {
            animator.SetTrigger("Dead");
        }
    }
}
