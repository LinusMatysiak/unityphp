using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField NameInput;
    [SerializeField] private TMP_InputField PassInput;

    [SerializeField] private TMP_Text Prompt;
    public void CallLogin()
    {
        StartCoroutine(LoginFunction());
    }
    public IEnumerator LoginFunction()
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", NameInput.text);
        form.AddField("loginPass", PassInput.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/multiplayer2/login.php", form))
        {
            yield return www.SendWebRequest(); 
            if (www.downloadHandler.text[0] == '0')
            {
                DBManager.username = NameInput.text;
                DBManager.currency = int.Parse(www.downloadHandler.text.Split('\t')[1]);
                Debug.Log("Log in = " + DBManager.loggedin + " " + DBManager.username);
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
            else
            {
                Debug.Log("Error: " + www.downloadHandler.text);
                Prompt.color = Color.red; Prompt.text = "Error: " + www.downloadHandler.text;
            }
        }
    }
}
