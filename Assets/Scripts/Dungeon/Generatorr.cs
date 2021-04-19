using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Generator : MonoBehaviour
{
    public int roomsCount = 15;
    public int maxMapSize = 10;
    public float tileSize = 30;

    public Room[] RoomPrefabs;
    public Room StartRoom;
    public Room[,] SpawnedRooms;
    public GameObject roomsRoot;

    public IEnumerator Start()
    {
        SpawnedRooms = new Room[maxMapSize, maxMapSize];
        SpawnedRooms[maxMapSize / 2, maxMapSize / 2] = StartRoom;

        for (int i = 0; i < roomsCount; i++)
        {
            yield return new WaitForSecondsRealtime(0.01f);
            PlaceRoom();
        }
    }

    public void Generate()
    {
        SpawnedRooms = new Room[maxMapSize, maxMapSize];
        SpawnedRooms[maxMapSize / 2, maxMapSize / 2] = StartRoom;

        for (int i = 0; i < roomsCount; i++)
        {
            PlaceRoom();
        }

    }
    private void PlaceRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < SpawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < SpawnedRooms.GetLength(1); y++)
            {
                if (SpawnedRooms[x, y] == null)
                {
                    continue;
                }

                int maxX = SpawnedRooms.GetLength(0) - 1;
                int maxY = SpawnedRooms.GetLength(1) - 1;

                if (x > 0 && SpawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && SpawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && SpawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && SpawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }

        Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)], roomsRoot.transform);

        int limit = 500;

        while (limit-- > 0)
        {
            Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));

            if (ConnectToSomething(newRoom, position))
            {
                newRoom.transform.position = new Vector3((position.x - maxMapSize / 2) * tileSize, 0, (position.y - maxMapSize / 2) * tileSize);
                SpawnedRooms[position.x, position.y] = newRoom;
                return;
            }
            if(limit == 1)
            {
                Debug.LogError("Didnt connected");
            }
        }

    }
    private bool ConnectToSomething(Room room, Vector2Int position)
    {
        List<Vector2Int> neighbours = new List<Vector2Int>();
        int maxX = SpawnedRooms.GetLength(0) - 1;
        int maxY = SpawnedRooms.GetLength(1) - 1;

        if (position.x > 0 && SpawnedRooms[position.x - 1, position.y] != null) neighbours.Add(Vector2Int.left);
        if (position.y > 0 && SpawnedRooms[position.x, position.y - 1] != null) neighbours.Add(Vector2Int.down);
        if (position.x < maxX && SpawnedRooms[position.x + 1, position.y] != null) neighbours.Add(Vector2Int.right);
        if (position.y < maxY && SpawnedRooms[position.x, position.y + 1] != null) neighbours.Add(Vector2Int.up);

        if (neighbours.Count == 0)
        {
            Debug.LogWarning("Cant connect");
            return false;

        }

        Vector2Int selectedDirection = neighbours[Random.Range(0, neighbours.Count)];
        Room selectedRoom = SpawnedRooms[position.x + selectedDirection.x, position.y + selectedDirection.y];




        if (selectedDirection == Vector2Int.up)
        {
            room.DoorPlaceN.gameObject.SetActive(false);
            selectedRoom.DoorPlaceS.gameObject.SetActive(false);
        }

        if (selectedDirection == Vector2Int.right)
        {
            room.DoorPlaceE.gameObject.SetActive(false);
            selectedRoom.DoorPlaceW.gameObject.SetActive(false);
        }

        if (selectedDirection == Vector2Int.down)
        {
            room.DoorPlaceS.gameObject.SetActive(false);
            selectedRoom.DoorPlaceN.gameObject.SetActive(false);
        }

        if (selectedDirection == Vector2Int.left)
        {
            room.DoorPlaceW.gameObject.SetActive(false);
            selectedRoom.DoorPlaceE.gameObject.SetActive(false);
        }

        return true;

    }
}
