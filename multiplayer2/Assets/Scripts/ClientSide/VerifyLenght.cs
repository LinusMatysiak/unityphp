using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VerifyLenght : MonoBehaviour
{
    [SerializeField] private Button Login;
    [SerializeField] private Button Submit;
    [SerializeField] private TMP_InputField NameInputRegister;
    [SerializeField] private TMP_InputField PassInputRegister;
    [SerializeField] private TMP_InputField NameInputLogin;
    [SerializeField] private TMP_InputField PassInputLogin;
    public void VerifyRegister()
    {
        Submit.interactable = (NameInputRegister.text.Length >= 5 && PassInputRegister.text.Length >= 8);
    }
    public void VerifyLogin()
    {
        Login.interactable = (NameInputLogin.text.Length >= 5 && PassInputLogin.text.Length >= 8);
    }
}
