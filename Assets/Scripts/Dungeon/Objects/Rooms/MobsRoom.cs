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
        }
        public IEnumerator SpawnMobs()
        {
            for(int i = 0; i < mobsCount; i++)
            {
                SpawnMob(GameStateData.instance.mobPrefabs[Random.Range(0, GameStateData.instance.mobPrefabs.Length)], true);
                yield return new WaitForSecondsRealtime(1f);
            }
        }

        public void StartFight()
        {

        }
    }
}
