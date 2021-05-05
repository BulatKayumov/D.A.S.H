using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Player;

namespace DASH._Units
{ 
    public class MobCombat : MonoBehaviour
    {
        private CharacterStats stats;

        private void Start()
        {
            stats = GetComponent<CharacterStats>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                Player player = other.GetComponent<Player>();
                Attack(player);
            } 
        }

        private void Attack(Player player)
        {
            float damageDone = player.TakeDamage(stats.damage.GetStat());
            Debug.Log("I dealt " + damageDone + " damage to player");
        }
    }
}