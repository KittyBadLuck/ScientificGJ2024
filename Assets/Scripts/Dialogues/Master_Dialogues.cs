using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Master_Dialogues : MonoBehaviour
{
    public static event Action<Story> OnCreateStory;
    public Story story;

    public TMP_Text dialogueText = null;
    public TMP_Text nameText = null;

    //Option ButtonsW
    public Button[] buttonArray = null;

    public GameObject chooseNameParent = null;

    //bool safeties
    private bool _canPass = true;

    public void StartStory(TextAsset storyJSONAsset)
    {
        story = new Story(storyJSONAsset.text);
        if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }

    void ChooseName()
    {
        _canPass = false;
        chooseNameParent.SetActive(true);
        print("choose name");
    }

    void RefreshView()
    {
        CleanView(); 
        // Continue gets the next line of the story
        if(story.canContinue)
        {
            string text = story.Continue();
            List<string> lineTags = story.currentTags;

            if (lineTags.Count > 0)
            {
                switch (lineTags[0])
                {
                    case "kai":
                        SetTalkerName("Kai");
                        break;

                    case "you":
                    SetTalkerName("You");
                        break;

                    case "name_select":
                        ChooseName();
                        break;

                    default:
                        break;
                }
            }
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);
        }
        
        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim(), i);
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate
                {
                    OnClickChoiceButton(choice);
                });
            }
        }

    }

    void CreateContentView(string text)
    {  
        dialogueText.text = text;
    }
    void SetTalkerName(string name)
    {
        nameText.gameObject.SetActive(true);

        nameText.text = name;
    }

    void CleanView()
    {
        foreach (Button button in buttonArray)
        {
            button.gameObject.SetActive(false);
        }
        nameText.gameObject.SetActive(false);
        dialogueText.text = " ";

    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    public void Pass(InputAction.CallbackContext context)
    {
        if(_canPass){ 
            if (context.performed)
            {
                if(story.currentChoices.Count == 0 )
                {
                    if (story.canContinue == false) 
                    { EndDialogues(); }
                    else { RefreshView(); }
                }
            }
        };

    }


    void EndDialogues()
    {
        print("End");
        this.gameObject.SetActive(false);

    }

    // Creates a button showing the choice text
    Button CreateChoiceView( string text, int index)
    {
        // Creates the button from a prefab
        Button choice = buttonArray[index];
        choice.gameObject.SetActive(true);

        // Gets the text from the button prefab
        TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text>();
        choiceText.text = text;

        // Make the button expand to fit the text
        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        return choice;
    }

    public void ValidateName(TMP_Text nameTMP)
    {
        if(nameTMP.text != null)
        {
            print("Make Name Bug");
            _canPass = true;
            chooseNameParent.SetActive(false);

        }
    }
}
