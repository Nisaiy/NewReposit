using UnityEngine;
using System.Collections;

public class MainWindow : MonoBehaviour
{

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Start Game"))
        {
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 100), "Exit Game"))
        {
            Application.Quit();
        }
    }
}
