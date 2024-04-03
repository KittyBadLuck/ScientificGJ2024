using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupScreen : MonoBehaviour
{
    //called when we click the "Play" button
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    //called when we click the "Quit" button
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
