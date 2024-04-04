using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraAnimation : MonoBehaviour
{
    
    
    public Animator animator;
    
    
    
    
    
    private bool isLean;
    
    
    // Start is called before the first frame update
    void Start()
    { 
        
        isLean = false;
        Debug.Log(isLean);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) //maintenir Space pour Zoomer puis relacher pour dezoomer
        {
            
            if (isLean)
            {
                
                isLean = false;
                animator.SetBool("Lean", false);
                animator.SetBool("Back", true);
                Debug.Log("player back rn");
                
            } 
            else
            {

                isLean = true;
                animator.SetBool("Lean", true);
                animator.SetBool("Back", false);
                Debug.Log("player lean rn");
            }
            
            
        }
        
    }

    public void StopBack()
    {
        animator.SetBool("Back", false);
    }
}
