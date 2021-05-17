using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Units;
using DASH._UI;

namespace DASH._Player
{
    public class Player : MonoBehaviour
    {
        #region Singleton

        public static Player instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        private CharacterStats stats;
        private PlayerHealth health;
        public Camera playerCamera;
        public bool alive;
        private void Start()
        {
            alive = true;
            stats = GetComponent<CharacterStats>();
            health = GetComponent<PlayerHealth>();
        }

        public float TakeDamage(float value)
        {
            if (alive)
            {
                float damage = value - stats.armor.GetStat();
                health.TakeDamage(damage);
                return damage;
            }
            else return 0;
        }
    }
}