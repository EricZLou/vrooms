using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonballCollision : MonoBehaviour {

    public gameManager gmScript;               // script attached to game manager

    // Use this for initialization
    void Start () {

    }

    // once cannonball collides with ground, setInAir to false
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "cannonball")
        {
            gmScript.setInAir(false);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
