using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Player;

namespace DASH._Dungeon
{
    public class RoomEnterTrigger : MonoBehaviour
    {
        private Room room;

        private void Start()
        {
            room = GetComponentInParent<Room>();
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                room.EnterTrigger();
            }
        }
    }
}