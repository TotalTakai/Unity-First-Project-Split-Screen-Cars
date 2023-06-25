using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVan : MonoBehaviour
{
    //variables
    private const float speed = 12.0f;


    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
