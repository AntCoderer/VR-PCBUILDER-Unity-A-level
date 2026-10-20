using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motherBoardScript : MonoBehaviour
{
    public AudioSource Click1;
    public Collider targetCollider;
    public Transform targetPosition;
    public MagicScrewDriverScript ScrewDriver;
    public RamScript ramScript1;
    public RamScript ramScript2;
    public NvmeScript NvmeScript;

    // this is a tracking variable to be used in other scripts
    public bool MotherBoardInstalled = false;

    // this running the code bellow when a collider that is a trigger enters the objects own collider
    private void OnTriggerEnter(Collider other)
    {
        // this is checking if the collider we are colliding with is the designated location
        if (other == targetCollider)
        {
            if(NvmeScript.NvmeInstalled == true && ScrewDriver.cpuFanFullyInstalled)
            {
                if(ramScript1.Pos1Filled == true || ramScript1.Pos3Filled == true)
                {
                    if (ramScript2.Pos1Filled == true || ramScript2.Pos3Filled == true)
                    {
                     
                        // all code bellow is moving the current component is put in the right place
                        // and makes sure that it wont move or be picked up
                        MotherBoardInstalled = true;
                        this.tag = "Untagged";
                        this.GetComponent<Rigidbody>().isKinematic = true;
                        this.transform.position = targetPosition.transform.position;
                        transform.localRotation = Quaternion.Euler(90, 0, 0);
                        this.transform.parent = GameObject.Find("CaseParent").transform;
                        Click1.Play(0);
                    }
                }
            }
        }
    }
}
