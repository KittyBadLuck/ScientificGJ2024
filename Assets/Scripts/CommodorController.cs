using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class CommodorController : MonoBehaviour
{
    // CONTANTS
    public int GAMESTAGE = 0;
    
    // COMPONENTS
    public GameObject _startButton;
    public GameObject _actionMenu;
    public GameObject _genderAssignementSelection;
    public List<Button> _actionButtons;
    
    // VARS
    private bool _inMenu = true;


    private void Awake()
    {
        _startButton.SetActive(true);
        _actionMenu.SetActive(false);
        _genderAssignementSelection.SetActive(false);
    }

    void Update()
    {
        UpdateMenus();
    }

    void UpdateMenus()
    {
        switch (GAMESTAGE)
        {
            case 0:
                break;
            case 1:
                _genderAssignementSelection.SetActive(true);
                Destroy(_startButton);
                break;
                
        }
    }

    void UpdateGAMESTAGE(int n = 1)
    {
        if (n == 1)
        {
            GAMESTAGE++;
        }
        else
        {
            GAMESTAGE = n;
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
        }
    }
    
}
