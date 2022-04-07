using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform checker;

    public Vector3 fallVelocity;
    public LayerMask groundMask;

    [SerializeField] private float velocity = 10.0f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private bool ground;

    private void Update()
    {
        //Get the values of the input
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //Movement
        Vector3 movement = transform.right * x + transform.forward * y;
        characterController.Move(movement * velocity * Time.deltaTime);

        //Gravity
        fallVelocity.y += gravity * Time.deltaTime;
        characterController.Move(fallVelocity * Time.deltaTime);

        //Check if the player is touching the ground
        ground = Physics.CheckSphere(checker.position, groundDistance, groundMask);

        //If is touching the ground, assign the fall velocity in y axis to 0
        if (ground && fallVelocity.y < 0) fallVelocity.y = 0;

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && ground) fallVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
    }
}
