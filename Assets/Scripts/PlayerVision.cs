using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerVision : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    private Transform playerCamera;
    private float horizontalAxisRotation = 0f;
    private float verticalAxisRotation = 0f;

   private Vector2 cameraMovement;
    void Start()
    {
        playerCamera = this.transform.GetChild(0);
    }

    public void OnCameraMove(InputAction.CallbackContext callback){
        cameraMovement = callback.ReadValue<Vector2>();
        
    }

    void Update()
    {
        //When you move the mouse left and right, it should rotate the camera left and right about the y
        float xMovement = cameraMovement.x * mouseSensitivity * Time.deltaTime;
        float yMovement = cameraMovement.y * mouseSensitivity * Time.deltaTime;

        //When the player moves up and down we don't want them to be able to point all teh way
        verticalAxisRotation += xMovement;
        horizontalAxisRotation -= yMovement;
        horizontalAxisRotation = Mathf.Clamp(horizontalAxisRotation, -10f, 10f);
        playerCamera.localRotation = Quaternion.Euler(horizontalAxisRotation, verticalAxisRotation, 0f);
    }
}
