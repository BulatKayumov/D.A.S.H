using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Menu
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 1)]
    public class Item : ScriptableObject
    {
        new public string name;
        public Sprite sprite;
        public StatModifier[] statModifiers;
        public int cost;
        public bool Buy()
        {
            if (Menu_GameManager.instance.SubtractCoins(cost))
            {
                PlayerPrefs.SetInt(name, 1);
                return true;
            }
            return false;
        }
    }
}