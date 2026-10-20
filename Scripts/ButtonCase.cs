using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCase : MonoBehaviour
{
    public Collider LHandCollider;
    public Collider RHandCollider;
    public isMotherBoardColliding script;
    public GameObject Case;
    public Transform PlatePosition;
    public bool isCaseStuck = false;

    private bool isPressed = true;
    private bool isDonePlaceHolder = false;


    // Start is called before the first frame update
    void Start()
    {
        Case.tag = "Untagged";
        Rigidbody motherRigid = Case.GetComponent<Rigidbody>();
        motherRigid.isKinematic = true;
        Case.transform.position = PlatePosition.transform.position;
        Case.transform.rotation = Quaternion.Euler(0, 180, 0);
        isPressed = true;
        isCaseStuck = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other == LHandCollider || other == RHandCollider)
        {
            if (isDonePlaceHolder == true)
            {

                if (isPressed == false)
                {
                    if (script.plateCollision == true)
                    {
                        Case.tag = "Untagged";
                        Rigidbody motherRigid = Case.GetComponent<Rigidbody>();
                        motherRigid.isKinematic = true;
                        Case.transform.position = PlatePosition.transform.position;
                        Case.transform.rotation = Quaternion.Euler(0, 0, 0);
                        isPressed = true;
                        isCaseStuck = true;
                    }

                }
                else
                {

                    Rigidbody motherRigid = Case.GetComponent<Rigidbody>();
                    motherRigid.isKinematic = false;
                    Case.tag = "Component";
                    isPressed = false;
                    isCaseStuck = false;
                }
            }
        }
    }

}
