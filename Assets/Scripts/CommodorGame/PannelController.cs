using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelController : MonoBehaviour
{
    public GameObject backgroundObject;
    public List<Material> textureList;
    private Renderer _renderer;
    public CommodorController _comGM;

    private void Awake()
    {
        _renderer = backgroundObject.GetComponent<Renderer>(); 
    }

    private void Update()
    {
        _renderer.material = textureList[_comGM.GetPannel()];
    }
    
}
