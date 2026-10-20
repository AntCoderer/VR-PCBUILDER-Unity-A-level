using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isMotherBoardColliding : MonoBehaviour
{
    public Collider motherBoard;
    public bool plateCollision = false;

    //runs once every time something collides with the object the script is on
    private void OnTriggerEnter(Collider other)
    {
        // checks if the object is the motherBoard
        if(other == motherBoard)
        {
            //changes tracking variable to true
            plateCollision = true;
            
        }
    }
    //runs once every time a collider leaves the object the script is on
    private void OnTriggerExit(Collider other)
    {
        // checks if the object is the motherBoard
        if (other == motherBoard)
        {
            //changes tracking variable to false
            plateCollision = false;
            
        }
    }
}
