using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingHeadController : MonoBehaviour
{

    private Transform parentTransform;
    private float normalVerticalHeadPosition;
    private float ranNumThreshold = .9995f; 
    public bool currentlyAttached = true;
    private Rigidbody headRigidbody;

    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        parentTransform = this.transform.parent;
        normalVerticalHeadPosition = this.transform.position.y;
        headRigidbody = this.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "GameFloor"){
            isGrounded = true;
        }
    }   
    // Update is called once per frame
    void Update()
    {
        float ranNum = Random.Range(0f,1f);
        //If the head is attached we don't want gravity acting on it.
        if(currentlyAttached == true){
            this.transform.parent = parentTransform;
            this.transform.position = new Vector3(parentTransform.position.x, normalVerticalHeadPosition, parentTransform.position.z);
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            headRigidbody.isKinematic = true; 
        }

        //If the head is attached then give it chance to become unattached.
        if(currentlyAttached && ranNum >= ranNumThreshold){
            //Decouple the head and activate the rigidbody
            currentlyAttached = false;
            this.transform.parent = null;
            headRigidbody.isKinematic = false;
            isGrounded = false;
        }

    }
}
