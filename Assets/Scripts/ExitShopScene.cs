using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Menu
{
    public class ExitShopScene : MonoBehaviour
    {
        [SerializeField]
        private ExitShopCanvas exitShopCanvas;
        public bool Ontrigger = false;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.E) && Ontrigger)
            {
                exitShopCanvas.Question.SetActive(true);
                exitShopCanvas.ButtonPrompt.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
            {

                exitShopCanvas.ButtonPrompt.SetActive(true);
                Ontrigger = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Player")
            {

                exitShopCanvas.ButtonPrompt.SetActive(false);
                Ontrigger = false;

            }
        }
    }
}