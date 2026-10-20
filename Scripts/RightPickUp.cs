using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class RightPickUp : MonoBehaviour
{
    private float GripInput;

    public bool isGrabbing = false;

    public XRNode inputSource;
    public Transform RDestination;

    // this is called every frame for every collider that is touching the hands trigger
    private void OnTriggerStay(Collider other)
    {
        // this is checking the tag of the object colliding to see if its an object thats allowed to be picked up
        if (other.CompareTag("Component"))
        {
            // this is checking if the player is pressing the grip button and that they are not holding anything else
            // also checks to see if the component is meant to be attached to another component
            if (GripInput > 0.7f && isGrabbing == false && other.CompareTag("Component"))
            {
                //this is showing that the player is currently holding something
                isGrabbing = true;
                //turns off the componets gravity
                other.GetComponent<Rigidbody>().isKinematic = true;
                //parents the object to the hand so it moves with the hand
                other.transform.parent = GameObject.Find("RightHand Controller").transform;

            }
            //checks if the player is letting go off the component
            if (GripInput <= 0.1f && other.CompareTag("Component"))
            {
                //turns the object back to normal
                other.GetComponent<Rigidbody>().isKinematic = false;
                other.transform.parent = GameObject.Find("Components").transform;
                //allows the player to pick up a new object
                isGrabbing = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // this is giving the device variable the data of a certain vr input device that can be set in the editor
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        // this is trying to get the value of the grip button on the selected controller
        // and takes that data and stores it in GripInput
        device.TryGetFeatureValue(CommonUsages.grip, out GripInput);
    }
}
