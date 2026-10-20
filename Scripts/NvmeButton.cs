using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NvmeButton : MonoBehaviour
{
    public Collider LHandCollider;
    public Collider RHandCollider;
    public GameObject Booth;
    public RamScript ramscript;
    public RamScript ramscript2;
    public bool nvmeButtonPressed = false;

    private bool IsOpening;


    private void OnTriggerEnter(Collider other)
    {
        // this is seing if the object colliding is one of the hands
        if (other == LHandCollider || other == RHandCollider)
        {
            if (ramscript.Pos1Filled == true || ramscript.Pos3Filled == true)
            {
                if (ramscript2.Pos1Filled == true || ramscript2.Pos3Filled == true)
                {
                    IsOpening = true;
                }
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
            
            nvmeButtonPressed = true;
        }
    }
}
