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

    // Start is called before the first frame update
    void Start()
    {
        _dialogues = dialogueCanvas.GetComponent<Master_Dialogues>();
        _dialogues.gameManager = this;
        StartIntro();
    }

    void StartIntro()
    {
        cameraControl.inDialogue = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _dialogues.StartStory(storyJSONassets[0]);
        cameraAnimControl.canLean = false;
    }

    public void EndStory()
    {
        switch (_scene)
        {
             case 0:
                cameraAnimControl.canLean = true;
                _scene++;
                break;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraControl.inDialogue = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
