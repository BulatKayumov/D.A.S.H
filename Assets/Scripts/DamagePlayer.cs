using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{ 
 

    public class DamagePlayer : MonoBehaviour
    {
        public int damage = 25;
        private void OnTriggerEnter(Collider other)
        {
            Player playerStats =  other.GetComponent<Player>();

            if (playerStats != null)
            {
                playerStats.TakeDamage(damage); 
            }    
        }
    }
   
          
}