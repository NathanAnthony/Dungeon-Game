using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject door;
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] closers;
    public GameObject[] endCaps;
    public List<GameObject> roomsList;
    public List<Vector2Int> spawnGrid;
}
