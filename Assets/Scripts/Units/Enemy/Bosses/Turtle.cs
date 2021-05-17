using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Units
{
    public class Turtle : Boss
    {
        [SerializeField]
        private float reflectDamage;
        public override float TakeDamage(float value)
        {
            player.TakeDamage(reflectDamage);
            return base.TakeDamage(value); 
        }
    }
}