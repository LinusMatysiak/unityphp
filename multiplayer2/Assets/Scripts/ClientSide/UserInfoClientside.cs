using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UserInfoClientside : MonoBehaviour
{
    [SerializeField] private TMP_Text UserInfoName;
    void Start()
    {
        if (DBManager.loggedin) {
            UserInfoName.text = "Logged in as: " + DBManager.username;
        }
    }
}
