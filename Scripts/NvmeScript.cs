using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NvmeScript : MonoBehaviour
{
    public AudioSource Click1;
    public Collider targetCollider;
    public Transform targetPosition;
    public bool NvmeInstalled = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other == targetCollider)
        {
            this.tag = "Untagged";
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.position = targetPosition.transform.position;
            this.transform.parent = GameObject.Find("motherBoardParent").transform;
            transform.localRotation = Quaternion.Euler(-90, 180, -180);
            NvmeInstalled = true;
            Click1.Play(0);
        }
    }

}
