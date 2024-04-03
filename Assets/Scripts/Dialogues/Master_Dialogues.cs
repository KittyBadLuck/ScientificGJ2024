using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class Master_Dialogues : MonoBehaviour
{
    public static event Action<Story> OnCreateStory;

    [SerializeField]
    private TextAsset _introJSONAsset = null;
    public Story story;

    [SerializeField]
    private Canvas _canvas = null;
    public TMP_Text dialogueText = null;

    // UI Prefabs
    [SerializeField]
    private TMP_Text _textPrefab = null;
    [SerializeField]
    private Button _buttonPrefab = null;

    //Option Buttons
    public Button[] buttonArray = null;


    // Start is called before the first frame update
    void Awake()
    {
        StartIntro();
    }

    void StartIntro()
    {
        story = new Story(_introJSONAsset.text);
        if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }

    void RefreshView()
    {
        CleanView(); 
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
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
                Button button = CreateChoiceView(choice.text.Trim() , i);
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate
                {
                    OnClickChoiceButton(choice);
                });
            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            Button choice = CreateChoiceView("End of story.\nRestart?" , 0 );
            choice.onClick.AddListener(delegate
            {
                StartIntro();
            });
        }
    }

    void CreateContentView(string text)
    {
        dialogueText.text = text;
    }

    void CleanView()
    {
        foreach (Button button in buttonArray)
        {
            button.gameObject.SetActive(false);
        }

        dialogueText.text = " ";

    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
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

}
