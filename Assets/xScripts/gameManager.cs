using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Transform controller;
    public GameObject acorn;
    public TextMesh textBox;

    private OVRInput.Controller c;
    private bool inAir;

    // Use this for initialization
    void Start()
    {
        inAir = false;
        c = OVRInput.Controller.RTrackedRemote;
    }

    public bool getInAir()
    {
        return inAir;
    }

    public void setInAir(bool air)
    {
        inAir = air;
    }

    public void treeHit()
    {
        acorn.GetComponent<Rigidbody>().useGravity = true;
        StartCoroutine(moveAcorn());
    }

    IEnumerator moveAcorn()
    {
        yield return new WaitForSeconds(2);
        acorn.transform.position = new Vector3(2.5f, 5.5f, 6f);
        acorn.transform.eulerAngles = new Vector3(0, -180, 0);
        acorn.GetComponent<Rigidbody>().useGravity = false;
        acorn.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ
            | RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezePositionY 
            | RigidbodyConstraints.FreezePositionZ;
        textBox.text = "Thank you so much! \n" +
            "You helped me get my acorn by using the " +
            "laws of physics!";
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetControllerPositionTracked(c))
        {
            controller.localRotation = OVRInput.GetLocalControllerRotation(c);
            controller.localPosition = OVRInput.GetLocalControllerPosition(c);
        }

        // to allow for reseting in case it messes up lol
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad, c) 
            && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, c))
        {
            inAir = false;
        }
    }
}
