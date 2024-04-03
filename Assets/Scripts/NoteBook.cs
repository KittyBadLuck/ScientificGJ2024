using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteBook : MonoBehaviour
{
    private InputField inputField;

    private void Start()
    {
        // Recherchez le InputField enfant du GameObject actuel
        inputField = GetComponentInChildren<InputField>();

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
        // Vous pouvez utiliser newText comme vous le souhaitez, par exemple pour l'afficher dans la console
        Debug.Log("Nouveau texte : " + newText);
    }
}
