using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DASH._Player;
using DASH._Units;
using DASH._Dungeon;

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
        public Gradient healthBarGradient;
        public Image healthBarFill;
        [SerializeField]
        private GameObject xpBar;
        private Slider xpBarSlider;
        public Gradient xpBarGradient;
        public Image xpBarFill;
        [SerializeField]
        private GameObject bossHealthBar;
        private Slider bossHealthBarSlider;
        public Gradient bossHealthBarGradient;
        public Image bossHealthBarFill;
        private GameStateData data;
        private Player player;
        private CharacterStats playerStats;
        private PlayerHealth playerHealth;
        private PlayerXP playerXP;
        [SerializeField]
        private Text interactText;
        [SerializeField]
        private Text HealText;
        [SerializeField]
        private Text DamageText;
        [SerializeField]
        private Text LevelText;
        private float healTextTimer = 0f;
        private float damageTextTimer = 0f;
        private Boss boss;
        private CharacterStats bossStats;
        [SerializeField]
        private GameObject bossUI;
        [SerializeField]
        private Text bossNameText;
        private bool bossFightStarted;

        [SerializeField]
        private Text goldText;

        private void Start()
        {
            data = GameStateData.instance;
            healthBarSlider = healthBar.GetComponent<Slider>();
            xpBarSlider = xpBar.GetComponent<Slider>();
            bossHealthBarSlider = bossHealthBar.GetComponent<Slider>();
            player = Player.instance;
            playerStats = player.GetComponent<CharacterStats>();
            playerHealth = player.GetComponent<PlayerHealth>();
            playerXP = player.GetComponent<PlayerXP>();
            bossUI.SetActive(false);
            bossFightStarted = false;
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
            SetHealth(playerHealth.currentHP);
            SetMaxXP(data.levelUpXPValues[playerXP.currentLevel - 1]);
            SetXp(playerXP.currentXP);
            healTextTimer -= Time.deltaTime;
            damageTextTimer -= Time.deltaTime;

            HealText.color = new Color(HealText.color.r, HealText.color.g, HealText.color.b, Mathf.Clamp(healTextTimer, 0, 1));
            DamageText.color = new Color(DamageText.color.r, DamageText.color.g, DamageText.color.b, Mathf.Clamp(damageTextTimer, 0, 1));

            if (bossFightStarted)
            {
                UpdateBossUI();
            }
        }

        public void UpdateCoinsUI()
        {
            goldText.text = GameManager.instance.coins.ToString();
        }

        public void BossFightStarted()
        {
            boss = GameManager.instance.boss;
            bossStats = boss.GetComponent<CharacterStats>();
            bossNameText.text = GameManager.instance.boss.mobName;
            bossUI.SetActive(true);
            bossFightStarted = true;
        }

        public void UpdateBossUI()
        {
            bossHealthBarSlider.maxValue = bossStats.maxHealth.GetStat();
            bossHealthBarSlider.value = boss.currentHP;
            bossHealthBarFill.color = bossHealthBarGradient.Evaluate(bossHealthBarSlider.normalizedValue);
        }

        public void SetMaxHealth(float health)
        {
            healthBarSlider.maxValue = health;
            //fill.color = gradient.Evaluate(1f);
        }

        public void SetHealth(float health)
        {
            healthBarSlider.value = health;
            healthBarFill.color = healthBarGradient.Evaluate(healthBarSlider.normalizedValue);
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

        public void SetMaxXP(float xp)
        {
            xpBarSlider.maxValue = xp;
            //fill.color = gradient.Evaluate(1f);
        }

        public void SetXp(float xp)
        {
            xpBarSlider.value = xp;
            xpBarFill.color = xpBarGradient.Evaluate(healthBarSlider.normalizedValue);
        }

        public void SetLevelText(int currentLevel)
        {
            LevelText.text = "Lvl " + currentLevel;
        }
    }
}