using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Dungeon
{
    public class LoadDange : MonoBehaviour
    {
        public GameObject Assets;
        public Camera PlayerCamera;

        Generator generator;
        // Start is called before the first frame update
        void Start()
        {
            generator = Generator.instance;
        }

        // Update is called once per frame
        void Update()
        {
            if (generator.IsGenerated)
            {
                Assets.SetActive(false);
                PlayerCamera.enabled = true;
            }
        }
    }
}