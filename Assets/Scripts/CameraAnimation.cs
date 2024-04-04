using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animator animator;

    private bool Lean;

    public bool canLean = false;
    
    
    // Start is called before the first frame update
    void Start()
    { 
        animator = gameObject.GetComponent<Animator>();
        Lean = false;
        Debug.Log(Lean);

    }

    // Update is called once per frame
    void Update()
    {
        if (canLean) {
            if (Input.GetKey(KeyCode.Space)) //maintenir Space pour Zoomer puis relacher pour dezoomer
            {

                animator.SetBool("Lean", true);

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("Back", true);
                animator.SetBool("Lean", false);
            }
            else
            {
                animator.SetBool("Back", false);

            }
        }
       
    }
}
