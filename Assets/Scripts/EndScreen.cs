using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void OnRestartButton()
    {
        SceneManager.LoadScene(0);
    }
    //called when we click the "Quit" button
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
