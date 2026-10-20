using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heightController : MonoBehaviour
{
    public HeightButton heightUp;
    public HeightButton heightDown;
    private float height;


    // Update is called once per frame
    void Update()
    {
        //takes the number for the top button and bottom and finds the differnece
        height = heightUp.height - heightDown.height;

        // if the height number does not go over the values then it
        if(height <= 1.5 && height >= -0.5)
        {
            // moves the camera up and down
            this.transform.position = new Vector3(this.transform.position.x, height, this.transform.position.z);
        }
    }
}
