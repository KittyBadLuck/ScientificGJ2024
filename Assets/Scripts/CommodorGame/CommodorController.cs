using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Rendering;
using UnityEngine.UI;
using GameObject = UnityEngine.GameObject;

public class CommodorController : MonoBehaviour
{
    // CONSTANTS
    [Header("Constants")]
    public int GAME_STAGE = 0;
    public int GAME_PANNEL = 0;

    // COMPONENTS
    [Header("Game Objects")]
    // public GameManager _gameManager;
    public List<GameObject> comUI;
    public GameObject _player;
    public GameObject _texteZone;
    public List<Button> _actionButtons;
    public bool helpTextShow = true;

    [Header("NPCs & Enemies")] 
    public List<GameObject> npc;

    //public Material backgroundMaterial;
    [Header("Backgrounds")] 
    public GameObject bgBlack;
    public GameObject bgPannel;
    private Color[] _comColorlist = new [] {
        new Color(0,0,0, 255), //0..0
        new Color(103, 82, 0, 255), //20..9
        new Color(96, 96, 96, 255), //38..11
        new Color(153, 105, 45, 255), //39..8
        new Color(146, 74, 64, 255), //41..2
        new Color(72, 58, 170, 255), //45..6
        new Color(114, 177, 75, 255), //49..5
        new Color(147, 81, 182, 255), //52..4
        new Color(138, 138, 138, 255), //54..12 
        new Color(193, 129, 120, 255), //61..10
        new Color(132, 197, 204, 255), //66..3
        new Color(134, 122, 222, 255), //67..14
        new Color(213, 223, 124, 255), //68..7
        new Color(179,179,179, 255), //70..15
        new Color(179, 236, 145, 255), //75..13
        new Color(255,255,255, 255) //100..1
    };

    // VARS
    [Header("Player")]
    public bool isGenderMale;
    private String playerName;
    public float PIXEL_SPEED = 1f;

    private void Awake()
    {
        _texteZone.SetActive(false);
        _player.SetActive(false);
        comUI[0].SetActive(true);
        for (int i = 1; i < comUI.Count; i++)
        {
           comUI[i].SetActive(false);
        }
        foreach (GameObject entity in npc)
        {
            entity.SetActive(false);
        }
        bgBlack.SetActive(false);
        bgPannel.SetActive(true);
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
                comUI[1].SetActive(true);
                Destroy(comUI[0]);
                break;
            
            case 2: // TYPE NAME
                comUI[2].SetActive(true);
                Destroy(comUI[1]);
                break;
            
            case 3: // GAME RULE, "know yourself. make the decision you fell right with..."
                Destroy(comUI[2]);
                
                helpTextShow = Math.Sin(Time.time * 2.33) > 0 ? true : false;
                comUI[4].SetActive(helpTextShow);
                comUI[3].SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    UpdateGAMESTAGE();
                }
                break;
            
            case 4: // GAME START
                bgBlack.SetActive(true);
                bgPannel.SetActive(false);
                _player.SetActive(true);
                _texteZone.SetActive(true);
                Destroy(comUI[3]);
                Destroy(comUI[4]);
                break;
        }
    }

    void UpdatePannel()
    {
        switch (GAME_PANNEL)
        {
            case 0: // ICONIC PURPLE BACKGROUND
                
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
                Debug.Log("PLAYER hesitating but presses the Female Button");
                UpdateGAMESTAGE();
                break;
            
            case 913:
                // NAME BUGS
                playerName = (string)comUI[2].GetComponent<TMP_InputField>().text;
                Debug.Log($"Input name = {playerName}");
                UpdateGAMESTAGE();
                break;
        }
    }

    public int GetPannel()
    {
        return GAME_PANNEL;
    }
    
}
