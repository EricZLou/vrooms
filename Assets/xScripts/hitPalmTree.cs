using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPalmTree : MonoBehaviour {

    public gameManager gmScript;               // script attached to game manager

	// Use this for initialization
	void Start () {
		
	}
	
    // when cannonball hits the palm tree
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "cannonball")
        {
            gmScript.treeHit();
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
