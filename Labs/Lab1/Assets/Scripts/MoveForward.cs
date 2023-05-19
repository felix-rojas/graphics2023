using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// The method <c>Update</c> moves the object forward
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
