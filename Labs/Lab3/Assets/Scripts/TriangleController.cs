using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    public void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    private void TimeCheck()
    {
        if(TimeManager.Minute % 10 == 0)
        {
            StartCoroutine(MoveTriangle());
        }
    }
    private IEnumerator MoveTriangle()
    {
        transform.position = new Vector3(-100f,-49f,0);
        Vector3 targetPos = new Vector3(700f,-49f,0);
        Vector3 currentPos = transform.position;
    
        float timeElapsed = 0;
        float timeToMove = 3;
    
        while(timeElapsed < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos,targetPos,timeElapsed/timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    }
}

