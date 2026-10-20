using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUScript : MonoBehaviour
{
    public AudioSource Click1;
    public Collider targetCollider;
    public Transform targetPosition;
    public MagicScrewDriverScript MagicScrew;

    // this is a tracking variable to be used in other scripts
    public bool GPUInstalled = false;

    // this running the code bellow when a collider that is a trigger enters the objects own collider
    private void OnTriggerEnter(Collider other)
    {
        // this is checking if the collider we are colliding with is the designated location
        if (other == targetCollider)
        {
            if (MagicScrew.PowerSupplyFullyInstalled == true)
            {
                // all code bellow is moving the current component to the MotherBoard
                // and makes sure that it wont move or be picked up
                this.tag = "Untagged";
                this.transform.position = targetPosition.transform.position;
                this.transform.parent = GameObject.Find("motherBoardParent").transform;
                transform.localRotation = Quaternion.Euler(0, 0, 180);
                GPUInstalled = true;
                this.GetComponent<Rigidbody>().isKinematic = true;
                Click1.Play(0);
                PositionChange();
            }
        }
    }
    private void PositionChange()
    {
        this.transform.position = targetPosition.transform.position;
        this.transform.parent = GameObject.Find("motherBoardParent").transform;
        transform.localRotation = Quaternion.Euler(0, 0, 180);
    }

}
