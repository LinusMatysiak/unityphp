using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class StartHost : MonoBehaviour
{
    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
