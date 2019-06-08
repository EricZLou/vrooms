using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCannon : MonoBehaviour {

    public GameObject cannonHead;
    public GameObject ball;
    private OVRInput.Controller controller;
    private bool inside;
    private bool adjusting;
    private bool upwards;

    // Use this for initialization
    void Start () {
        controller = OVRInput.Controller.RTrackedRemote;
        inside = false;
        adjusting = false;
        upwards = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ball")
        {
            inside = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "ball")
        {
            inside = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        // change direction of cannon motion 
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad, controller))
        {
            upwards = !upwards;
        }
        // when trigger pulled, start changing angle
		if (inside && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            adjusting = true;
        }
        // when trigger released, stop changing angle
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            adjusting = false;
        }
        // when adjusting, tilt up or down appropriately
        if (adjusting)
        {
            float angle = 30f;
            // get vector to rotate around (clockwise, counterclockwise)
            Vector3 dir;
            if (upwards) dir = Vector3.right;
            else dir = Vector3.left;
            transform.RotateAround(new Vector3(0f, 5.7f, 2f), dir, angle * Time.deltaTime);
        }
    }
}
