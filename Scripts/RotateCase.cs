using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCase : MonoBehaviour
{
    public Collider LHandCollider;
    public Collider RHandCollider;
    public ButtonCase ButtonCase;
    public GameObject Case;
    public Transform PlatePosition;
    public bool isCaseStuck = true;


    private void Start()
    {
        Case.tag = "Untagged";
        Rigidbody motherRigid = Case.GetComponent<Rigidbody>();
        motherRigid.isKinematic = true;
        Case.transform.position = PlatePosition.transform.position;
        Case.transform.rotation = Quaternion.Euler(0, 180, 0);
        isCaseStuck = true;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other == LHandCollider || other == RHandCollider)
        {
            if (isCaseStuck == true)
            {
                Case.transform.rotation *= Quaternion.Euler(0, 90, 0);
            }

        }
    }

}
