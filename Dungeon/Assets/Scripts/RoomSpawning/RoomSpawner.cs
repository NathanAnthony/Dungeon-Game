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
    private Vector2Int tModifer = new Vector2Int(0, 1);
    private Vector2Int bModifer = new Vector2Int(0, -1);
    private Vector2Int lModifer = new Vector2Int(-1, 0);
    private Vector2Int rModifer = new Vector2Int(1, 0);

    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                //Spawn room with BOTTOM door
                rand = Random.Range(0, templates.bottomRooms.Length);
                GameObject myRoom = templates.bottomRooms[rand];
                foreach(char dir in myRoom.GetComponent<AddRoom>().roomIdentity) {
                    if(dir == 'B') {
                        //Ignore, room spawned from here
                    } else if(dir == 'T') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + tModifer + tModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[0];
                        }
                    } else if(dir == 'L') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + lModifer + tModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[0];
                        }
                    } else if(dir == 'R') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + rModifer + tModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[0];
                        }
                    }
                }

                Instantiate(myRoom, transform.position, myRoom.transform.rotation);

                //Detect which Identity the room is spawning from using openingDirection
                //Loop through all identities in the room to be spawned and check using the grid if there is any conflicts
                //If not, spawn room
                //Otherwise, abort and spawn end cap
                
                SpawnDoor(openingDirection);
            }
            else if (openingDirection == 2)
            {
                //Spawn room with TOP door
                rand = Random.Range(0, templates.topRooms.Length);
                GameObject myRoom = templates.topRooms[rand];
                foreach(char dir in myRoom.GetComponent<AddRoom>().roomIdentity) {
                    if(dir == 'B') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + bModifer + bModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[1];
                        }
                    } else if(dir == 'T') {
                        //Ignore, room spawned from here
                    } else if(dir == 'L') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + lModifer + bModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[1];
                        }
                    } else if(dir == 'R') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + rModifer + bModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[1];
                        }
                    }
                }

                Instantiate(myRoom, transform.position, myRoom.transform.rotation);

                SpawnDoor(openingDirection);
            }
            else if (openingDirection == 3)
            {
                //Spawn room with LEFT door
                rand = Random.Range(0, templates.leftRooms.Length);
                GameObject myRoom = templates.leftRooms[rand];
                foreach(char dir in myRoom.GetComponent<AddRoom>().roomIdentity) {
                    if(dir == 'B') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + bModifer + rModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[2];
                        }
                    } else if(dir == 'T') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + tModifer + rModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[2];
                        }
                    } else if(dir == 'L') {
                        //Ignore, room spawned from here
                    } else if(dir == 'R') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + rModifer + rModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[2];
                        }
                    }
                }

                Instantiate(myRoom, transform.position, myRoom.transform.rotation);

                SpawnDoor(openingDirection);
            }
            else if (openingDirection == 4)
            {
                //Spawn room with RIGHT door
                rand = Random.Range(0, templates.rightRooms.Length);
                GameObject myRoom = templates.rightRooms[rand];
                foreach(char dir in myRoom.GetComponent<AddRoom>().roomIdentity) {
                    if(dir == 'B') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + bModifer + lModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[3];
                        }
                    } else if(dir == 'T') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + tModifer + lModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[3];
                        }
                    } else if(dir == 'L') {
                        if(templates.spawnGrid.Contains(this.GetComponentInParent<AddRoom>().roomPos + lModifer + lModifer)) {
                            Debug.Log("WE SPAWNED INTO A WALL");
                            myRoom = templates.endCaps[3];
                        }
                    } else if(dir == 'R') {
                        //Ignore, room spawned from here
                    }
                }

                Instantiate(myRoom, transform.position, myRoom.transform.rotation);
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
