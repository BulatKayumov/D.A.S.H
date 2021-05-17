using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DASH._Menu
{
    [System.Serializable]
    public struct StatModifier
    {
        public string StatName;
        public float Modifier;
    }
    public class Shop : MonoBehaviour
    {
        [SerializeField]
        private Item[] itemObjects;
        public List<Item> items;
        private Item currentItem;
        private int currentIndex;

        [SerializeField]
        private Text nameText;
        [SerializeField]
        private Image image;
        [SerializeField]
        private Text statModifiersText;
        public Button Next;
        public Button Previous;
        public Button Buy;
        public Text BuyButtonText;

        [SerializeField]
        private GameObject shopRoot;
        [SerializeField]
        private GameObject shopClosed;
        [SerializeField]
        private GameObject notEnoughMoney;

        private void Start()
        {
            shopRoot.SetActive(false);
            shopClosed.SetActive(false);
            notEnoughMoney.SetActive(false);
        }

        public void OpenShop()
        {
            notEnoughMoney.SetActive(false);
            items = new List<Item>();
            foreach(Item item in itemObjects)
            {
                if (PlayerPrefs.HasKey(item.name))
                {
                    if(PlayerPrefs.GetInt(item.name) == 0)
                    {
                        items.Add(item);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt(item.name, 0);
                    items.Add(item);
                }
            }
            if(items.Count > 0)
            {
                currentIndex = 0;
                currentItem = items[currentIndex];
                Previous.gameObject.SetActive(false);
                if (items.Count > 1)
                {
                    Next.gameObject.SetActive(true);
                }
                else
                {
                    Next.gameObject.SetActive(false); ;
                }
                ShowItem(currentItem);
                shopRoot.SetActive(true);
            }
            else
            {
                shopClosed.SetActive(true);
            }
        }

        public void CloseShop()
        {
            shopRoot.SetActive(false);
            shopClosed.SetActive(false);
            PlayerPrefs.Save();
        }

        public void ShowItem(Item item)
        {
            nameText.text = item.name;
            image.sprite = item.sprite;
            string text = "";
            foreach(StatModifier statModifier in item.statModifiers)
            {
                text += statModifier.StatName + " +" + statModifier.Modifier + "\n";
            }
            statModifiersText.text = text;
            BuyButtonText.text = item.cost.ToString();
        }

        public void NextItem()
        {
            currentIndex++;
            currentItem = items[currentIndex];
            ShowItem(currentItem);
            Previous.gameObject.SetActive(true);
            if(currentIndex == items.Count - 1)
            {
                Next.gameObject.SetActive(false);
            }
        }

        public void PreviousItem()
        {
            currentIndex--;
            currentItem = items[currentIndex];
            ShowItem(currentItem);
            Next.gameObject.SetActive(true);
            if(currentIndex == 0)
            {
                Previous.gameObject.SetActive(false);
            }
        }

        public void TryBuyItem()
        {
            if (currentItem.Buy())
            {
                CloseShop();
                OpenShop();
            }
            else
            {
                StartCoroutine(ShowNotEnoughMoneyText());
            }
        }

        private IEnumerator ShowNotEnoughMoneyText()
        {
            notEnoughMoney.SetActive(true);
            yield return new WaitForSeconds(2f);
            notEnoughMoney.SetActive(false);
        }

    }
}