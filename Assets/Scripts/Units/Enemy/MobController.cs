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
        private Player player;
        public float attackDistance = 0.5f;
        private MobCombat combat;
        private MobMovement movement;
        private MobAnimator animator;
        private CharacterStats stats;
        private Collider collider;
        public Room room;
        private float walkTimer = 0f;
        public float currentHP = 0f;
        [SerializeField]
        private float rewardGold;
        [SerializeField]
        private float rewardXP;
        public bool alive { get; private set; }

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
                        combat.Attack(player);
                    }
                    else
                    {
                        movement.Move(player.transform.position);
                    }
                }
                else
                {
                    if(walkTimer <= 0)
                    {
                        movement.Walk(room.transform.position + new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f)));
                        walkTimer = Random.Range(7f, 20f);
                    }
                    walkTimer -= Time.deltaTime;
                }
            }
        }

        public float TakeDamage(float value)
        {
            float damage = value - stats.armor.GetStat();
            currentHP -= damage;
            currentHP = Mathf.Clamp(currentHP, 0, stats.maxHealth.GetStat());
            Debug.Log(gameObject.name + " has taken " + damage + " damage. Current HP = " + currentHP);
            if (currentHP == 0)
            {
                StartCoroutine(Dead());
            }
            return damage;
        }

        private IEnumerator Dead()
        {
            Debug.Log("I am " + gameObject.name + " and I dead");
            alive = false;
            player.GetComponent<PlayerXP>().AddXP(rewardXP);
            animator.PlayDeathAnimation();
            movement.StopAgent();
            collider.enabled = false;
            yield return new WaitForSecondsRealtime(4);
            Destroy(gameObject);
        }

        public void SetPosition(Vector3 position)
        {
            movement.SetPosition(position);
        }
    }
}