using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public static bool isGamePaused;

   
    public void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
   
    }
    public void ContinueGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ContinueGame();
                Debug.Log("Game should NOT be paused rn");
            } 
            else
            {
                PauseGame();
                Debug.Log("Game should be paused rn");
            }
        }
        
    }

    public void OnResumeButton()
    {
        ContinueGame();
        Debug.Log("RESUME");
    }
    //called when we click the "Quit" button
    public void OnQuitButton()
    {
        Application.Quit();
        Debug.Log("QUIIIIIIIIIT");
    }

    
}
