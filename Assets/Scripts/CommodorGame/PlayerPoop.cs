using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class PlayerPoop : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("That is a big big poop here :O");
    }
}
