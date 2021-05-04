using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DASH.Spawn
{

    public class EnterDungeon : MonoBehaviour
    {

        public GameObject Door;
        public void EnterDungeonDoor()
        {
            if (Door.activeSelf)
            {
                
                Spawn_SceneManager.instance.NewGame();
            }
            
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}