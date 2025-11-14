using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBounceBoy : MonoBehaviour
{

    Animator _movementAnimator;

   
    void Start()
    {
        _movementAnimator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    public void Update()
    {
        if(_movementAnimator != null)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                Frw();
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                _movementAnimator.SetTrigger("TrIdle");
            }

            if(Input.GetKeyDown(KeyCode.D))
            {
                Right();
            }
            if(Input.GetKeyUp(KeyCode.D))
            {
                _movementAnimator.SetTrigger("TrIdle");
            }

             if(Input.GetKeyDown(KeyCode.A))
            {
                Left();  
            }
            if(Input.GetKeyUp(KeyCode.A))
            {
                _movementAnimator.SetTrigger("TrIdle");
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                Back();             
            }
             if(Input.GetKeyUp(KeyCode.S))
            {
                _movementAnimator.SetTrigger("TrIdle");
            }

             if(Input.GetMouseButton(1))
            {
                Kick();              
            }
            

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Dash();
            }          
        }       
    }

    public void Frw()
    {
         if(Input.GetKey(KeyCode.W))
            {
                _movementAnimator.SetTrigger("TrForward");   
            }
            else
            {
                _movementAnimator.SetTrigger("TrIdle"); 
            }
    }

    public void Right()
    {
         if(Input.GetKey(KeyCode.D))
            {
                _movementAnimator.SetTrigger("TrRight");   
            }
            else
            {
                _movementAnimator.SetTrigger("TrIdle"); 
            }
    }

    public void Left()
    {
         if(Input.GetKey(KeyCode.A))
            {
                _movementAnimator.SetTrigger("TrLeft");   
            }
            else
            {
                _movementAnimator.SetTrigger("TrIdle"); 
            }
    }

    public void Back()
    {
         if(Input.GetKey(KeyCode.S))
            {
                _movementAnimator.SetTrigger("TrBackward");   
            }
            else
            {
                _movementAnimator.SetTrigger("TrIdle"); 
            }
    }

    private void Kick()
    {
         if(Input.GetMouseButton(1))
            {
                _movementAnimator.SetTrigger("TrKick");               
            }
            else
            {
                _movementAnimator.SetTrigger("TrIdle");
            }
    }

    private void Dash()
    {
          if(Input.GetKeyDown(KeyCode.Space))
            {
                _movementAnimator.SetTrigger("TrFrwDash");
            }
            else
            {
                _movementAnimator.SetTrigger("TrIdle");
            } 
    }
}
