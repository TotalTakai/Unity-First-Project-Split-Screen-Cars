using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //variabls
    public GameObject player;
    private Vector3 thirdPersonOffSet = new Vector3(0, 4, -7);
    private Vector3 firstPersonOffSet = new Vector3(0, 2, 1);
    private Vector3 offset = new Vector3(0, 4, -7);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdatePosition();
        transform.position = player.transform.position + offset;
    }
    public void UpdatePosition()
    {
        //changes the view from first to third person according to player pressing P
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (offset.Equals(thirdPersonOffSet))
            {
                offset = firstPersonOffSet;
            }
            else
            {
                offset = thirdPersonOffSet;
            }
            transform.position = player.transform.position + offset;
        }
    }
}
