 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HddScript : MonoBehaviour
{
    public AudioSource Click1;
    public Collider targetCollider;
    public Transform targetPosition;
    public motherBoardScript MotherBoard;

    // this is a tracking variable to be used in other scripts
    public bool HddInstalled = false;

    // this running the code bellow when a collider that is a trigger enters the objects own collider
    private void OnTriggerEnter(Collider other)
    {
        // this is checking if the collider we are colliding with is the ddesignated location
        if (other == targetCollider)
        {
            // this is checking if the motherBoard is installed
            if (MotherBoard.MotherBoardInstalled == true)
            {
                // all code bellow is moving the current component to the Case
                // and makes sure that it wont move or be picked up
                this.tag = "Untagged";
                this.transform.position = targetPosition.transform.position;
                this.transform.parent = GameObject.Find("CaseParent").transform;
                transform.localRotation = Quaternion.Euler(-90, 180, 0);
                HddInstalled = true;
                this.GetComponent<Rigidbody>().isKinematic = true;
                Click1.Play(0);
            }
        }
    }

}
