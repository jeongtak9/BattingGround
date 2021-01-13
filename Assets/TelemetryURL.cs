using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security;
using UnityEngine;

/*
 * 컴퓨터가 하는 3가지
 * 1. 입력
 * 2. 계산
 * 3. 출력
 */

/*
 * 모든 함수는
 * 1. 입력
 * 2. 계산
 * 3. 출력
 */

[Serializable]
public class MatchDataAttributes
{
    public string URL;
    public string createdAt;
    public string description;
    public string name;
}

[Serializable]
public class MatchDataObject
{
    public string type;
    public MatchDataAttributes attributes;
}

[Serializable]
public class MatchInfo
{
    public MatchDataObject[] included;
}
public class TelemetryURL : MonoBehaviour
{
    T JsonToObject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData);
    }
    void Start()
    {

        WebClient client = new WebClient();
        client.Headers["Accept"] = "application/vnd.api+json";
        var jsonString = client.DownloadString("https://api.pubg.com/shards/steam/matches/26f450fc-4d1b-491e-85e0-1a9367f7523d");
        Debug.Log(jsonString);

        var indexOfUrl = jsonString.IndexOf("URL");
        Debug.Log(indexOfUrl);
        Debug.Log(jsonString.Substring(indexOfUrl - 10, 300));
        var jsonData = JsonToObject<MatchInfo>(jsonString);
        // jsonData.Print();
        var assetObject = Array.Find(jsonData.included, (x => x.type == "asset"));
        if (assetObject == null)
        {
            Debug.Log("못찾겠다 꾀꼬리");
            return;
        }
        Debug.Log(assetObject.attributes.URL);


        // 유저들의 (위치 정보 + 시간)를 저장하는 것
        // 누가, 언제, 어디였는지 < 1차 스펙
        // 누구와 누가 팀인지 < 2차 스펙
        // 누가 무슨 아이템을 언제 장착했는지 < 3차 스펙
        // 차량 정보 < 4차 스펙
    }
}
