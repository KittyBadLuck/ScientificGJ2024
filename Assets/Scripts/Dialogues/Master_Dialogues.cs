using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;

public class Master_Dialogues : MonoBehaviour
{
    public GameManager gameManager;
    public CommodorController commodorController;
    public static event Action<Story> OnCreateStory;
    public Story story;
    public AudioManagerScene audioManagerScene;
    public AudioManagerCommodore audioCommodore;

    public TMP_Text dialogueText = null;
    public TMP_Text nameText = null;
    public GameObject nameTextParent = null;
    public Material happyMaterial = null;

    //Option ButtonsW
    public Button[] buttonArray = null;

    //backgrounds
    [Header("Backgrounds Images")]
    public GameObject chooseNameParent = null;
    public Image textBackground = null;
    public RawImage nameBackground = null;

    //bool safeties
    private bool _canPass = true;
    public bool isWoman = false;
    private bool goodEnd = false;
    public float goodEndPoints = 0;

    //Colors for text
    [Header("Colors")]
    public Color commodorPrimColor;
    public Color commodorSecColor;
    public Color kaiPrimColor;
    public Color kaiSecColor;
    public Color charaPrimColor;
    public Color charaSecColor;
    public Color envColor;



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
        commodorController.GAME_STAGE = 2;
    }

    void RefreshView()
    {
        CleanView(); 
        // Continue gets the next line of the story
        if(story.canContinue)
        {
            audioCommodore.SFX_TextWritingPlay();
            string text = story.Continue();
            CheckTags();
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
                button.onClick.RemoveAllListeners();
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
        nameTextParent.gameObject.SetActive(true);

        nameText.text = name;
    }

    void CleanView()
    {
        foreach (Button button in buttonArray)
        {
            button.gameObject.SetActive(false);
        }
        nameTextParent.gameObject.SetActive(false);
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

    private void BadEnd()
    {
        SceneManager.LoadScene(2);
    }
    void EndDialogues()
    {
        gameManager.EndStory();
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


        return choice;
    }

    public void ValidateName(TMP_Text nameTMP)
    {
        if(nameTMP.text != null)
        {
            audioCommodore.SFX_MenuValidationPlay();
            if (goodEnd)
            {
                commodorController.playerName = nameTMP.text;
                SceneManager.LoadScene(2);
            }
            else
            {
                print("Make Name Bug");
                nameTMP.text = "E3#&&))";
                commodorController.playerName = "E3#&&))";
                commodorController.GAME_STAGE = 3;
                RefreshView();
                _canPass = true;
                chooseNameParent.SetActive(false);
                audioManagerScene.SFX_CorruptionPlay();
            }
           

        }
    }

    public void CheckTags()
    {
        List<string> lineTags = story.currentTags;
        bool isEnv = true;

        if (lineTags.Count > 0)
        {
            switch (lineTags[0])
            {
                case "kai":
                    SetTalkerName("Kai");
                    textBackground.color = kaiPrimColor;
                    nameBackground.color = kaiSecColor;
                    isEnv = false;
                    break;

                case "you":
                    SetTalkerName("You");
                    textBackground.color = charaPrimColor;
                    nameBackground.color = charaSecColor;
                    isEnv = false;
                    break;
                case "c64":
                    SetTalkerName("Commodore");
                    textBackground.color = commodorPrimColor;
                    nameBackground.color = commodorSecColor;
                    isEnv = false;
                    break;

                case "name_select":
                    
                    break;
                //case "man":
                //    isWoman = false;
                //    commodorController.isGenderMale = true;
                //    break;
                //case "woman":
                //    isWoman = true;
                //    commodorController.isGenderMale = false;
                //    break;
                case "good_end":
                    ChooseName();
                    goodEnd = true;
                    break;
                case "bad_end":
                    BadEnd();
                    break;
                default:
                    break;
            }

            // Check for bonus or malus
            if(lineTags.Contains("woman"))
            {
                isWoman = true;
                commodorController.isGenderMale = false;
            }

            if(lineTags.Contains("name_select")){ ChooseName(); }

            if (lineTags.Contains("minus"))
            {
                goodEndPoints--;
            }
            else if (lineTags.Contains("bonus"))
            {
                goodEndPoints++;
            }

            // Check if Ally is happy
            if (lineTags.Contains("ally_happy"))
            {
                commodorController.currentNPC.GetComponent<MeshRenderer>().material = happyMaterial;
            }
            if (lineTags.Contains("ally_dead"))
            {
                commodorController.currentNPC.SetActive(false);
            }

            //Change Background color to envColor if no other speaker is detected
            if (isEnv) { textBackground.color = envColor; }



            //sound check
            if (lineTags.Contains("steal"))
            {
                audioCommodore.SFX_StealingPlay();
            }
            else if (lineTags.Contains("buy")) { 
                audioCommodore.SFX_PurchasingPlay(); 
            }
            if (lineTags.Contains("witch"))
            {
                audioCommodore.SFX_WitchSpeakingPlay();
            }

        }
        else //no tag means its env speaking
        {
            textBackground.color = envColor;
        }
    }

}
