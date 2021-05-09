using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using DASH._Player;
using DASH._Units;

namespace DASH._Dungeon
{
    [DefaultExecutionOrder(-200)]
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        public static GameManager instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        public List<RoomPrefab> RoomPrefabs;
        public List<Room> Rooms;
        public List<Door> ClosedByKeyDoors;
        public Room[,] SpawnedRooms;
        GameStateData data;
        bool generated = false;

        void Start()
        {
            data = GameStateData.instance;
            RoomPrefabs = new List<RoomPrefab>();
            for(int i = 0; i < data.RoomPrefabs.Length; i++)
            {
                RoomPrefabs.Add(new RoomPrefab { room = data.RoomPrefabs[i], count = data.RoomPrefabs[i].Count, index = i });
            }
            Rooms = new List<Room>();
            Generator.instance.Generate();
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Player player = Instantiate(data.PlayerPrefab, data.playerSpawnCords, Quaternion.identity);
            CharacterStats stats = player.GetComponent<CharacterStats>();

        }
    }
}