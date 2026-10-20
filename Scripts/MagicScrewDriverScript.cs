using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MagicScrewDriverScript : MonoBehaviour
{
    public AudioSource screw;

    private bool TriggerValueLeft;
    private bool TriggerValueRight;

    // to check if the obeject being screwed in is installed yet
    public CpuFanScript CpuFanScript;
    public motherBoardScript MotherBoardScript;
    public FanScript fan1;
    public FanScript fan2;
    public FanScript fan3;
    public PowerSupplyScript PowerSupply;

    public XRNode inputSource;
    public XRNode inputSource1;



    public LeftPickUp leftPickUp;
    public RightPickUp rightPickUp;

    public int cpuFanCount = 0;
    public int motherBoardCount = 0;
    public int PWCount = 0;
    public int FanCount = 0;


    // collider Variables are used to detect when the screw driver is in contact with screws

    // mesh render variables are used to turn on the renderer of the screw

    public GameObject CpuFanScrew1;
    public Collider CpuFanScrew2;
    public Collider CpuFanScrew3;
    public Collider CpuFanScrew4;

    public MeshRenderer CpuFanRen1;
    public MeshRenderer CpuFanRen2;
    public MeshRenderer CpuFanRen3;
    public MeshRenderer CpuFanRen4;

    public Collider MotherScrew1;
    public Collider MotherScrew2;
    public Collider MotherScrew3;
    public Collider MotherScrew4;
    public Collider MotherScrew5;
    public Collider MotherScrew6;
    public Collider MotherScrew7;
    public Collider MotherScrew8;

    public MeshRenderer MotherRen1;
    public MeshRenderer MotherRen2;
    public MeshRenderer MotherRen3;
    public MeshRenderer MotherRen4;
    public MeshRenderer MotherRen5;
    public MeshRenderer MotherRen6;
    public MeshRenderer MotherRen7;
    public MeshRenderer MotherRen8;

    public Collider Fan1Col1;
    public Collider Fan1Col2;
    public Collider Fan1Col3;
    public Collider Fan1Col4;

    public MeshRenderer Fan1Ren1;
    public MeshRenderer Fan1Ren2;
    public MeshRenderer Fan1Ren3;
    public MeshRenderer Fan1Ren4;

    public Collider Fan2Col1;
    public Collider Fan2Col2;
    public Collider Fan2Col3;
    public Collider Fan2Col4;

    public MeshRenderer Fan2Ren1;
    public MeshRenderer Fan2Ren2;
    public MeshRenderer Fan2Ren3;
    public MeshRenderer Fan2Ren4;

    public Collider Fan3Col1;
    public Collider Fan3Col2;
    public Collider Fan3Col3;
    public Collider Fan3Col4;

    public MeshRenderer Fan3Ren1;
    public MeshRenderer Fan3Ren2;
    public MeshRenderer Fan3Ren3;
    public MeshRenderer Fan3Ren4;

    public Collider PSCol1;
    public Collider PSCol2;
    public Collider PSCol3;
    public Collider PSCol4;

    public MeshRenderer PSMesh1;
    public MeshRenderer PSMesh2;
    public MeshRenderer PSMesh3;
    public MeshRenderer PSMesh4;



    // tracking variables for the instalation of certain parts

    public bool cpuFanFullyInstalled = false;
    public bool motherBoardFullyInstalled = false;
    public bool Fan1FullyInstalled = false;
    public bool Fan2FullyInstalled = false;
    public bool Fan3FullyInstalled = false;
    public bool PowerSupplyFullyInstalled = false;

    // runs code bellow when the collider of the current object collides with another
    private void OnTriggerStay(Collider other)
    {
        
        //checks to see if the player is trying to screw something in
        if ((TriggerValueLeft == true && leftPickUp.isGrabbing == true) || (TriggerValueRight == true && rightPickUp.isGrabbing == true))
        {
 

            GameObject[] CpuFanScrews;
            CpuFanScrews = GameObject.FindGameObjectsWithTag("CpuFanScrews");
            foreach (GameObject screws in CpuFanScrews)
            {
                
                if (screws == other.gameObject && screws.GetComponent<MeshRenderer>().enabled == false)
                {
                    screws.GetComponent<MeshRenderer>().enabled = true;
                    cpuFanCount = cpuFanCount + 1;
                    screw.Play(0);
                }
            }


            /*
            // checks if the cpuFan is installed
            if (CpuFanScript.CpuFanInstalled == true)
            {
                // the rest of this is checking what screw its colliding with then turing its renderer on
                if (other == CpuFanScrew1 && CpuFanRen1.enabled != true)
                {
                    CpuFanRen1.enabled = true;
                    cpuFanCount = cpuFanCount + 1;
                    screw.Play(0);
                }

                if (other == CpuFanScrew2 && CpuFanRen2.enabled != true)
                {
                    CpuFanRen2.enabled = true;
                    cpuFanCount = cpuFanCount + 1;
                    screw.Play(0);
                }

                if (other == CpuFanScrew3 && CpuFanRen3.enabled != true)
                {
                    CpuFanRen3.enabled = true;
                    cpuFanCount = cpuFanCount + 1;
                    screw.Play(0);
                }

                if (other == CpuFanScrew4 && CpuFanRen4.enabled != true)
                {
                    CpuFanRen4.enabled = true;
                    cpuFanCount = cpuFanCount + 1;
                    screw.Play(0);
                }
            
            }
            */
            // checks if the motherboard is installed
            if (MotherBoardScript.MotherBoardInstalled == true)
            {
                // the rest of this is checking what screw its colliding with then turing its renderer on
                if (other == MotherScrew1 && MotherRen1.enabled != true)
                {
                    MotherRen1.enabled = true;
                    motherBoardCount = motherBoardCount + 1;
                    screw.Play(0);
                }
                if (other == MotherScrew2 && MotherRen2.enabled != true)
                {
                    MotherRen2.enabled = true;
                    motherBoardCount = motherBoardCount + 1;
                    screw.Play(0);
                }
                if (other == MotherScrew3 && MotherRen3.enabled != true)
                {
                    MotherRen3.enabled = true;
                    motherBoardCount = motherBoardCount + 1;
                    screw.Play(0);
                }
                if (other == MotherScrew4 && MotherRen4.enabled != true)
                {
                    MotherRen4.enabled = true;
                    motherBoardCount = motherBoardCount + 1;
                    screw.Play(0);
                }
                if (other == MotherScrew5 && MotherRen5.enabled != true)
                {
                    MotherRen5.enabled = true;
                    motherBoardCount = motherBoardCount + 1;
                    screw.Play(0);
                }
                if (other == MotherScrew6 && MotherRen6.enabled != true)
                {
                    MotherRen6.enabled = true;
                    motherBoardCount = motherBoardCount + 1;
                    screw.Play(0);
                }
                if (other == MotherScrew7 && MotherRen7.enabled != true)
                {
                    MotherRen7.enabled = true;
                    motherBoardCount = motherBoardCount + 1;
                    screw.Play(0);
                }
                if (other == MotherScrew8 && MotherRen8.enabled != true)
                {
                    MotherRen8.enabled = true;
                    motherBoardCount = motherBoardCount + 1;
                    screw.Play(0);
                }

            }

            // checks if first fan installed
            if (fan1.fanInstalled == true)
            {
                // the rest of this is checking what screw its colliding with then turing its renderer on
                if (other == Fan1Col1 && Fan1Ren1.enabled != true)
                {
                    Fan1Ren1.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
                if (other == Fan1Col2 && Fan1Ren2.enabled != true)
                {
                    Fan1Ren2.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
                if (other == Fan1Col3 && Fan1Ren3.enabled != true)
                {
                    Fan1Ren3.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
                if (other == Fan1Col4 && Fan1Ren4.enabled != true)
                {
                    Fan1Ren4.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
            }

            // checks if second fan installed
            if (fan2.fanInstalled == true)
            {
                // the rest of this is checking what screw its colliding with then turing its renderer on
                if (other == Fan2Col1 && Fan2Ren1.enabled != true)
                {
                    Fan2Ren1.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
                if (other == Fan2Col2 && Fan2Ren2.enabled != true)
                {
                    Fan2Ren2.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
                if (other == Fan2Col3 && Fan2Ren3.enabled != true)
                {
                    Fan2Ren3.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
                if (other == Fan2Col4 && Fan2Ren4.enabled != true)
                {
                    Fan2Ren4.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
            }

            // checks if third fan installed
            if (fan3.fanInstalled == true)
            {
                // the rest of this is checking what screw its colliding with then turing its renderer on
                if (other == Fan3Col1 && Fan3Ren1.enabled != true)
                {
                    Fan3Ren1.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
                if (other == Fan3Col2 && Fan3Ren2.enabled != true)
                {
                    Fan3Ren2.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
                if (other == Fan3Col3 && Fan3Ren3.enabled != true)
                {
                    Fan3Ren3.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
                if (other == Fan3Col4 && Fan3Ren4.enabled != true)
                {
                    Fan3Ren4.enabled = true;
                    FanCount = FanCount + 1;
                    screw.Play(0);
                }
            }

            if (PowerSupply.PSInstalled == true)
            {
                // the rest of this is checking what screw its colliding with then turing its renderer on
                if (other == PSCol1 && PSMesh1.enabled != true)
                {
                    PSMesh1.enabled = true;
                    PWCount = PWCount + 1;
                    screw.Play(0);
                }
                if (other == PSCol2 && PSMesh2.enabled != true)
                {
                    PSMesh2.enabled = true;
                    PWCount = PWCount + 1;
                    screw.Play(0);
                }
                if (other == PSCol3 && PSMesh3.enabled != true)
                {
                    PSMesh3.enabled = true;
                    PWCount = PWCount + 1;
                    screw.Play(0);
                }
                if (other == PSCol4 && PSMesh4.enabled != true)
                {
                    PSMesh4.enabled = true;
                    PWCount = PWCount + 1;
                    screw.Play(0);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        // this is giving the device variable the data of a certain vr input device that can be set in the editor
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        InputDevice device2 = InputDevices.GetDeviceAtXRNode(inputSource1);
        
        // this is trying to get the value of the grip button on the selected controller
        // and takes that data and stores it in GripInput 
        device.TryGetFeatureValue(CommonUsages.triggerButton, out TriggerValueLeft);
        device2.TryGetFeatureValue(CommonUsages.triggerButton, out TriggerValueRight);

        if (cpuFanCount == 4)
        {
            cpuFanFullyInstalled = true;
        }


        //this is setting a tracking variable to true if all needed screws are installed
        if (CpuFanRen1.enabled == true && CpuFanRen2.enabled == true && CpuFanRen3.enabled == true && CpuFanRen4.enabled == true)
        {
            cpuFanFullyInstalled = true;
        }

        //this is also setting a tracking variable to true if all needed screws are installed
        if (MotherRen1.enabled == true && MotherRen2.enabled == true && MotherRen3.enabled == true && MotherRen4.enabled == true && MotherRen5.enabled == true && MotherRen6.enabled == true && MotherRen7.enabled == true && MotherRen8.enabled == true)
        {
            motherBoardFullyInstalled = true;
        }

        //this is also setting a tracking variable to true if all needed screws are installed
        if (PSMesh1.enabled == true && PSMesh2.enabled == true && PSMesh3.enabled == true && PSMesh4.enabled == true )
        {
            PowerSupplyFullyInstalled = true;
        }

        //this is also setting a tracking variable to true if all needed screws are installed
        if (Fan1Ren1.enabled == true && Fan1Ren2.enabled == true && Fan1Ren3.enabled == true && Fan1Ren4.enabled == true)
        {
            Fan1FullyInstalled = true;
        }

        //this is also setting a tracking variable to true if all needed screws are installed
        if (Fan2Ren1.enabled == true && Fan2Ren2.enabled == true && Fan2Ren3.enabled == true && Fan2Ren4.enabled == true)
        {
            Fan2FullyInstalled = true;
        }

        //this is also setting a tracking variable to true if all needed screws are installed
        if (Fan3Ren1.enabled == true && Fan3Ren2.enabled == true && Fan3Ren3.enabled == true && Fan3Ren4.enabled == true)
        {
            Fan3FullyInstalled = true;
        }

    }
}
