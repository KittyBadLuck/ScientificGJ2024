using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
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

    void Awake()
    {
        _comGM = FindObjectOfType<CommodorController>();
        _range = GetComponent<Collider>();
    }

    public virtual void Interract(int step)
    {
        Debug.Log("We interracted cutie <3");
    }

    private void OnTriggerEnter(Collider player)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // _comGM
        }
    }
}
