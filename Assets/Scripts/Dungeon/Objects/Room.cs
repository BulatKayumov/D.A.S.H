using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DASH._Units;

namespace DASH._Dungeon
{
    public enum RoomType
    {
        Required, Simple
    }
    public class Room : MonoBehaviour
    {
        public string roomName;
        public int index;
        public List<int> way;
        public DoorPlace[] doorPlaces;
        public GameObject triggerCubesRoot;
        public Door entryDoor;
        [SerializeField]
        protected List<Door> doors = new List<Door>();
        public Vector2Int Coordinates;
        public Vector2Int size;
        [Range(0, 100)]
        public int rating = 50;
        [Range(1, 30)]
        public int Count = 1;
        public int radius = 1;
        public RoomType roomType;
        public int vacantPlacesRequiredAmount = 1;
        public int doorsLimit;

        [HideInInspector]
        public DoorPlace selectedDoorPlace;

        [SerializeField]
        protected List<MobController> mobs = new List<MobController>();

        public bool HasDoorTo(Vector2Int cords, DoorPlace otherDoorPlace)
        {
            int doorsCount = 0;
            foreach(DoorPlace doorPlace in doorPlaces)
            {
                if (!doorPlace.isActive)
                {
                    doorsCount++;
                }
            }
            if(doorsCount >= doorsLimit)
            {
                return false;
            }
            foreach (DoorPlace doorPlace in doorPlaces)
            {
                if (doorPlace.isActive &&
                    doorPlace.forDoor &&
                    Coordinates + doorPlace.cords + doorPlace.OrientationCords() == cords + otherDoorPlace.cords)
                {
                    otherDoorPlace.neighbour = doorPlace;
                    doorPlace.neighbour = otherDoorPlace;
                    return true;
                }
            }
            return false;
        }

        public void EnterTrigger()
        {
            RoomEntry();
            Destroy(triggerCubesRoot);
        }

        protected virtual void RoomEntry()
        {

        }

        public void RotateRandomly()
        {
            int count = Random.Range(0, 4);

            for (int i = 0; i < count; i++)
            {
                int tmp = size.x;
                size.x = size.y;
                size.y = tmp;

                transform.Rotate(0, 90, 0);

                foreach(DoorPlace doorPlace in doorPlaces)
                {
                    doorPlace.Rotate(size.y);
                }
            }
        }

        public void AddEntryDoor()
        {
            WallEntrance doorEntrance = Instantiate(GameStateData.instance.wallEntrancePrefab, gameObject.transform);
            doorEntrance.SetPosition(this.Coordinates + selectedDoorPlace.cords, selectedDoorPlace.orientation);
            Door newDoor = Instantiate(GameStateData.instance.doorPrefab, gameObject.transform);
            newDoor.SetPosition(this.Coordinates + selectedDoorPlace.cords, selectedDoorPlace.orientation);
            this.entryDoor = newDoor;
            newDoor.entryRoom = selectedDoorPlace.neighbour.GetComponentInParent<Room>();
            AddDoor(newDoor);
            newDoor.entryRoom.AddDoor(newDoor);
        }

        public void AddDoor(Door door)
        {
            doors.Add(door);
        }

        public int GetRating(int vacantPlacesCount)
        {
            if(vacantPlacesCount < vacantPlacesRequiredAmount)
            {
                return 0;
            }
            return rating;
        }

        public virtual void SpawnMob(MobController prefab, bool agressive)
        {
            Vector2 spawnArea = new Vector2(size.x * (Generator.instance.tileSize - 2)  / 2, size.y * (Generator.instance.tileSize - 2) / 2);
            Vector3 position = new Vector3(Random.Range(transform.position.x - spawnArea.x, transform.position.x + spawnArea.x),
                                            0,
                                            Random.Range(transform.position.z - spawnArea.y, transform.position.z + spawnArea.y));
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360) , 0);
            MobController newMob = Instantiate(prefab, GameStateData.instance.mobsRoot.transform);
            newMob.transform.position = position;
            newMob.SetPosition(position);
            newMob.transform.rotation = rotation;
            newMob.agressive = agressive;
            newMob.room = this;
            mobs.Add(newMob);
        }

        public void MobDied(MobController mob)
        {
            if (!mobs.Contains(mob))
            {
                Debug.LogError(roomName + " doesn't contain " + mob.mobName);
            } else
            {
                mobs.Remove(mob);
            }
        }
    }
}