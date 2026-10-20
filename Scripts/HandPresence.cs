using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice;
    private GameObject spawnedHandModel;
    private Animator HandAnimator;

    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialise();
    }

    // the initialise function is essetial whenever using vr,
    // when calling for vr componets if done in start() controllers not yet plugged in would not be analysed
    // this would mean any script using them would not work
    // initialise will check until the required conponents are active then get the info needed
    void TryInitialise()
    {
        // gives the devices list a list of the controllers characteristics(button outputs)
        List<InputDevice> devices = new List<InputDevice>();
        
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);


        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            HandAnimator = spawnedHandModel.GetComponent<Animator>();
        }

    }

    void UpdateHandAnimation()
    {
        // this will check if the controller has a trigger button and if it does not it will set the trigger animation to 0 (default animation)
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger,out float triggerValue))
        {
            HandAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            HandAnimator.SetFloat("Trigger", 0);
        }
        // this will check if the controller has a grip button and if it does not it will set the grip animation to 0 (default animation)
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            HandAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            HandAnimator.SetFloat("Grip", 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //will check if our device has been activated and if not will it will try to initialise again
        if (!targetDevice.isValid)
        {
            TryInitialise();
        }
        else
        {
            spawnedHandModel.SetActive(true);
            UpdateHandAnimation();
        }

        
    }
}
