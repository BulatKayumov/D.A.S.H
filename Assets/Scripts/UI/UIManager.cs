using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DASH._Player;
using DASH._Units;

namespace DASH._UI
{
    public class UIManager : MonoBehaviour
    {
        #region Singleton

        public static UIManager instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        [SerializeField]
        private GameObject healthBar;
        private Slider healthBarSlider;
        public Gradient healtBarGradient;
        public Image healthBarFill;
        private Player player;
        private CharacterStats playerStats;
        [SerializeField]
        private Text interactText;

        private void Start()
        {
            healthBarSlider = healthBar.GetComponent<Slider>();
            player = Player.instance;
            playerStats = player.gameObject.GetComponent<CharacterStats>();
            interactText.gameObject.SetActive(false);
        }

        public void ShowInteractText(string text)
        {
            interactText.text = text;
            interactText.gameObject.SetActive(true);
        }

        public void HideInteractText()
        {
            interactText.gameObject.SetActive(false);
        }

        private void Update()
        {
            SetMaxHealth(playerStats.maxHealth.GetStat());
            SetHealth(player.currentHP);
        }

        public void SetMaxHealth(float health)
        {
            healthBarSlider.maxValue = health;
            //fill.color = gradient.Evaluate(1f);
        }

        public void SetHealth(float health)
        {
            healthBarSlider.value = health;
            healthBarFill.color = healtBarGradient.Evaluate(healthBarSlider.normalizedValue);
        }

    }
}