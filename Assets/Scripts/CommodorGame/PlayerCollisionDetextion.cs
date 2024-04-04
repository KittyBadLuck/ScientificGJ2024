using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetextion : MonoBehaviour
{
    public GameObject self;
    private SphereCollider _selfCollider;
    public CommodorController _comGM;
    private void Awake()
    {
        _selfCollider = self.GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ffGoNext")) _comGM.SwapPannel();
    }
    
    
}
