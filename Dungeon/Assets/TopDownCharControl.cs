using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private ImputHandler input;
    [SerializeField] private float moveSpeed;
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
       input = GetComponent<ImputHandler>();
      // controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame 
    
    void Update()
    {
        var targetVector = new Vector3(input.InputVector.x, 0, input.InputVector.y);

        // move in dir we are aiming
       // MoveTowardTarget(targetVector);

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

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
    }
    
    private void MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
        // ADD A SPEED MODIFIER AT THE END
        transform.Translate(targetVector * speed);
    }
    
}
