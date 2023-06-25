using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Variables
    [SerializeField] private float horsePower = 0;
    private const float turnSpeed = 45.0f;
    private const float topSpeed = 100f;
    private float speed;
    private float rpm;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRB;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] TextMeshProUGUI speedometer;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] GameObject centerOfMass;


    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.centerOfMass = centerOfMass.transform.localPosition;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Get User movment inputs
        if (gameObject.CompareTag("Player1"))
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
        }
        else if (gameObject.CompareTag("Player2"))
        {
            horizontalInput = Input.GetAxis("Horizontal2");
            forwardInput = Input.GetAxis("Vertical2");
        }
        if (isGrounded())
        {
            //Control the vehicle
            // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRB.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            if(playerRB.velocity.magnitude * 3.6 > topSpeed)
            {
                playerRB.velocity = playerRB.velocity.normalized * (topSpeed/3.6f);
            }
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
            speed = Mathf.RoundToInt(playerRB.velocity.magnitude * 3.6f); // 3.6f turns meters/ per hour to kilometers/ per hour
            speedometer.SetText("Speed: " + speed + " kph");
            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }
    }

    private bool isGrounded()
    {
        int wheelOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded) wheelOnGround++;
        }
        if (wheelOnGround == 4) return true;
        else return false;
    }
}
