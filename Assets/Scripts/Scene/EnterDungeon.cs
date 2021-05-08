using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DASH._Menu
{

    public class EnterDungeon : MonoBehaviour
    {

        public GameObject Door;
        public void EnterDungeonDoor()
        {
            if (Door.activeSelf)
            {
                Menu_SceneManager.instance.NewGame();
            }
            
        }
    }
}