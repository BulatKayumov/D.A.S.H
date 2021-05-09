using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Units;

namespace DASH._Player
{
    public class PlayerSword : MonoBehaviour
    {
        Player player;
        PlayerCombat combat;

        private void Start()
        {
            player = Player.instance;
            combat = player.GetComponent<PlayerCombat>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<MobController>() && combat.isAttacking)
            {
                Debug.Log("Sword trigger");
                MobController mob = other.GetComponent<MobController>();
                combat.Damage(mob);
            }
        }
    }
}
