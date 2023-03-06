using UnityEngine;
using Unity.Netcode;

public class StartClient : MonoBehaviour
{
    public void JoinServer() {
        NetworkManager.Singleton.StartClient();
    }
}
