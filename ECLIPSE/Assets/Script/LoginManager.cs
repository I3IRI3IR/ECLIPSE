using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using TMPro;

public class LoginManager : MonoBehaviour
{
    string targeturl_prefix = "http://127.0.0.1:8000/";
    public TMP_InputField input_userid; 
    public TMP_InputField input_password;
    string userid;
    string password;

    public GameObject SignUI;
    public GameObject LobbyUI;

    void Start()
    {
        
        userid = string.Empty;
        password = string.Empty;
    }

    public void Sign_in_Onclick()
    {
        userid = input_userid.text;
        password = input_password.text;

        StartCoroutine(Send_Sign_in_Request());
        Debug.Log("Sign-in request started");
    }

    public IEnumerator Send_Sign_in_Request()
    {
        Debug.Log("Preparing sign-in request...");
        string targetUrl = targeturl_prefix + "sign_in";

        
        string jsonData = $"{{\"user_name\": \"{userid}\", \"password\": \"{password}\"}}";

        UnityWebRequest request = new UnityWebRequest(targetUrl, "POST");

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("Sending sign-in request...");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + request.downloadHandler.text);
            SignUI.SetActive(false);
            LobbyUI.SetActive(true);
            StartCoroutine(Send_Get_Room_Request());
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }

    public void Sign_up_Onclick()
    {
        
        userid = input_userid.text;
        password = input_password.text;

        StartCoroutine(Send_Sign_up_Request());
        Debug.Log("Sign-up request started");
    }

    public IEnumerator Send_Sign_up_Request()
    {
        Debug.Log("Preparing sign-up request...");
        string targetUrl = targeturl_prefix + "sign_up";

        
        string jsonData = $"{{\"user_name\": \"{userid}\", \"password\": \"{password}\"}}";

        UnityWebRequest request = new UnityWebRequest(targetUrl, "POST");

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("Sending sign-up request...");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }

    public IEnumerator Send_Get_Room_Request()
    {
        Debug.Log("Preparing sign-in request...");
        string targetUrl = targeturl_prefix + "get_room_list/" + userid;

        UnityWebRequest request = UnityWebRequest.Get(targetUrl);

        yield return request.SendWebRequest();

        //沒做完

    }
}
