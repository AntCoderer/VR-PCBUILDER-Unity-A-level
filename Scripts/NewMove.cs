using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class NewMove : MonoBehaviour
{
    private Vector2 inputAxis;
    private XROrigin rig;

    public CharacterController character;
    public XRNode inputSource;
    public float speedy = 10f;
    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // this is giving the rig variable the data of the XROrigin
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        // This is creating a sphere at the groundcheck's position with a radius of groundDistance
        // isGrounded will be set to true if any object enters this sphere with the the groundMask mask
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // this will then check if we are on the floor(isGrounded) and if we are falling or not
        // if these are true then it will make sure are velocity does not start climing even if we are not falling
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // this is giving the device variable the data of a certain vr input device that can be set in the editor
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        // this is trying to get the value of the joystick on the selected controller
        // and takes that data and stores it in inputAxis
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        // gravity
        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //this is just finding the angle the head is turing at and putting that data into the headYaw variable
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);

        // this is creating a direction to move in based on where the JoyStick is positioned
        // multiplying by the head yaw will make sure the player moves in the the direction they are facing
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        // then the Move funtion on the character controller is used to move in the direction specified
        // speedy allows ulteration of speed and time makes movement framrate independent
        character.Move(direction * Time.fixedDeltaTime * speedy);
    }
}
