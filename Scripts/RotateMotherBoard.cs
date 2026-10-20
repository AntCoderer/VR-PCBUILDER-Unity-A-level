using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMotherBoard : MonoBehaviour
{
    public Collider LHandCollider;
    public Collider RHandCollider;

    public ButtonMotherBoard ButtonMotherBoard;
    public GameObject MotherBoard;

    
    //runs once every time something collides with the object the script is on
    private void OnTriggerEnter(Collider other)
    {
        // this is seing if the object colliding is one of the hands
        if (other == LHandCollider || other == RHandCollider)
        {
            // this checks if the motehrboard is stuck in position
            if (ButtonMotherBoard.isMotherBoardStuck == true)
            {
                // this turns the motherboard 90 degrees
                MotherBoard.transform.rotation *= Quaternion.Euler(0, 90, 0);
            }

        }
    }

}
