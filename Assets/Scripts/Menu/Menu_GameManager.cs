using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Menu
{
    public class Menu_GameManager : MonoBehaviour
    {
        #region Singleton

        public static Menu_GameManager instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        public int coins;
        void Start()
        {
            if (!PlayerPrefs.HasKey("Coins"))
            {
                PlayerPrefs.SetInt("Coins", 0);
                coins = 0;
            }
            else
            {
                coins = PlayerPrefs.GetInt("Coins");
            }
            Menu_UI.instance.UpdateCoinsUI();
        }

        public void AddCoins(int value)
        {
            coins += value;
            PlayerPrefs.SetInt("Coins", coins);
            Menu_UI.instance.UpdateCoinsUI();
        }

        public bool SubtractCoins(int value)
        {
            if(coins < value)
            {
                return false;
            }
            else
            {
                coins -= value;
                PlayerPrefs.SetInt("Coins", coins);
                Menu_UI.instance.UpdateCoinsUI();
                return true;
            }
        }
    }
}