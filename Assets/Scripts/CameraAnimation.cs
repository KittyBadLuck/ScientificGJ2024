using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraAnimation : MonoBehaviour
{

    public Animator animator;

    private bool isLean;
    public bool canLean = false;
    
    
    // Start is called before the first frame update
    void Start()
    { 
        
        isLean = false;

    }

    // Update is called once per frame
    void Update()
    {
        if ( canLean && Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //maintenir Space pour Zoomer puis relacher pour dezoomer
            {

                if (isLean)
                {

                    isLean = false;
                    animator.SetBool("Lean", false);
                    animator.SetBool("Back", true);

                }
                else
                {

                    isLean = true;
                    animator.SetBool("Lean", true);
                    animator.SetBool("Back", false);
                }


            }
        }
       
        
    }

    public void StopBack()
    {
        animator.SetBool("Back", false);
    }
}
