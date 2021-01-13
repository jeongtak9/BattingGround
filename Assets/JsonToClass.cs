using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security;
using UnityEngine;

[Serializable]
public class Data
{
    public int id;
    public string color;
    public string pantone_value;
    public int year;
    public string name;
    public void Print()
    {
        Debug.Log($"data : id = {id} / name = {name} / year = {year} / color = {color} / pantone_value = {pantone_value}");
    }
}
[Serializable]
public class Ad
{
    public string company;
    public string url;
    public string text;
    public void Print()
    {
       Debug.Log($"ad : company = {company} / url = {url} / text = {text}");
    }
}
[Serializable]
public class Response
{
    public Data data;
    public Ad support;
    public void Print()
    {
        data.Print();
        support.Print();
    }
}
public class JsonToClass : MonoBehaviour
{
    T JsonToObject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData);
    }
    void Start()
    {
        WebClient client = new WebClient();
        var jsonString = client.DownloadString("https://reqres.in/api/products/3");
        Debug.Log(jsonString);
        var jsonData = JsonToObject<Response>(jsonString);
        jsonData.Print();
    }
}



