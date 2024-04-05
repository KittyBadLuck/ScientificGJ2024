using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseOver : MonoBehaviour
{
    [SerializeField] private GameObject pressE;
    public static bool isOpen;
    public Behaviour player;
    [SerializeField] private GameObject Notebook;
    public bool canOpen = false;
   
    public void PauseGame()
    {
        player.enabled = false;
        Notebook.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        isOpen = true;
   
    }
    public void ContinueGame()
    {
        player.enabled = true;
        Notebook.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        isOpen = false;
    }


    private void Update()
    {
        if (canOpen) 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isOpen)
                {
                    ContinueGame();
                }
                else
                {
                    PauseGame();
                }

            }
        }
       
    }


    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        if (canOpen){ pressE.gameObject.SetActive(true); }
        


    }

    void OnMouseExit()
    {
        if (canOpen) { pressE.gameObject.SetActive(false); }
        //The mouse is no longer hovering over the GameObject so output this message each frame
    }  
}
