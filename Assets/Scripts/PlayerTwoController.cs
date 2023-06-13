using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    // Variables
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get User movment inputs
        horizontalInput = Input.GetAxis("Horizontal2");
        forwardInput = Input.GetAxis("Vertical2");

        //Control the vehicle
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
