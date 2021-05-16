using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Menu
{
    public class ExitShopCanvas : MonoBehaviour
    {

        public GameObject Question;
        public GameObject YES;
        public GameObject NO;
        public GameObject ButtonPrompt;
        // Start is called before the first frame update
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LeaveShop()
        {
            Menu_SceneManager.instance.NewMenu();
        }

        public void ReturnShop()
        {
            Question.SetActive(false);
            ButtonPrompt.SetActive(true);
        }
    }
}