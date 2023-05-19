using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>FollowPlayer</c> models the camera behaviour to follow the player
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    // generate player object to follow
    public GameObject player;
    /// <summary> 
    /// Give an offset to the camera
    /// </summary>
    private Vector3 offset = new Vector3(0,6,-7);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Method <c>LateUpdate</c> is called right after Update is called to avoid camera jittering
    /// </summary>
    void LateUpdate()
    {
        // transform the position of the camera to follow player object
        // plus an offset
        transform.position = player.transform.position + offset;
    }
}