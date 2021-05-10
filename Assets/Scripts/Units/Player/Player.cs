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
        private UIManager ui;
        public Camera playerCamera;
        private void Start()
        {
            stats = GetComponent<CharacterStats>();
            ui = UIManager.instance;
        }

        public float TakeDamage(float value)
        {
            float damage = value - stats.armor.GetStat();
            ui.SetDamageText(damage);
            return damage;
        }
    }
}