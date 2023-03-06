using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    IEnumerator Start() {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost/multiplayer2/echo.php");
        yield return request.SendWebRequest();

        string[] webResults = request.downloadHandler.text.Split('\t');
        foreach (string splitted in webResults) { // for each split \t, debug.log splitted info
            //Debug.Log(splitted);
        }
        Debug.Log("converted vars");
        Debug.Log(webResults[0]);
        int webNumber = int.Parse(webResults[1]);
        Debug.Log(webNumber);
    }
}
