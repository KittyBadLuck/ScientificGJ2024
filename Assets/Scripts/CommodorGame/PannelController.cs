using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelController : MonoBehaviour
{
    public GameObject backgroundObject;
    public List<Material> texterList;
    private Material _bg;
    public CommodorController _comGM;

    private void Awake()
    {
        _bg = backgroundObject.GetComponent<Material>();
    }

    private void Update()
    {
        _bg = texterList[_comGM.GetPannel()];
    }
}
