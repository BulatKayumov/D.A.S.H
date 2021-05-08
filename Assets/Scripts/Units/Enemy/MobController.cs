using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Player;
using DASH._Dungeon;

namespace DASH._Units
{
    public class MobController : MonoBehaviour
    {
        public bool agressive = false;
        private Player player;
        public float attackDistance = 0.5f;
        private MobCombat combat;
        private MobMovement movement;
        public Room room;
        private float walkTimer = 0f;

        void Start()
        {
            player = Player.instance;
            combat = GetComponent<MobCombat>();
            movement = GetComponent<MobMovement>();
        }

        void Update()
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
}