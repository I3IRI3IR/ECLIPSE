using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class networktest : MonoBehaviour
{
    // 目標 URL
    string targeturl_prefix = "http://127.0.0.1:8000/";

    public void Sign_in_Onclick()
    {
        StartCoroutine(Send_Sign_in_Request());
        Debug.Log("test1");
    }

    public IEnumerator Send_Sign_in_Request()
    {
        Debug.Log("test2");
        string targetUrl=targeturl_prefix+"sign_in";
        
        string jsonData = "{\"user_name\": \"bir\", \"password\": \"12345\"}";

        // 建立 UnityWebRequest，設置為 POST
        UnityWebRequest request = new UnityWebRequest(targetUrl, "POST");
        
        // 設置請求的內容類型和資料
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("test3");

        // 發送請求並等待回應
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // 請求成功，處理響應
            Debug.Log("Response: " + request.downloadHandler.text);
        }
        else
        {
            // 請求失敗，顯示錯誤
            Debug.LogError("Error: " + request.error);
        }
        Debug.Log("test4");
    }


    public void Sign_up_Onclick()
    {
        StartCoroutine(Send_Sign_up_Request());
        Debug.Log("test5");
    }

    public IEnumerator Send_Sign_up_Request()
    {
        Debug.Log("test6");

        string targetUrl=targeturl_prefix+"sign_up";
        string jsonData = "{\"user_name\": \"sakinu\", \"password\": \"23456\"}";

        
        UnityWebRequest request = new UnityWebRequest(targetUrl, "POST");
        
        // 設置請求的內容類型和資料
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("test7");

        // 發送請求並等待回應
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // 請求成功，處理響應
            Debug.Log("Response: " + request.downloadHandler.text);
        }
        else
        {
            // 請求失敗，顯示錯誤
            Debug.LogError("Error: " + request.error);
        }
        Debug.Log("test8");
    }


}
