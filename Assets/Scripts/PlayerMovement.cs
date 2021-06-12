using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    //Player Movement Variables
    public float baseSpeed = 1f;
    public float sprintSpeed = 1.25f;
    public float jumpHeight = .5f;

    //Grabbing GameObjects and transforms;
    private Transform player;
    private CharacterController playerController;

    //Private Variables
    private Vector2 chosenDirection = new Vector2(0, 0);
    void Start(){
        player = this.transform;
        playerController = this.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext callback){
        chosenDirection = callback.ReadValue<Vector2>();
    }

    void Update(){
        Debug.Log(chosenDirection);
    }

}
