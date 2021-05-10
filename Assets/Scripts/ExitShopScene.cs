using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Menu
{
    public class ExitShopScene : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
            {
              
                 Menu_SceneManager.instance.NewMenu();
            }
        }
    }
}