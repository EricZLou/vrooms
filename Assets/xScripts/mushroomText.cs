using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomText : MonoBehaviour {

    public TextMesh textBox;
    private OVRInput.Controller controller;
    private string[] messages = new string[9];
    private int count = 0;

    // Use this for initialization
    void Start ()
    {
        controller = OVRInput.Controller.RTrackedRemote;
        messages[0] = "Hi there! \n" +
            "I’m Nibbles and I need your help. \n" +
            "(touch mushroom to continue)";
        messages[1] = "I hurt my foot and cannot reach \n" +
            "that acorn high up in the tree.";
        messages[2] = "Here is a cannon that you can use to \n" +
            "get the acorn. To start, pull the trigger while \n" +
            "touching the cannon. This moves it down.";
        messages[3] = "If you push down on the touchpad, \n" +
            "you can change the direction that the\n" +
            "cannon turns.";
        messages[4] = "Aim it in the direction of the \n" +
            "acorn and touch the red fuse on the back \n" +
            "of the cannon. Give it a try!";
        messages[5] = "What did you notice? Try a large \n" +
            "angle. Look, the cannon ball goes very \n" +
            "high in the air but doesn’t go very far.";
        messages[6] = "Try a smaller angle. What do \n" +
            "you notice? The cannon ball doesn’t go \n" +
            "very high but goes very far.";
        messages[7] = "As you can see, the angle you \n" +
            "shoot at will help determine how far \n" +
            "and high the cannon ball travels.";
        messages[8] = "Now that you know how to use the \n" +
            "cannon, you are ready to help me get the acorn. \n" +
            "Aim the cannon at the tree and experiment \n" +
            "with the angle to hit the acorn.";

        textBox.text = messages[count];
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ball")
        {
            if (count < 8)
            {
                count++;
                textBox.text = messages[count];
            }
            else
            {
                textBox.text = "";
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
