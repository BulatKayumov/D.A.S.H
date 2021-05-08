using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DASH._Player;
using DASH._Units;

namespace DASH._UI
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;
        public Image fill;
        private Player player;
        private CharacterStats playerStats;

        private void Start()
        {
            player = Player.instance;
            playerStats = player.gameObject.GetComponent<CharacterStats>();
        }

        private void Update()
        {
            SetMaxHealth(playerStats.maxHealth.GetStat());
            SetHealth(player.currentHP);
        }

        public void SetMaxHealth(float health)
        {
            slider.maxValue = health;
            //fill.color = gradient.Evaluate(1f);
        }

        public void SetHealth(float health)
        {
            slider.value = health;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }

    }
}