using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DASH._Units;
using DASH._Player;

namespace DASH._Dungeon
{
    public struct RoomPrefab
    {
        public Room room;
        public int count;
        public int index;
    }

    [DefaultExecutionOrder(-300)]
    public class GameStateData : MonoBehaviour
    {
        #region Singleton

        public static GameStateData instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        public GameObject roomsRoot;
        public GameObject Player;
        public Door doorPrefab;
        public WallEntrance wallEntrancePrefab;

        public Room[] RoomPrefabs;
        //public Interior[] interiors;
        public GameObject mobsRoot;
        public MobController[] mobPrefabs;
        public Player PlayerPrefab;
        public Vector3 playerSpawnCords = new Vector3(0, 0, 0);
    }
}