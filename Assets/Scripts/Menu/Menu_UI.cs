using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DASH._Menu
{
    public class Menu_UI : MonoBehaviour
    {
        #region Singleton

        public static Menu_UI instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        [SerializeField]
        private Text goldText;

        public void UpdateCoinsUI()
        {
            goldText.text = Menu_GameManager.instance.coins.ToString();
        }
    }
}