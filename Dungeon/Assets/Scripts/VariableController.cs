using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class VariableController : MonoBehaviour
{
    public PlayerData data;
    public TopDownCharControl controls;

    public TextMeshProUGUI speedText;
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;

    // Start is called before the first frame update
    void Start()
    {
        data.LoadFromJason();
        speedText.text = "Speed: " + data.getSpeed();
        UpdateSpeed(0);
        UpdateHealth(0);
        UpdateAttack(0);
        UpdateDefence(0);
        UpdateMagic(0);
    }

    // Basic Stats
    private void UpdateSpeed(int scoreToAdd)
    {
        data.setSpeed(scoreToAdd);
        speedText.text = "Speed: " + data.getSpeed();
        controls.UpdateStats();
    }

    private void UpdateAttack(int scoreToAdd)
    {
        data.setAtk(scoreToAdd);
        atkText.text = "Attack: " + data.getAtk();
        controls.UpdateStats();
    }
    private void UpdateHealth(int scoreToAdd)
    {
        data.setHp(scoreToAdd);
        hpText.text = "Health: " + data.getHp();
        controls.UpdateStats();
    }
    private void UpdateDefence(int scoreToAdd)
    {
        data.setDef(scoreToAdd);
        defText.text = "Defence: " + data.getDef();
        controls.UpdateStats();
    }
    private void UpdateMagic(int scoreToAdd)
    {
        data.setMp(scoreToAdd);
        mpText.text = "Magic: " + data.getMp();
        controls.UpdateStats();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpdateSpeed(1);
        }   
    }
}
