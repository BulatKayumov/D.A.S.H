using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DASH._Dungeon
{
    public class Dungeon_SceneManager : MonoBehaviour
    {
        #region Singleton

        public static Dungeon_SceneManager instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion
        public void ReturnToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
