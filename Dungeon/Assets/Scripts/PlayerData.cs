using System;
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

    // Stats getters and setters
    public void setHp(float newHp)
    {
        data.hp += newHp;
    }
    public float getHp()
    {
        return data.hp;
    }
    public void setSpeed(float newSpeed)
    {
        data.speed += newSpeed;
    }
    public float getSpeed()
    {
        return data.speed;
    }
    public void setAtk(float newAtk)
    {
        data.atk += newAtk;
    }
    public float getAtk()
    {
        return data.atk;
    }
    public void setDef(float newDef)
    {
        data.def += newDef;
    }
    public float getDef()
    {
        return data.def;
    }
    public void setMp(float newMp)
    {
        data.mp += newMp;
    }
    public float getMp()
    {
        return data.mp;
    }
    public void setGold(int newGold)
    {
        data.gold += newGold;
    }
    public int getGold()
    {
        return data.gold;
    }
    public void setExp(int newExp)
    {
        data.exp += newExp;
    }
    public int getExp()
    {
        return data.exp;
    }
    public void levelUp()
    {
        data.level += 1;
    }
    public int getLevel()
    {
        return data.level;
    }
    public bool addSpell(int spellNum)
    {
        if (!data.spells.Contains(spellNum))
        {
            data.spells.Add(spellNum);
            return true;
        }
        return false;
    }
    public List<int> getSpells()
    {
        return data.spells;
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
        public float hp = 0;
        public float speed = 0;
        public float atk = 0;
        public float def = 0;
        public float mp = 0;
        public int gold = 0;
        public int level = 0;
        public int exp = 0;
        public List<int> spells;
        //public List<String> spells = new List<String>();
    }
}
