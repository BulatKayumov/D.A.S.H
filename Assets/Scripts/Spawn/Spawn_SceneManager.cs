using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DASH._Spawn
{
    public class Spawn_SceneManager : MonoBehaviour
    {
        #region Singleton

        public static Spawn_SceneManager instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        public void NewGame()
        {
            Debug.Log("load 1");
            SceneManager.LoadScene(1);
        }
    }
}
