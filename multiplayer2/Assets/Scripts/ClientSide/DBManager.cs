using UnityEngine;

public class DBManager : MonoBehaviour
{
    public static string username;
    public static int currency;

    public static bool loggedin { get { return username != null; } }

    public static void logout() {
        username = null;
    }
}
