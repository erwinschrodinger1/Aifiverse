using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEditor;

public class LoadObj : MonoBehaviour
{

    readonly string postReqUrl = "http://65.2.80.113:3000/models/list";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("objListRequest");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator objListRequest()
    {
        Debug.Log("Started Courotine");
        UnityWebRequest request = UnityWebRequest.Get(postReqUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.downloadHandler.text);
        }
        else
        {
            Debug.Log("Data recieved");
            Debug.Log(request.downloadHandler.text);
            var data = JsonConvert.DeserializeObject<DataObjClass>(request.downloadHandler.text);
            Debug.Log(data.status);
            foreach (LocationUrls location in data.locations)
            {
                Debug.Log(location.url);
            }

        }
    }
    // IEnumerator objRequest(string url)
    // {
    //     UnityWebRequest request = UnityWebRequest.Get(url);
    //     yield return request.SendWebRequest();
    //     if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
    //     {
    //         Debug.Log(request.downloadHandler.text);
    //     }
    //     else
    //     {
    //         Debug.Log(request.downloadHandler.text);
    //     }
    // }
}

public class DataObjClass
{
    public string status;
    public List<LocationUrls> locations;
}
public class LocationUrls
{
    public string url;
    public string location;
}
