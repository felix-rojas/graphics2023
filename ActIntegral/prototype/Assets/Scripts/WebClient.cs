// TC2008B Modelación de Sistemas Multiagentes con gráficas computacionales
// C# client to interact with Python server via POST
// Sergio Ruiz-Loza, Ph.D. March 2021

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class WebClient : MonoBehaviour
{
    /// Movement vars for players
    Vector3 currentPos;
    public float speed = 5.0f;
    public float turnSpeed = 0.0f;
    public float horizontalInput;
    public float forwardInput;
    // IEnumerator - yield return
    IEnumerator SendData(string data)
    {
        WWWForm form = new WWWForm();
        form.AddField("bundle", "the data");
        string url = "http://localhost:8585";
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(data);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            //www.SetRequestHeader("Content-Type", "text/html");
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();          // Talk to Python
            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);    // Answer from Python
                Vector3 tPos = JsonUtility.FromJson<Vector3>(www.downloadHandler.text.Replace('\'', '\"'));
                //Debug.Log("Form upload complete!");
                Debug.Log(tPos);
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        currentPos = new Vector3(1.0f, 1.0f, 1.0f);
        //StartCoroutine(SendData(call));
        // transform.localPosition
    }

    // Update is called once per frame
    void Update()
    {
        /// Translate to fwd and bwd movement
        string json = EditorJsonUtility.ToJson(currentPos);
        StartCoroutine(SendData(json));
        transform.position = Vector3.MoveTowards(transform.position,);
    }
}