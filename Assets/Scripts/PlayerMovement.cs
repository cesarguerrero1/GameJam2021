using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    //Player Movement Variables
    public float baseSpeed = 2f;
    public float sprintSpeed = 5f;
    public float jumpHeight = 1f;
    public float gravityValue = -9.81f;

    //Grabbing GameObjects and transforms;
    private Transform player;
    private CharacterController playerController;

    //Private Variables
    private Vector2 chosenDirection = new Vector2(0, 0);
    public Vector3 verticalVelocity = new Vector3(0, 0, 0);
    private Vector3 currentLandVelocity = new Vector3(0, 0, 0);

    //Booleans
    public bool isGrounded = false;
    private bool isSprinting = false;


    void Start(){
        player = this.transform;
        playerController = this.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext callback){
        chosenDirection = callback.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext callback){
        //When you jump you gain an initial velocity which is v = sqrt(-2 * g * jumpDistance); g is assumed to be negative in this case
        if(isGrounded){
            verticalVelocity.y = Mathf.Sqrt(-2f * gravityValue * jumpHeight);
        }
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
        //Handle gravity!
        isGrounded = playerController.isGrounded;
        if(isGrounded && verticalVelocity.y < 0){
            //Needs to be sufficiently big enough otherwise CharacterController panics
            verticalVelocity.y = -1f;
        }

        currentLandVelocity = CalculateLandVelocity(); 
        playerController.Move(currentLandVelocity * Time.deltaTime);
    
        //You are always being crushed by gravity. If you don't multiply by Time.deltaTime here you are literally crushed. lol
        verticalVelocity.y += gravityValue * Time.deltaTime;
        playerController.Move(verticalVelocity * Time.deltaTime);   
    }

}
