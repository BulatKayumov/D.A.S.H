using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Menu
{
    public class VisitShop : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void visitShop()
        {
            Menu_SceneManager.instance.NewShop();
        }
    }
}