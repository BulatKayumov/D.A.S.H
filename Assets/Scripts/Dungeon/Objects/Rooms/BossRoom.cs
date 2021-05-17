using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Units;
using DASH._UI;

namespace DASH._Dungeon
{
    public class BossRoom : Room
    {
        private void Start()
        {
            SpawnBoss(GameStateData.instance.bossPrefab);
        }

        private void SpawnBoss(Boss prefab)
        {
            {
                Vector3 position = new Vector3(transform.position.x, 0, transform.position.z);
                Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                Boss boss = Instantiate(prefab, GameStateData.instance.mobsRoot.transform);
                boss.transform.position = position;
                boss.SetPosition(position);
                boss.transform.rotation = rotation;
                boss.agressive = false;
                boss.room = this;
                mobs.Add(boss);
                GameManager.instance.boss = boss;
            }
        }
        protected override void RoomEntry()
        {
            base.RoomEntry();
            LockAllDoors();
            foreach(MobController mob in mobs){
                mob.agressive = true;
            }
            UIManager.instance.BossFightStarted();
        }

        private void LockAllDoors()
        {
            foreach (Door door in doors)
            {
                door.Lock();
            }
            Debug.Log("Doors locked");
        }
    }
}
