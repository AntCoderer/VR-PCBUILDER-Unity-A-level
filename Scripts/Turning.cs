using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit; 

public class Turning : MonoBehaviour
{
    private Vector2 inputAxis;

    public XRNode inputSource;
    public float SensX = 2f;
    public Camera Camera;

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        transform.Rotate(Vector3.up, inputAxis.x * SensX);

        //Debug.Log(Camera.transform.localRotation.eulerAngles.y);



    }
}
