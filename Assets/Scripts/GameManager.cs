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

    public CameraAnimation cameraAnimControl;
    public CameraControl cameraControl;

    public int goodEndThreshold = 4;

    // Start is called before the first frame update
    void Start()
    {
        _dialogues = dialogueCanvas.GetComponent<Master_Dialogues>();
        _dialogues.gameManager = this;
        StartStory();
    }

    void StartStory()
    {
        switch (_scene)
        {
            case 5:
                if (_dialogues.isWoman)
                {
                    _dialogues.StartStory(storyJSONassets[6]);
                }
                else
                {
                    _dialogues.StartStory(storyJSONassets[5]);
                }
                break;
            case 8:
                if (_dialogues.goodEndPoints >= goodEndThreshold)
                {
                    _dialogues.StartStory(storyJSONassets[8]);
                }
                else
                {
                _dialogues.StartStory(storyJSONassets[9]); 
                }
                break;
            default:
                _dialogues.StartStory(storyJSONassets[_scene]);
                break;


        }
        cameraControl.inDialogue = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cameraAnimControl.canLean = false;
    }

    public void EndStory()
    {
        switch (_scene)
        {
             case 5:
                _scene = 7; break;
             default:
                _scene++;
                break;


        }
        cameraAnimControl.canLean = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraControl.inDialogue = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
