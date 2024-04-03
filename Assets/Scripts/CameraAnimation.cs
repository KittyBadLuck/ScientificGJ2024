using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animator animator;

    private bool Lean;
    
    
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
        if (Input.GetKey(KeyCode.E)) //maintenir E pour Zoomer puis relacher pour dezoomer
        {
            
            animator.SetBool("Lean", true);
            Debug.Log("Lean :" + Lean);
            
        }
        if (Input.GetKeyUp(KeyCode.E))
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
