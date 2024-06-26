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
    public AudioManagerScene audioManagerScene;
    public AudioManagerCommodore audioCommodore;
    /// COMPONENTS
    public PlayerInput playerInput;
    public GameObject player;
    public GameObject dialogueCanvas;


    /// Stories stats
    public TextAsset[] storyJSONassets;
    public int scene = 0;
    public int goodEndThreshold = 4;


    // Start is called before the first frame update
    void Start()
    {
        audioCommodore.SFX_CommodoreMusicPlay();
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

        switch (scene)
        {
            case 0:
                _dialogues.StartStory(storyJSONassets[0]);
                audioManagerScene.SFX_DoorOpeningPlay();
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
                _dialogues.StartStory(storyJSONassets[8]); 
                }
                break;
            default:
                _dialogues.StartStory(storyJSONassets[scene]);
                break;


        }

    }

    public void EndStory()
    {
        switch (scene)
        {
             case 4:

                scene = 6;
                print("scene 6" +  scene);
                break;
             default:
                scene++;
                print("scene default" );
                break;
        }
        commodorController.canMove = true;
        cameraAnimControl.canLean = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mouseOver.canOpen = true;
        cameraControl.inDialogue = false;
        playerInput.SwitchCurrentActionMap("Game");
        if(commodorController.currentNPC != null) { commodorController.currentNPC.GetComponent<EnemyController>().hasTalked = true; }
       

    }


    public void UpdateField(TMP_InputField originField)
    {

        string name = originField.text;
        TMP_InputField TMP_IF = commodorController.comUI[2].GetComponent<TMP_InputField>();
        TMP_IF.interactable = true;
        TMP_IF.text = name;
    }
}
