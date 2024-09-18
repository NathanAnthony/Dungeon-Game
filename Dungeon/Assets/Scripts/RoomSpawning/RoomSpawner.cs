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
            }
            else if (openingDirection == 2)
            {
                //Spawn room with TOP door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //Spawn room with LEFT door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //Spawn room with RIGHT door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
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
                }

                // Creates closing room TR
                if((openingDirection == 2 && other.GetComponent<RoomSpawner>().openingDirection == 4) || openingDirection == 4 && other.GetComponent<RoomSpawner>().openingDirection == 2) {
                    Instantiate(templates.closers[1], transform.position, templates.closers[1].transform.rotation);
                }

                // Creates closing room LB
                if((openingDirection == 1 && other.GetComponent<RoomSpawner>().openingDirection == 3) || openingDirection == 3 && other.GetComponent<RoomSpawner>().openingDirection == 1) {
                    Instantiate(templates.closers[2], transform.position, templates.closers[2].transform.rotation);
                }

                // Creates closing room RB
                if((openingDirection == 1 && other.GetComponent<RoomSpawner>().openingDirection == 4) || openingDirection == 4 && other.GetComponent<RoomSpawner>().openingDirection == 1) {
                    Instantiate(templates.closers[3], transform.position, templates.closers[3].transform.rotation);
                }

            }
            spawned = true;
        }
    }
}
