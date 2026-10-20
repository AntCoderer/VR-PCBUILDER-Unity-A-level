using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HeightButton : MonoBehaviour
{
    public Collider LHandCollider;
    public Collider RHandCollider;
    public Collider LHandLaser;
    public Collider RHandLaser;

    private bool TriggerValue;
    private bool TriggerValue2;
    public XRNode inputSource;
    public XRNode inputSource2;

    private bool adding = false;
    public float height = 0f;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(TriggerValue);
        // this is seing if the object colliding is one of the hands
        if ((other == LHandCollider || other == RHandCollider)&& adding == false)
        {
            adding = true;
            StartCoroutine(AddHeight());
            
        }
        if ((other == LHandLaser && TriggerValue == true || other == RHandLaser && TriggerValue2 == true) && adding == false )
        {
            adding = true;
            StartCoroutine(AddHeight());
            Debug.Log(other);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // this is giving the device variable the data of a certain vr input device that can be set in the editor
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        InputDevice device2 = InputDevices.GetDeviceAtXRNode(inputSource2);

        // this is trying to get the value of the grip button on the selected controller
        // and takes that data and stores it in GripInput
        device.TryGetFeatureValue(CommonUsages.triggerButton, out TriggerValue);

        device2.TryGetFeatureValue(CommonUsages.triggerButton, out TriggerValue2);
    }

    IEnumerator AddHeight()
    {
        // adds to the plus/minus of the players height
        height = height + 0.1f;
        //waits time some time so that when pressing the button it doesnt instantly make the player the max height
        yield return new WaitForSeconds(0.3f);
        //allows the player to press the button again
        adding = false;
       
    }
}
