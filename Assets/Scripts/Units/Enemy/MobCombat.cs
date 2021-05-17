using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Player;

namespace DASH._Units
{
    public enum AttackType
    {
        Simple, Critical
    }

    public class MobCombat : MonoBehaviour
    {
        private CharacterStats stats;
        private float attackTimer;
        private MobAnimator animator;
        private MobController controller;
        [SerializeField]
        private float simpleHitTime;
        [SerializeField]
        private float criticalHitTime;

        private void Start()
        {
            stats = GetComponent<CharacterStats>();
            animator = GetComponent<MobAnimator>();
            controller = GetComponent<MobController>();
            attackTimer = 0f;
        }

        private void Update()
        {
            attackTimer -= Time.deltaTime;
        }

        public void Attack(Player player)
        {
            if(stats.attackSpeed.GetStat() != 0)
            {
                if(attackTimer <= 0)
                {
                    float random = Random.Range(0f, 1f);
                    if(stats.criticalStrikeChance.GetStat() > random)
                    {
                        animator.PlayCriticalAttackAnimation();
                        StartCoroutine(TryDamage(player, AttackType.Critical));
                    }
                    else
                    {
                        animator.PlaySimpleAttackAnimation();
                        StartCoroutine(TryDamage(player, AttackType.Simple));
                    }
                    float reload = 200 / stats.attackSpeed.GetStat();
                    attackTimer = reload;
                }
            }
            else
            {
                Debug.LogError("Division by zero");
            }
        }

        private IEnumerator TryDamage(Player player, AttackType attackType)
        {
            if(attackType == AttackType.Simple)
            {
                yield return new WaitForSeconds(criticalHitTime);
                if(Vector3.Distance(transform.position, player.transform.position) < controller.attackDistance)
                {
                    float damageDone = player.TakeDamage(stats.damage.GetStat());
                }
            }
            if(attackType == AttackType.Critical)
            {
                yield return new WaitForSeconds(simpleHitTime);
                if (Vector3.Distance(transform.position, player.transform.position) < controller.attackDistance)
                {
                    float damageDone = player.TakeDamage(Mathf.Round(stats.damage.GetStat() * stats.criticalStrikeModifier.GetStat()));
                }
            }
        }
    }
}