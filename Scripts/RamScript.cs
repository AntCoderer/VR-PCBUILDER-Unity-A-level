using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamScript : MonoBehaviour
{
    public AudioSource Click1;
    public Collider Pos1Col;
    public Collider Pos3Col;
    public bool Pos1Filled = false;
    public bool Pos3Filled = false;
    public Transform Pos1Dest;
    public Transform Pos3Dest;
    public RamScript script;


    private void OnTriggerEnter(Collider other)
    {
        // checks if the collider the ram is colliding with is the first position
        if (other == Pos1Col)
        {
            // checks that the position its trying to enter is not filled and that the current stick should not be filling somewhere else
            if (script.Pos1Filled == false && Pos3Filled == false)
            {
                // all code bellow is moving the current component to the MotherBoard
                // and makes sure that it wont move or be picked up
                Pos1Filled = true;
                this.tag = "Untagged";
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.position = Pos1Dest.transform.position;
                this.transform.parent = GameObject.Find("motherBoardParent").transform;
                transform.localRotation = Quaternion.Euler(-90, 90, 180);
                Click1.Play(0);

            }

        }
        //same as above just with other ram position
        if (other == Pos3Col)
        {
            if (script.Pos3Filled == false && Pos1Filled == false)
            {
                // all code bellow is moving the current component to the MotherBoard
                // and makes sure that it wont move or be picked up
                Pos3Filled = true;
                this.tag = "Untagged";
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.position = Pos3Dest.transform.position;
                this.transform.parent = GameObject.Find("motherBoardParent").transform;
                transform.localRotation = Quaternion.Euler(-90, 90, 180);
                Click1.Play(0);
            }
        }
    }

}
