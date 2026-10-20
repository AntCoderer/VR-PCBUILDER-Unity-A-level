using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialButton : MonoBehaviour
{
    public Collider LHandCollider;
    public Collider RHandCollider;
    public Collider LHandLaser;
    public Collider RHandLaser;

    private bool TriggerValue;
    private bool TriggerValue2;
    public XRNode inputSource;
    public XRNode inputSource2;

    private void OnTriggerStay(Collider other)
    {
        // this is seing if the object colliding is one of the hands
        if (other == LHandCollider || other == RHandCollider )
        {
            // this is loading the 2rd scene which is the tutorial
            SceneManager.LoadScene(1);
        }
        if(other == LHandLaser && TriggerValue == true || other == RHandLaser && TriggerValue2 == true)
        {
            // this is loading the 2rd scene which is the tutorial
            SceneManager.LoadScene(1);
        }
    }
    private void Update()
    {
        // this is giving the device variable the data of a certain vr input device that can be set in the editor
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        InputDevice device2 = InputDevices.GetDeviceAtXRNode(inputSource2);

        // this is trying to get the value of the grip button on the selected controller
        // and takes that data and stores it in GripInput
        device.TryGetFeatureValue(CommonUsages.triggerButton, out TriggerValue);

        device2.TryGetFeatureValue(CommonUsages.triggerButton, out TriggerValue2);
    }
}
