using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    [SerializeField] private GameObject pressE;

    [SerializeField] private GameObject inputField;
    void OnMouseOver()
    {
        pressE.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            inputField.gameObject.SetActive(true);
            Debug.Log("OPEN NOTEBOOK");
            
        }
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        pressE.gameObject.SetActive(false);
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }  
}
