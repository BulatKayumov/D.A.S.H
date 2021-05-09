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
        [SerializeField]
        private Text HealText;
        [SerializeField]
        private Text DamageText;
        private float healTextTimer = 0f;
        private float damageTextTimer = 0f;

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
            healTextTimer -= Time.deltaTime;
            damageTextTimer -= Time.deltaTime;

            HealText.color = new Color(HealText.color.r, HealText.color.g, HealText.color.b, Mathf.Clamp(healTextTimer, 0, 1));
            DamageText.color = new Color(DamageText.color.r, DamageText.color.g, DamageText.color.b, Mathf.Clamp(damageTextTimer, 0, 1));
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

        public void SetHealText(float value)
        {
            HealText.text = "+" + value;
            HealText.color = new Color(HealText.color.r, HealText.color.g, HealText.color.b, 1);
            healTextTimer = 3f;
        }

        public void SetDamageText(float value)
        {
            DamageText.text = "-" + value;
            DamageText.color = new Color(DamageText.color.r, DamageText.color.g, DamageText.color.b, 1);
            damageTextTimer = 3f;
        }
    }
}