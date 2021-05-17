using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DASH._Dungeon
{
    public class MobsRoom : Room
    {
        public float mobsCount = 10;
        protected override void RoomEntry()
        {
            base.RoomEntry();
            StartCoroutine(SpawnMobs());
            LockAllDoors();
        }
        public IEnumerator SpawnMobs()
        {
            for(int i = 0; i < mobsCount; i++)
            {
                SpawnMob(GameStateData.instance.mobPrefabs[Random.Range(0, GameStateData.instance.mobPrefabs.Length)], true);
                yield return new WaitForSeconds(1f);
            }
            StartCoroutine(CheckMobsALive());
        }

        private IEnumerator CheckMobsALive()
        {
            while (mobs.Count > 0)
            {
                yield return new WaitForSeconds(1f);
            }
            UnlockAllDoors();
        }

        private void LockAllDoors()
        {
            foreach(Door door in doors)
            {
                door.Lock();
            }
            Debug.Log("Doors locked");
        }

        private void UnlockAllDoors()
        {
            foreach (Door door in doors)
            {
                door.Unlock();
            }
            Debug.Log("Doors unlocked");
        }
    }
}
