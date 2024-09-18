using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;
    public Vector2Int roomPos;
    public string roomIdentity;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.roomsList.Add(this.gameObject);
        templates.spawnGrid.Add(new Vector2Int((int)(this.gameObject.transform.position.x / 20f), (int)(this.gameObject.transform.position.z / 20f)));
        roomPos = new Vector2Int((int)(this.gameObject.transform.position.x / 20f), (int)(this.gameObject.transform.position.z / 20f));
    }
}
