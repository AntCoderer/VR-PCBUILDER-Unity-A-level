using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caseButton : MonoBehaviour
{
    public Collider LHandCollider;
    public Collider RHandCollider;
    public MagicScrewDriverScript screwDriverScript;
    public GPUScript GPUScript;
    public bool buttonPressed;
    public MeshRenderer glass;
    public MeshRenderer Fglass;
    public MeshRenderer backPanel;

    public MeshRenderer Monitor;
    public GameObject VRheadset;
    public MeshRenderer Headset;
    public CapsuleCollider VRcollider;
    public SkinnedMeshRenderer cable1;
    


    // Start is called before the first frame update
    void Start()
    {
        buttonPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // this is seing if the object colliding is one of the hands
        if (other == LHandCollider || other == RHandCollider)
        {
            if (screwDriverScript.Fan1FullyInstalled == true && screwDriverScript.Fan2FullyInstalled == true && screwDriverScript.Fan3FullyInstalled == true && GPUScript.GPUInstalled == true && buttonPressed == false)
            {
                buttonPressed = true;
                glass.enabled = true;
                Fglass.enabled = true;
                backPanel.enabled = true;
                Monitor.enabled = true;
                VRheadset.tag = "Component";
                Headset.enabled = true;
                VRcollider.enabled = true;
                cable1.enabled = true;

            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
