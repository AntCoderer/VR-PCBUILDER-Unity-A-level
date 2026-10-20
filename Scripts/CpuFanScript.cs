using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuFanScript : MonoBehaviour
{
    public AudioSource Click1;
    public Collider targetCollider;
    public Transform targetPosition;
    public CpuScript CpuScript;
    public bool CpuFanInstalled = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other == targetCollider)
        {
            if (CpuScript.CpuInstalled == true)
            {
                this.tag = "Untagged";
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.position = targetPosition.transform.position;
                this.transform.parent = GameObject.Find("motherBoardParent").transform;
                transform.localRotation = Quaternion.Euler(-90, 0, 0);
                CpuFanInstalled = true;
                Click1.Play(0);
            }
        }
    }



}
