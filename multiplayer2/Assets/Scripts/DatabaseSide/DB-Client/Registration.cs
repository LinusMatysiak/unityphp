using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
public class Registration : MonoBehaviour
{

    [SerializeField] private TMP_InputField NameInput;
    [SerializeField] private TMP_InputField PassInput;
    [SerializeField] private TMP_InputField EmailInput;

    [SerializeField] private TMP_Text Prompt;

    public void CallRegister() {
        StartCoroutine(Register());
    }
    public IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", NameInput.text);
        form.AddField("loginPass", PassInput.text);
        form.AddField("loginEmail", EmailInput.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/multiplayer2/register.php", form))
        {
            yield return www.SendWebRequest();
            if (www.downloadHandler.text == "0") {
                Debug.Log("User created successfully.");
                Prompt.color = Color.green; Prompt.text = "account created";

            }
            else {
                Debug.Log("Error: " + www.downloadHandler.text);
                Prompt.color = Color.red; Prompt.text = "Error: " + www.downloadHandler.text;
            }
        }
    }
}