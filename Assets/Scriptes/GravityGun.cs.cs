using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mirror;

public class GravityGun : MonoBehaviour
{

    [SerializeField] public Camera cam;
    [SerializeField] float maxGrabDistance = 10f, throwForce = 20f, lerpSpeed = 10f;
    [SerializeField] Transform objectHolder;

    public GameObject grabbedObj;
    public Rigidbody grabbedRB;
    public LayerMask CanPick;

    void Start()
    {
        //if (!isLocalPlayer) return;
        cam = Camera.main;
 
    }
    void FixedUpdate()
    {
        //if (!isLocalPlayer) return;
        if (grabbedRB)
        {
            //if (!isLocalPlayer) return;
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, Time.fixedDeltaTime * lerpSpeed));

            if (Input.GetMouseButtonDown(0))
            {
                grabbedRB.useGravity = true;
                grabbedRB.drag = grabbedRB.drag / 5;
                grabbedRB.AddForce(cam.transform.forward * throwForce, ForceMode.VelocityChange);
                grabbedRB = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //if (!isLocalPlayer) return;
            if (grabbedRB)
            {
                grabbedRB.useGravity = true;
                grabbedRB.drag = grabbedRB.drag / 5;
                grabbedRB = null;
            }
            else
            {
                
                //cam = GetComponent<FPSController>().cam;
                objectHolder = cam.transform.GetChild(0);
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                Debug.Log(Physics.Raycast(ray, out hit, maxGrabDistance, CanPick));
                if (Physics.Raycast(ray, out hit, maxGrabDistance, CanPick))
                {
                    grabbedObj = hit.collider.gameObject;
                    grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (grabbedRB)
                    {
                        grabbedRB.useGravity = false;
                        grabbedRB.drag = grabbedRB.drag * 5;
                    }
                }
                else
                {
                    Debug.Log("You can`t pick it up.");
                }
            }
        }
    }
}