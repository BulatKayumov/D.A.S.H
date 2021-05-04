using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Spawn
{
    public class Cube : MonoBehaviour
    {
        void OnTriggerStay(Collider other)
        {
            Spawn_SceneManager.instance.NewGame();
        }
    }
}