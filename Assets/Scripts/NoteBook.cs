using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;

public class NoteBook : MonoBehaviour
{
    [SerializeField] private GameObject Notebook;
    public InputField inputField;
    public Text outputText;

    private void Start()
    {
        // Recherchez le InputField enfant du GameObject actuel
        
        if (inputField == null)
        {
            Debug.LogError("InputField introuvable dans le GameObject ou ses enfants.");
        }
        else
        {
            // Activer l'interaction avec l'InputField
            inputField.interactable = true;
            
            
        }
    }

    

    // Méthode appelée lorsque le texte est modifié dans le champ de texte
    public void OnTextChange(string newText)
    {
        newText = inputField.text;
        
        outputText.text = outputText.text + '\n' + newText;
       
        
    }

    public void OnXButton()
    {
        Notebook.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        
    }
    
}
