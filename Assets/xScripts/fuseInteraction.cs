using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuseInteraction : MonoBehaviour {

    public Rigidbody cannonballPrefab;
    public GameObject dotPrefab;
    public GameObject marker;
    public GameObject cannonHead;
    public gameManager gmScript;               // script attached to game manager
    private Renderer rend;
    private Color origColor;
    private float scale;
    private Rigidbody cannonball;
    private List<GameObject> dotList;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
        scale = 20f;
	}
	
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ball")
        {
            //if in air, don't trigger
            if (gmScript.getInAir())
            {
                rend.material.color = Color.black;
            }
            else
            {
                gmScript.setInAir(true);               // cannonball fired, aka in air!
                rend.material.color = Color.white;
                cannonball = Instantiate(cannonballPrefab, marker.transform.position, Quaternion.identity);
                float angle = Mathf.Abs(cannonHead.transform.rotation.eulerAngles.x) * Mathf.Deg2Rad;
                cannonball.velocity = scale * new Vector3(0f, Mathf.Abs(Mathf.Sin(angle)), Mathf.Abs(Mathf.Cos(angle)));
                InvokeRepeating("createDots", 0.1f, 0.2f);
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "ball")
        {
            rend.material.color = origColor;
        }
    }

    private void createDots()
    {
        GameObject dot = Instantiate(dotPrefab, cannonball.transform.position, Quaternion.identity);
        dotList.Add(dot);
    }

    private void removeDots()
    {
        foreach (GameObject dot in dotList)
        {
            Destroy(dot);
        }
        dotList.Clear();
    }

    // Update is called once per frame
    void Update() {
        if (!gmScript.getInAir())
        {
            CancelInvoke();
        }
    }
}
