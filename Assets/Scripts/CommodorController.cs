using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class CommodorController : MonoBehaviour
{
    // CONTANTS
    public int GAME_STAGE = 0;
    public Vector2 SCREEN_SIZE = new Vector2(7.99f, 3.99f);
    
    // COMPONENTS
    // public GameManager _gameManager;
    public GameObject _startButton;
    public GameObject _actionMenu;
    public GameObject _genderAssignementSelection;
    public GameObject _player;
    private BoxCollider _playerCollider;
    public List<Button> _actionButtons;
    
    // VARS
    public bool isGenderMale;
    // private bool _inMenu = false;

    
    //// PLAYER
    // VARS
    public float PIXEL_SPEED = 1f;

    private void Awake()
    {
        _player.SetActive(false);
        _startButton.SetActive(true);
        _actionMenu.SetActive(false);
        _genderAssignementSelection.SetActive(false);
        _playerCollider = _player.GetComponent<BoxCollider>();
    }

    void Update()
    {
        UpdateMenus();
    }

    private void FixedUpdate()
    {
        UpdatePlayer();
    }

    // UPDATERS
    void UpdateMenus()
    {
        switch (GAME_STAGE)
        {
            case 0:
                break;
            case 1:
                _genderAssignementSelection.SetActive(true);
                Destroy(_startButton);
                break;
            case 2:
                _player.SetActive(true);
                Destroy(_genderAssignementSelection);
                break;
        }
    }

    void UpdatePlayer()
    {
        Vector3 playerPose = _player.transform.position;
        
        float _hAxe = Input.GetAxis("Horizontal");
        float _vAxe = Input.GetAxis("Vertical");

        float xMove = _hAxe * PIXEL_SPEED;
        float yMove = _vAxe * PIXEL_SPEED;
        
        Vector3 move = new Vector3(xMove, yMove, 0);
        _player.transform.position += move;

        if (playerPose.x < -SCREEN_SIZE[0])
        {
            playerPose = new Vector3(-8, playerPose.y, playerPose.z);
            Debug.Log("brbrbr");
        }
        else if (playerPose.x > SCREEN_SIZE[0])
        {
            playerPose = new Vector3(8, playerPose.y, playerPose.z);
            Debug.Log("brbrbr");
        }
        if (playerPose.z < -SCREEN_SIZE[1])
        {
            playerPose = new Vector3(playerPose.x, playerPose.y, -4);
            Debug.Log("brbrbr");
        }
        else if (playerPose.z > SCREEN_SIZE[1])
        {
            playerPose = new Vector3(playerPose.x, playerPose.y, 4);
            Debug.Log("brbrbr");
        }
    }

    // BUTTON ACTION CALLING
    void UpdateGAMESTAGE(int n = 1)
    {
        if (n == 1)
        {
            GAME_STAGE++;
        }
        else
        {
            GAME_STAGE = n;
        }
    }

    
    public void ButtonPressed(int buttonID)
    {
        switch (buttonID)
        {
            case 0:
                UpdateGAMESTAGE();
                break;
            case 1:
                UpdateGAMESTAGE();
                break;
            
            case 911:
                //NORMAL
                isGenderMale = true;
                Debug.Log("PLAYER presses without hesitation");
                UpdateGAMESTAGE();
                break;
            
            case 912:
                //HESITATE, THEN PRESS
                isGenderMale = false;
                Debug.Log("PLAYER hestiating but presses the Female Button");
                UpdateGAMESTAGE();
                break;
        }
    }
    
}
