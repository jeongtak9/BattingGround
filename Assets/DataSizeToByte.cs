using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security;
using UnityEngine;


public class DataSizeToByte : MonoBehaviour
{
    void Start()
    {
        WebClient client = new WebClient();
        var bytes = client.DownloadData("https://reqres.in/api/products/3");

        UnityEngine.Debug.Log(bytes.Length);

        var jsonString = client.DownloadString("https://reqres.in/api/products/3");
        UnityEngine.Debug.Log(jsonString);



    }

}
