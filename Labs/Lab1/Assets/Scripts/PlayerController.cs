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
    public float timer = 0.1f;
    public float turnSpeed = 0.0f;
    public float horizontalInput;
    public float forwardInput;

    public int playerPoints = 0;
    public bool GameOver = false;

    /// Multiplayer Vars
    public string inputId;

    /// <summary>
    /// Global vars for camera controls for <c>PlayerController</c>
    public Camera mainCamera;
    public Camera hoodCamera;
    /// InputKey for Player to switch camera
    public KeyCode switchKey; 
    /// </summary>
    
    /// generate a waypoint to follow player
    public GameObject wayPoint;

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

        /// Translate to fwd and bwd movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        /// Translate vector using rotation on the whole object
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        /// Camera Switch <param name="switchKey">switchKey is the defined camera</param> is pressed
        if(Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }

        if(timer > 0)
        {
             timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
             //The position of the waypoint will update to the player's position
             UpdatePosition();
             timer = 0.1f;
        }

        if (transform.position[0] >= 50 && !GameOver){
            Debug.Log("You win with score: " + playerPoints);
        }
    }
        /// <summary>
        /// This method is called on every update to follow the player every <c>timer</c> seconds
        /// </summary>
        void UpdatePosition()
    {
        //The wayPoint's position will now be the player's current position.
         wayPoint.transform.position = transform.position;
    }


    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.transform.name.StartsWith("Road") && transform.position[2] <= -10)
        {
            GameOver = true;
            Debug.Log("GameOver, fell off");
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.transform.name.StartsWith ("Obstaculo"))
        {
            playerPoints += 1 ;
            Debug.Log("Extra points, crashed with: " + collisionInfo.transform.name);
        }

        if (collisionInfo.transform.name.StartsWith ("Veh_Bus_Blue"))
        {
            GameOver = true;
            Debug.Log("GameOver, crashed with: " + collisionInfo.transform.name);
        }
    }
}