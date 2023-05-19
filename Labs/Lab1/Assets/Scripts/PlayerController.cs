using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This player controller class will update the events from the vehicle player.
/// Standar coding documentarion can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>



public class PlayerController : MonoBehaviour
{
    /// Movement vars for players
    public float speed = 5.0f;
    public float turnSpeed = 0.0f;
    public float horizontalInput;
    public float forwardInput;
    
    /// Multiplayer Vars
    public string inputId;

    /// <summary>
    /// Global vars for camera controls for <c>PlayerController</c>
    public Camera mainCamera;
    public Camera hoodCamera;
    /// InputKey for PLayer to switch camera
    public KeyCode switchKey; 
    /// </summary>

    /// <summary>
    /// This method is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }
    /// <summary>
    /// This method is called once per frame to check for user inputs and rotate the object
    /// </summary>
    void Update()
    {
        /// Get user input to turn
        horizontalInput = Input.GetAxis("Horizontal" + inputId);
        /// Get user input to move
        forwardInput = Input.GetAxis("Vertical" + inputId);

        /// translate to fwd and bwd movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        /// translate vector using rotation on the whole object
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        /// Camera Switch when <param>switchkey</param> is pressed
        if(Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}