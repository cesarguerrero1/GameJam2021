using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //We need to check how to transition the animations
        if(playerMovement.isMoving){
            //This means we are standing still.
            animator.SetBool("isMoving", true);
        }else{
            animator.SetBool("isMoving", false);
        }

        if(playerMovement.isGrounded){
            animator.SetBool("isJumping", false);
        }else{
            animator.SetBool("isJumping", true);
        }
    }
}
