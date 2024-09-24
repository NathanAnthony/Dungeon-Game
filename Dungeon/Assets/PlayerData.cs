using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public myData data = new myData();

    public void SaveToJson()
    {
        string playerStats = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + "/playerStats.json";
        System.IO.File.WriteAllText(filePath, playerStats);
        Debug.Log("Save successful");
    }

    public void LoadFromJason()
    {
        string filePath = Application.persistentDataPath + "/playerStats.json";
        string playerStats = System.IO.File.ReadAllText(filePath);

        data = JsonUtility.FromJson<myData>(playerStats);
        Debug.Log("Load Successful");
    }
    public void setSpeed(float newSpeed)
    {
        data.speed += newSpeed;
    }
    public float getSpeed()
    {
        return data.speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            SaveToJson();
        }
    }

    [System.Serializable] 
    public class myData
    {
        public float speed = 0;


    }
}
