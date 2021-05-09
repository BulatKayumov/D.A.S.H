using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Player;

namespace DASH._Dungeon
{
    public class LoadDange : MonoBehaviour
    {
        public GameObject Assets;

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
                Player.instance.playerCamera.enabled = true;
            }
        }
    }
}