using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuFanButton : MonoBehaviour
{
    public Collider LHandCollider;
    public Collider RHandCollider;
    public GameObject Booth;
    public NvmeScript NvmeScript;
    public bool CpuFanButtonPressed = false;

    private bool IsOpening;


    private void OnTriggerEnter(Collider other)
    {
        // this is seing if the object colliding is one of the hands
        if (other == LHandCollider || other == RHandCollider)
        {
            if (NvmeScript.NvmeInstalled == true)
            {
                IsOpening = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (IsOpening == true && Booth.transform.position.y < 3.2f)
        {
            Booth.transform.Translate(Vector3.right * Time.deltaTime * 3);
        }

        if (Booth.transform.position.y > 3.2f)
        {
            CpuFanButtonPressed = true;
        }

    }

}
