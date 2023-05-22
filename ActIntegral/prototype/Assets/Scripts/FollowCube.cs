using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCube : MonoBehaviour
{
    // generate cube object to follow
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Method <c>LateUpdate</c> is called right after Update is called to avoid camera jittering
    /// </summary>
    void LateUpdate()
    {
        // transform the position of the camera to follow cube object
        transform.position = cube.transform.position;
    }
}