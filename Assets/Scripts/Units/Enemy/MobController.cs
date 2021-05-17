using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Player;
using DASH._Dungeon;

namespace DASH._Units
{
    public class MobController : MonoBehaviour
    {
        public string mobName;
        public bool agressive = false;
        protected Player player;
        public float attackDistance = 0.5f;
        protected MobCombat combat;
        protected MobMovement movement;
        protected MobAnimator animator;
        protected CharacterStats stats;
        protected Collider collider;
        public Room room;
        private float walkTimer = 0f;
        public float currentHP = 0f;
        [SerializeField]
        protected int rewardGold;
        [SerializeField]
        protected float rewardXP;
        [SerializeField]
        private bool walkable = true;
        public bool alive { get; protected set; }

        private void Awake()
        {
            combat = GetComponent<MobCombat>();
            movement = GetComponent<MobMovement>();
            stats = GetComponent<CharacterStats>();
            animator = GetComponent<MobAnimator>();
            collider = GetComponent<Collider>();
        }

        void Start()
        {
            player = Player.instance;
            currentHP = stats.maxHealth.GetStat();
            alive = true;
        }

        void Update()
        {
            if (alive)
            {
                if (agressive)
                {
                    if(Vector3.Distance(player.transform.position, transform.position) < attackDistance)
                    {
                        if (FaceTarget(player.transform))
                        {
                            combat.Attack(player);
                        }
                    }
                    else
                    {
                        movement.Move(player.transform.position);
                    }
                }
                else
                {
                    if(walkTimer <= 0 && walkable)
                    {
                        movement.Walk(room.transform.position + new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f)));
                        walkTimer = Random.Range(7f, 20f);
                    }
                    walkTimer -= Time.deltaTime;
                }
            }
        }

        private bool FaceTarget(Transform target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
            return Quaternion.Angle(transform.rotation, lookRotation) < 20;
        }

        public void SetPosition(Vector3 position)
        {
            movement.SetPosition(position);
        }

        public virtual float TakeDamage(float value)
        {
            float damage = value - stats.armor.GetStat();
            currentHP -= damage;
            currentHP = Mathf.Clamp(currentHP, 0, stats.maxHealth.GetStat());
            if (currentHP == 0)
            {
                StartCoroutine(Dead());
            }
            return damage;
        }

        protected virtual IEnumerator Dead()
        {
            alive = false;
            player.GetComponent<PlayerXP>().AddXP(rewardXP);
            GameManager.instance.EarnCoins(rewardGold);
            room.MobDied(this);
            animator.PlayDeathAnimation();
            movement.StopAgent();
            collider.enabled = false;
            yield return new WaitForSeconds(4);
            Destroy(gameObject);
        }
    }
}