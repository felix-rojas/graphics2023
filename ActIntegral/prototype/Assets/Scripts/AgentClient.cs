// TC2008B Modelación de Sistemas Multiagentes con gráficas computacionales
// C# client to interact with Python server via POST
// Sergio Ruiz-Loza, Ph.D. March 2021

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class AgentClient : MonoBehaviour
{
    Vector3 agentPosition;
    public void GetAgentData() {
        Agent a = AgentAPIHelper.GetData();
        agentPosition = new Vector3(a.x, 
                                    a.y,
                                    a.z);
    }


    // Start is called before the first frame update
    void Start()
    {
        transform.position = agentPosition;
    }

    // Update is called once per frame
    void Update()
    {
    }
}