using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMotherBoard : MonoBehaviour
{
    public Collider LHandCollider;
    public Collider RHandCollider;
    public GameObject MotherBoard;
    public Transform PlatePosition;
    public bool isMotherBoardStuck = true;
    public MagicScrewDriverScript ScrewDriverScript;





    private void Start()
    {
        // this makes it so the motherboard cannot move or be picked up
        // also locks it in place so it can be worked on
        MotherBoard.tag = "Untagged";
        Rigidbody motherRigid = MotherBoard.GetComponent<Rigidbody>();
        motherRigid.isKinematic = true;
        MotherBoard.transform.position = PlatePosition.transform.position;
        MotherBoard.transform.rotation = Quaternion.Euler(0, 0, 0);
        isMotherBoardStuck = true;
    }

    //runs once every time something collides with the object the script is on
    private void OnTriggerEnter(Collider other)
    {
        // this is seing if the object colliding is one of the hands
        if (other == LHandCollider || other == RHandCollider)
        {
            if(ScrewDriverScript.cpuFanFullyInstalled == true)
            {
                // this reverses all changes made above
                Rigidbody motherRigid = MotherBoard.GetComponent<Rigidbody>();
                motherRigid.isKinematic = false;
                MotherBoard.tag = "Component";
                isMotherBoardStuck = false;
            }
        }
    }

}
