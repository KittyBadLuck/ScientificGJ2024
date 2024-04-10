using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.IMGUI.Controls;

#endif
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    // COMPONENTS
    //private GameManager _gm;
    private CommodorController _comGM;
    [Header("Components")]
    public GameObject self;
    private Collider _range;
    
    // VARS
    [Header("Mod Variables")]
    public int ID = 0;
    public bool corrupted = false;
    public int pannel = 1;
    public Vector2 position= new Vector2(0f, 0f);
    public bool playerNear;
    public bool hasTalked;
    public int storyStage = 0;

    void Awake()
    {
        _comGM = FindObjectOfType<CommodorController>();
        _range = GetComponent<Collider>();
    }

    void Update()
    {
        
    }

    public virtual void Interract(int step)
    {
        if ( playerNear)
        {
            Debug.Log("We interracted cutie <3");
        }
        
    }

    private void OnTriggerEnter(Collider player)
    {
        print("player is near");
        playerNear = true;
    }
    private void OnTriggerExit(Collider player)
    {
        playerNear = false;
    }
}
