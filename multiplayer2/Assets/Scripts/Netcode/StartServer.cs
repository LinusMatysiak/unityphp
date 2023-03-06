using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class StartServer : MonoBehaviour
{
    private void Start()
    {
        NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
