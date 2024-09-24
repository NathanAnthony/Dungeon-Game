using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class VariableController : MonoBehaviour
{
    public PlayerData data;
    public TextMeshProUGUI speedText;
    public float otherNum;
    public TextMeshProUGUI otherText;
    // Start is called before the first frame update
    void Start()
    {
        data.LoadFromJason();
        speedText.text = "Speed: " + data.getSpeed();
        UpdateScore(0);
    }

    private void UpdateScore(int scoreToAdd)
    {
        data.setSpeed(scoreToAdd);
        speedText.text = "Speed: " + data.getSpeed();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpdateScore(5);
        }   
    }
}
