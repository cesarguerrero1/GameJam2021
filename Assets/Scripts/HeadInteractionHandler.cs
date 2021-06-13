using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadInteractionHandler : MonoBehaviour
{
    private FallingHeadController fallingHeadController;

    void Start(){
        fallingHeadController = this.transform.GetChild(1).GetComponent<FallingHeadController>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.collider.name == "HeadMesh" && fallingHeadController.currentlyAttached == false && fallingHeadController.isGrounded){
            //Reattach the head!
            fallingHeadController.currentlyAttached = true;
        }
    }
}
