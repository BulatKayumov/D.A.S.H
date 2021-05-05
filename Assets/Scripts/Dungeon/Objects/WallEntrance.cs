using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DASH._Dungeon
{
    public class WallEntrance : MonoBehaviour
    {
        [HideInInspector]
        public Vector2 cords;
        [HideInInspector]
        public Orientation orientation;
        public Room entryRoom;

        public void SetPosition(Vector2 cords, Orientation orientation)
        {
            this.orientation = orientation;
            this.cords = cords + OrientationCords(this.orientation);
            gameObject.transform.position = new Vector3(this.cords.x - Generator.instance.maxMapSize / 2, 0, this.cords.y - Generator.instance.maxMapSize / 2) * Generator.instance.tileSize;
            switch (orientation)
            {
                case Orientation.North:
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case Orientation.East:
                    gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                    break;
                case Orientation.South:
                    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case Orientation.West:
                    gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
                    break;
            }
        }

        private Vector2 OrientationCords(Orientation orientation)
        {
            Vector2 orientationCords = new Vector2();
            switch (orientation)
            {
                case Orientation.North:
                    orientationCords = Vector2.up / 2f;
                    break;
                case Orientation.East:
                    orientationCords = Vector2.right / 2f;
                    break;
                case Orientation.South:
                    orientationCords = Vector2.down / 2f;
                    break;
                case Orientation.West:
                    orientationCords = Vector2.left / 2f;
                    break;
            }
            return orientationCords;
        }
    }
}