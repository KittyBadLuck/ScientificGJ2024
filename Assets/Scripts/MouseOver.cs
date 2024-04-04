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
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (isOpen)
            {
                ContinueGame();
                Debug.Log("notebook close rn");
            } 
            else
            {
                PauseGame();
                Debug.Log("notebook open rn");
            }
        
            

        }
    }


    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        
        

    }

    void OnMouseExit()
    {
        pressE.gameObject.SetActive(false);
        //The mouse is no longer hovering over the GameObject so output this message each frame
    }  
}
