using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> needs BOTTOM door
    // 2 --> needs TOP door
    // 3 --> needs LEFT door
    // 4 --> needs RIGHT 

    // T >>> L >>> R >>> B

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    public float waitTime = 5f;

    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", .1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                //Spawn room with BOTTOM door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                
                SpawnDoor(openingDirection);
            }
            else if (openingDirection == 2)
            {
                //Spawn room with TOP door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);

                SpawnDoor(openingDirection);
            }
            else if (openingDirection == 3)
            {
                //Spawn room with LEFT door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);

                SpawnDoor(openingDirection);
            }
            else if (openingDirection == 4)
            {
                //Spawn room with RIGHT door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);

                SpawnDoor(openingDirection);
            }
            spawned = true;
        }

    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("SpawnPoint")) {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
                // Spawn wall blocking off any opening
                Debug.Log("Close this loop!");

                // Creates closing room TL
                if((openingDirection == 2 && other.GetComponent<RoomSpawner>().openingDirection == 3) || openingDirection == 3 && other.GetComponent<RoomSpawner>().openingDirection == 2) {
                    Instantiate(templates.closers[0], transform.position, templates.closers[0].transform.rotation);

                    SpawnDoor(2);
                    SpawnDoor(3);
                }

                // Creates closing room TR
                if((openingDirection == 2 && other.GetComponent<RoomSpawner>().openingDirection == 4) || openingDirection == 4 && other.GetComponent<RoomSpawner>().openingDirection == 2) {
                    Instantiate(templates.closers[1], transform.position, templates.closers[1].transform.rotation);

                    SpawnDoor(2);
                    SpawnDoor(4);
                }

                // Creates closing room LB
                if((openingDirection == 1 && other.GetComponent<RoomSpawner>().openingDirection == 3) || openingDirection == 3 && other.GetComponent<RoomSpawner>().openingDirection == 1) {
                    Instantiate(templates.closers[2], transform.position, templates.closers[2].transform.rotation);

                    SpawnDoor(1);
                    SpawnDoor(3);
                }

                // Creates closing room RB
                if((openingDirection == 1 && other.GetComponent<RoomSpawner>().openingDirection == 4) || openingDirection == 4 && other.GetComponent<RoomSpawner>().openingDirection == 1) {
                    Instantiate(templates.closers[3], transform.position, templates.closers[3].transform.rotation);

                    SpawnDoor(1);
                    SpawnDoor(4);
                }

            }
            spawned = true;
        }
    }

    void SpawnDoor(int direction) {
        GameObject newDoor;
        Vector3 doorOffset;
        switch(direction) {
            case 1:
                //Spawns door
                doorOffset = new Vector3(transform.position.x, 0f, transform.position.z + -10f);
                newDoor = Instantiate(templates.door, doorOffset, Quaternion.identity);
                newDoor.transform.Rotate(0f, -180f, 0f);
                break;
            case 2:
                //Spawns door
                doorOffset = new Vector3(transform.position.x, 0f, transform.position.z + 10f);
                newDoor = Instantiate(templates.door, doorOffset, Quaternion.identity);
                newDoor.transform.Rotate(0f, 0f, 0f);
                break;
            case 3:
                //Spawn door
                doorOffset = new Vector3(transform.position.x + -10f, 0f, transform.position.z);
                newDoor = Instantiate(templates.door, doorOffset, Quaternion.identity);
                newDoor.transform.Rotate(0f, -90f, 0f);
                break;
            case 4:
                //Spawn door
                doorOffset = new Vector3(transform.position.x + 10f, 0f, transform.position.z);
                newDoor = Instantiate(templates.door, doorOffset, Quaternion.identity);
                newDoor.transform.Rotate(0f, 90f, 0f);
                break;
        }
    }
}
