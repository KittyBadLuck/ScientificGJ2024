using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public CommodorController commodorController;
    private Master_Dialogues _dialogues;
    public GameObject player;

    public TextAsset[] storyJSONassets;
    private int _scene = 0;

    // Start is called before the first frame update
    void Start()
    {
        _dialogues = dialogueCanvas.GetComponent<Master_Dialogues>();
        StartIntro();
    }

    void StartIntro()
    {
        _dialogues.StartStory(storyJSONassets[0]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
