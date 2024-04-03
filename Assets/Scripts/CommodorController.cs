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
    
    // COMPONENTS
    // public GameManager _gameManager;
    public GameObject _startButton;
    public GameObject _actionMenu;
    public GameObject _genderAssignementSelection;
    public GameObject _player;
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
        float _hAxe = Input.GetAxis("Horizontal");
        float _vAxe = Input.GetAxis("Vertical");

        float xMove = _hAxe * PIXEL_SPEED;
        float yMove = _vAxe * PIXEL_SPEED;

        Vector3 move = new Vector3(xMove, yMove, 0);
        _player.transform.position += move;
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
