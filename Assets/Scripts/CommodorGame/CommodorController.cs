using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CommodorController : MonoBehaviour
{
    // CONTANTS
    public int GAME_STAGE = 0;
    public Vector2 SCREEN_SIZE = new Vector2(7.99f, 3.99f);
    
    // COMPONENTS
    // public GameManager _gameManager;
    
    public List<GameObject> obl;
    public GameObject _player;
    public GameObject _texteZone;
    public List<Button> _actionButtons;
    public bool helpTextShow = true;
    
    // VARS
    public bool isGenderMale;
    private String playerName;
    // private bool _inMenu = false;

    
    //// PLAYER
    // VARS
    public float PIXEL_SPEED = 1f;

    private void Awake()
    {
        _texteZone.SetActive(false);
        _player.SetActive(false);
        obl[0].SetActive(true);
        for (int i = 1; i < obl.Count; i++)
        {
           obl[i].SetActive(false);
        }
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
            case 0: // START BUTTON, Screen stop
                break;
            
            case 1: // GENDER SELECTION menu
                obl[1].SetActive(true);
                Destroy(obl[0]);
                break;
            
            case 2: // TYPE NAME
                obl[2].SetActive(true);
                Destroy(obl[1]);
                break;
            
            case 3: // GAME RULE, "know yourself. make the decision you fell right with..."
                Destroy(obl[2]);
                
                helpTextShow = Math.Sin(Time.time * 2.33) > 0 ? true : false;
                obl[4].SetActive(helpTextShow);
                obl[3].SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    UpdateGAMESTAGE();
                }
                break;
            
            case 4: // GAME START
                _player.SetActive(true);
                _texteZone.SetActive(true);
                Destroy(obl[3]);
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
            
            case 913:
                // NAME BUGS
                playerName = (string)obl[2].GetComponent<TMP_InputField>().text;
                Debug.Log($"Input name = {playerName}");
                UpdateGAMESTAGE();
                break;
        }
    }

}
