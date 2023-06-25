using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private const float speed = 20.0f;
    private const float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get User movment inputs
        if (gameObject.CompareTag("Player1"))
        {
            horizontalInput = Input.GetAxis("Horizontal1");
            forwardInput = Input.GetAxis("Vertical1");
        }
        else if (gameObject.CompareTag("Player2"))
        {
            horizontalInput = Input.GetAxis("Horizontal2");
            forwardInput = Input.GetAxis("Vertical2");
        }

        //Control the vehicle
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
