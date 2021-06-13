using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerVision : MonoBehaviour
{
    //Vision Movement Variables
    public float mouseSensitivity = 10f;
    public float upperLookLimit = 10f;
    public float lowerLookLimit = -10f;
    

    //Grabbing Players Vision Camera
    private GameObject playerCameraObject;
    private Transform playerCamera;
  
    //Private Variables
    private Vector2 cameraMovement;
    private float horizontalAxisRotation = 0f;
    private float verticalAxisRotation = 0f;
    void Start()
    {
        playerCameraObject = GameObject.Find("Vision Camera");
        playerCamera = playerCameraObject.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        horizontalAxisRotation = Mathf.Clamp(horizontalAxisRotation, lowerLookLimit, upperLookLimit);
        playerCamera.localRotation = Quaternion.Euler(horizontalAxisRotation, verticalAxisRotation, 0f);
    }
}
