using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Units;
using DASH._UI;

namespace DASH._Player
{
    public class PlayerEquipment : MonoBehaviour
    {
        private CharacterStats stats;
        //private UIManager ui;
        SetCharacter setCharacter;
        private const int torsoGroupID = 1;
        private const int legsGroupID = 0;

        private void Awake()
        {
            setCharacter = GetComponent<SetCharacter>();
            stats = GetComponent<CharacterStats>();
        }

        private void Start()
        {
            //ui = UIManager.instance;
        }

        public void TorsoEquip(int itemID)
        {
            GameObject addedObj = setCharacter.AddItem(setCharacter.itemGroups[torsoGroupID], itemID);
        }

        public void LegsEquip(int itemID)
        {
            GameObject addedObj = setCharacter.AddItem(setCharacter.itemGroups[legsGroupID], itemID);
        }
    }
}