using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    /// Scripts references

    public CommodorController commodorController;
    private Master_Dialogues _dialogues;
    public MouseOver mouseOver;
    public CameraAnimation cameraAnimControl;
    public CameraControl cameraControl;

    /// COMPONENTS
    public PlayerInput playerInput;
    public GameObject player;
    public GameObject dialogueCanvas;


    /// Stories stats
    public TextAsset[] storyJSONassets;
    private int _scene = 0;
    public int goodEndThreshold = 4;


    // Start is called before the first frame update
    void Start()
    {
        _dialogues = dialogueCanvas.GetComponent<Master_Dialogues>();
        playerInput = this.GetComponent<PlayerInput>();
        _dialogues.gameManager = this;
        StartStory();
    }

    public void StartStory()
    {
        playerInput.SwitchCurrentActionMap("Dialogues");
        dialogueCanvas.SetActive(true);
        commodorController.canMove = false;
        cameraControl.inDialogue = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cameraAnimControl.canLean = false;
        mouseOver.canOpen = false;
        switch (_scene)
        {
            case 0:
                _dialogues.StartStory(storyJSONassets[0]);
                commodorController.GAME_STAGE = 1;
                break;
            case 4:
                if (_dialogues.isWoman)
                {
                    _dialogues.StartStory(storyJSONassets[5]);
                }
                else
                {
                    _dialogues.StartStory(storyJSONassets[4]);
                }
                break;
            case 7:
                if (_dialogues.goodEndPoints >= goodEndThreshold)
                {
                    _dialogues.StartStory(storyJSONassets[7]);
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
        commodorController.canMove = true;
        cameraAnimControl.canLean = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mouseOver.canOpen = true;
        cameraControl.inDialogue = false;
        playerInput.SwitchCurrentActionMap("Game");

    }


    public void UpdateField(TMP_InputField originField)
    {

        string name = originField.text;
        TMP_InputField TMP_IF = commodorController.comUI[2].GetComponent<TMP_InputField>();
        TMP_IF.interactable = true;
        TMP_IF.text = name;
    }
}
