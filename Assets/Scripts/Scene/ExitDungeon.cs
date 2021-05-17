using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Dungeon;

namespace DASH._Menu
{
    public class ExitDungeon : MonoBehaviour

    {
        public GameObject Exit;
        public GameObject ExitQuestion;
        public GameObject ON;
        public GameObject OFF;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !Exit.activeSelf && !ExitQuestion.activeSelf)
            {
                Exit.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0;
            }
            // if (Input.GetKeyDown(KeyCode.Escape) && Exit.activeSelf && !ExitQuestion.activeSelf)
            //{
            //    Exit.SetActive(false);
            //    Cursor.lockState = CursorLockMode.Locked;
            //    Cursor.visible = false;

            //}

            //if (Input.GetKeyDown(KeyCode.Escape) && !Exit.activeSelf && ExitQuestion.activeSelf)
            //{
            //    ExitQuestion.SetActive(false);
            //    Cursor.lockState = CursorLockMode.Locked;
            //    Cursor.visible = false; 
            //}

        }

        public void ReturnDungeonPlace()
        {
            ExitQuestion.SetActive(false);
            Exit.SetActive(true);
        }
        public void LeaveDungeonPlace()
        {
            GameManager.instance.LeaveDungeon();
        }

        public void xActivate()
        {
            Exit.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
        public void FirstExit()
        {
            ExitQuestion.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Exit.SetActive(false);
            Time.timeScale = 0;
        }
        public void VolumeOff()
        {
            ON.SetActive(false);
            OFF.SetActive(true);
        }
        public void VolumeON()
        {
            ON.SetActive(true);
            OFF.SetActive(false);
        }
    }
}