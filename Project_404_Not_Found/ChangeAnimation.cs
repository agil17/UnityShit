using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeAnimation : MonoBehaviour
{
    Animator anim;
    bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;

        if(keyboard != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isRunning = runToggle();
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                if (isRunning)
                    anim.SetFloat("Speed", 1f); 
                else
                    anim.SetFloat("Speed", 0.5f);
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            {
                anim.SetFloat("Speed", 0.0f);
            }
        }  
    }

    public void Jump()
    {
        //anim.SetBool("Squat", false);
        //anim.SetBool("Aiming", false);
        anim.SetTrigger("Jump");
    }

    private bool runToggle()
    {
        if (isRunning)
            return false;
        else
            return true;
    }

    /*public void Walk()
    {
        anim.SetBool("Aiming", false);
        anim.SetFloat("Speed", 0.5f);
    }*/
}
