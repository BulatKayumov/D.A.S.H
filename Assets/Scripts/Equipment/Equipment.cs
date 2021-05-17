using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Player;

namespace DASH._Menu
{
    public class Equipment : MonoBehaviour
    {
        #region Singleton

        public static Equipment instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        [SerializeField]
        private GameObject inventoryRoot;
        [SerializeField]
        SetCharacter setCharacter;
        [SerializeField]
        private Slot[] torso;
        [SerializeField]
        private Slot[] legs;

        void Start()
        {
            inventoryRoot.SetActive(false);
        }

        public void OpenEquipment()
        {
            inventoryRoot.SetActive(true);

            if (PlayerPrefs.HasKey("Рубашка"))
            {
                if (PlayerPrefs.GetInt("Рубашка") == 1)
                {
                    torso[0].gameObject.SetActive(true);
                }
                else
                {
                    torso[0].gameObject.SetActive(false);
                }
            }

            if (PlayerPrefs.HasKey("Легкие доспехи"))
            {
                if (PlayerPrefs.GetInt("Легкие доспехи") == 1)
                {
                    torso[1].gameObject.SetActive(true);
                }
                else
                {
                    torso[1].gameObject.SetActive(false);
                }
            }

            if (PlayerPrefs.HasKey("Тяжелые доспехи"))
            {
                if (PlayerPrefs.GetInt("Тяжелые доспехи") == 1)
                {
                    torso[2].gameObject.SetActive(true);
                }
                else
                {
                    torso[2].gameObject.SetActive(false);
                }
            }

            if (PlayerPrefs.HasKey("Брюки"))
            {
                if (PlayerPrefs.GetInt("Брюки") == 1)
                {
                    legs[0].gameObject.SetActive(true);
                }
                else
                {
                    legs[0].gameObject.SetActive(false);
                }
            }

            if (PlayerPrefs.HasKey("Легкие поножи"))
            {
                if (PlayerPrefs.GetInt("Легкие поножи") == 1)
                {
                    legs[1].gameObject.SetActive(true);
                }
                else
                {
                    legs[1].gameObject.SetActive(false);
                }
            }

            if (PlayerPrefs.HasKey("Тяжелые поножи"))
            {
                if (PlayerPrefs.GetInt("Тяжелые поножи") == 1)
                {
                    legs[2].gameObject.SetActive(true);
                }
                else
                {
                    legs[2].gameObject.SetActive(false);
                }
            }
            if (PlayerPrefs.HasKey("currentTorso"))
            {
                EquipItem(1, PlayerPrefs.GetInt("currentTorso"));

            }
            else
            {
                PlayerPrefs.SetInt("currentTorso", 0);
                setCharacter.AddItem(setCharacter.itemGroups[1], 0);
            }
            if (PlayerPrefs.HasKey("currentLegs"))
            {
                EquipItem(0, PlayerPrefs.GetInt("currentLegs"));
            }
            else
            {
                PlayerPrefs.SetInt("currentLegs", 0);
                setCharacter.AddItem(setCharacter.itemGroups[0], 0);
            }
            UpdateInventory();
        }

        public void EquipItem(int itemGroupID, int itemID)
        {
            for (int n = 0; n < setCharacter.itemGroups[itemGroupID].items.Length; n++)
            {
                if (setCharacter.HasItem(setCharacter.itemGroups[itemGroupID], n))
                {
                    List<GameObject> removedObjs = setCharacter.GetRemoveObjList(setCharacter.itemGroups[itemGroupID], n);
                    for (int m = 0; m < removedObjs.Count; m++)
                    {
                        if (removedObjs[m] != null)
                        {
                            DestroyImmediate(removedObjs[m]);
                        }
                    }
                }
            }
            setCharacter.AddItem(setCharacter.itemGroups[itemGroupID], itemID);
            UpdateInventory();
        }

        private void UpdateInventory()
        {
            if (PlayerPrefs.HasKey("currentTorso"))
            {
                foreach (Slot torso in torso)
                {
                    if (PlayerPrefs.GetInt("currentTorso") == torso.id)
                    {
                        torso.equipButton.gameObject.SetActive(false);
                        torso.unequipButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        torso.unequipButton.gameObject.SetActive(false);
                        torso.equipButton.gameObject.SetActive(true);
                    }
                }
            }
            if (PlayerPrefs.HasKey("currentLegs"))
            {
                foreach (Slot leg in legs)
                {
                    if (PlayerPrefs.GetInt("currentLegs") == leg.id)
                    {
                        leg.equipButton.gameObject.SetActive(false);
                        leg.unequipButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        leg.unequipButton.gameObject.SetActive(false);
                        leg.equipButton.gameObject.SetActive(true);
                    }
                }
            }
        }

        public void CloseEquipment()
        {
            inventoryRoot.SetActive(false);
            PlayerPrefs.Save();
        }
    }
}