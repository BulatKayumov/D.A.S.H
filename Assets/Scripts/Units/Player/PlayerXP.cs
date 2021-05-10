using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Units;
using DASH._UI;
using DASH._Dungeon;

namespace DASH._Player
{
    public class PlayerXP : MonoBehaviour
    {
        private GameStateData data;
        private CharacterStats stats;
        private UIManager ui;
        public float currentXP = 0f;
        public int currentLevel = 1;
        private void Start()
        {
            data = GameStateData.instance;
            stats = GetComponent<CharacterStats>();
            ui = UIManager.instance;
            currentXP = 0f;
            currentLevel = 1;
        }

        public void AddXP(float value)
        {
            currentXP += value;
            if(data.levelUpXPValues.Length >= currentLevel)
            {
                if(currentXP >= data.levelUpXPValues[currentLevel - 1])
                {
                    LevelUp(currentXP - data.levelUpXPValues[currentLevel - 1]);
                    currentXP = 0f;
                }
            } 
            else
            {
                Debug.LogWarning("Player reached max level");
            }
        }

        private void LevelUp(float remainingXP)
        {
            currentLevel += 1;
            ui.SetLevelText(currentLevel);
            if(remainingXP > 0)
            {
                AddXP(remainingXP);
            }
        }
    }
}