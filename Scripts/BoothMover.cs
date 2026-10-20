using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothMover : MonoBehaviour
{
    //To detect when the hand toches button
    public Collider LHandCollider;
    public Collider RHandCollider;
    //To move the booth
    public GameObject Booth;
    //To see when the booth has moved (used in other script)
    public bool cpuButtonPressed = false;

    //used to move the door graduly up instead of using animation
    private bool IsOpening;

    //called once every time an object with a trigger collider collides with the button
    private void OnTriggerEnter(Collider other)
    {
        // this is seing if the object colliding is one of the hands
        if (other == LHandCollider || other == RHandCollider)
        {
            //set is opening to true to be used in update function
            IsOpening = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if the button is pressed and the button has not moved past maximum distance
        if (IsOpening == true && Booth.transform.position.y < 3.2f)
        {
            //move the booth right over time (this actualy moves the booth up but the rotaion of the both means it='s right)
            Booth.transform.Translate(Vector3.right * Time.deltaTime * 3);
        }

        if(Booth.transform.position.y > 3.2f)
        {
            // used for tracking when the booth has been opened.
            cpuButtonPressed = true;
        }
    }
}

