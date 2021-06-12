using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    //Player Movement Variables
    public float baseSpeed = 2f;
    public float sprintSpeed = 3.5f;
    public float jumpHeight = .5f;

    //Grabbing GameObjects and transforms;
    private Transform player;
    private CharacterController playerController;

    //Private Variables
    private Vector2 chosenDirection = new Vector2(0, 0);
    private Vector3 verticalVelocity = new Vector3(0, 0, 0);
    private Vector3 currentLandVelocity = new Vector3(0, 0, 0);

    //Booleans

    private bool isSprinting = false;

    void Start(){
        player = this.transform;
        playerController = this.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext callback){
        chosenDirection = callback.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext callback){

    }

    public void onSprint(InputAction.CallbackContext callback){
        if(callback.performed){
            isSprinting = true;
        }else{
            isSprinting = false;
        }
    }

    public Vector3 CalculateLandVelocity(){
        Vector3 tempVector = player.forward * chosenDirection.y + player.right * chosenDirection.x;  
        float moveSpeed;
        if(isSprinting){
            moveSpeed = sprintSpeed;
        }else{
            moveSpeed = baseSpeed;
        }
        return tempVector * moveSpeed;
    }

    void Update(){
        currentLandVelocity = CalculateLandVelocity(); 
        playerController.Move(currentLandVelocity *Time.deltaTime);
    }

}
