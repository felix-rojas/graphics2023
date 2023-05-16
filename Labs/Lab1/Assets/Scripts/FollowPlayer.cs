using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // generate player object to follow
    public GameObject player;
    // give offset to camera
    private Vector3 offset = new Vector3(0,6,-7);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called once per frame right after Update is called
    // this is to avoid camera jittering
    void LateUpdate()
    {
        // transform the position of the camera to follow player object
        // plus an offset
        transform.position = player.transform.position + offset;
    }
}
