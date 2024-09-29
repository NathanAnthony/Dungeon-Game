using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharControl : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    private ImputHandler input;

    // All player data
    public PlayerData data;

    public float moveSpeed = 0f;


    public GameObject character;
   // private CharacterController controller;

    //private Vector2 movement;
    //private Vector2 aim;

    //private Vector3 playerVelocity;

    public Camera playerCam;

    private Ray camRay;
    private Plane groundPlane;
    private float rayLength;
    private Vector3 pointToLook;

    void Start()
    {
       moveSpeed = data.getSpeed();
       input = GetComponent<ImputHandler>();
       m_Rigidbody = GetComponent<Rigidbody>();
        // controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame 

    private void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);
    }


    void Update()
    {
        var targetVector = new Vector3(input.InputVector.x, 0, input.InputVector.y);

        // Mouse rotation
        //Sending a raycast
        camRay = playerCam.ScreenPointToRay(Input.mousePosition);

        //Setting groundPlane
        groundPlane = new Plane(Vector3.up, Vector3.zero);

        //Checking if the ray hit something
        if (groundPlane.Raycast(camRay, out rayLength))
        {
            pointToLook = camRay.GetPoint(rayLength);
        }

        //Rotating the player
        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
    }

    public void UpdateStats()
    {
        moveSpeed = data.getSpeed();
    }
}
