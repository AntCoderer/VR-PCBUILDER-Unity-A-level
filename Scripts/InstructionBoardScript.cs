using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionBoardScript : MonoBehaviour
{
    public Transform player;

    //These variables are used to refer to the bool variables in the other scripts
    public CpuScript CPUScript;
    public BoothMover cpuButton;
    public ramButton ramButton;
    public RamScript ramscript;
    public RamScript ramscript2;
    public NvmeButton nvmeButton;
    public NvmeScript NvmeScript;
    public CpuFanButton CpuFanButton;
    public CpuFanScript CpuFanScript;
    public ScrewDriverButton ScrewDriverButton;
    public MagicScrewDriverScript MagicScrewDriverScript;
    public ButtonMotherBoard ButtonMotherBoard;
    public motherBoardScript MotherBoardScript;
    public HddButton HddButton;
    public HddScript HddScript;
    public PowerSupplyButton PowerSupplyButton;
    public PowerSupplyScript PowerSupplyScript;
    public GpuButton GpuButton;
    public GPUScript GPUScript;
    public FanButton FanButton;
    public FanScript FanScript1;
    public FanScript FanScript2;
    public FanScript FanScript3;
    public caseButton caseButton;

    // these are used to change the material of the booths and buttons to make them glow
    public Material gold;
    public Material brown;
    public Material glowRed;
    public Material red;

    // to reference and make the booths glow
    public GameObject booth1;
    public GameObject booth2;
    public GameObject booth3;
    public GameObject booth4;
    public GameObject booth5;
    public GameObject booth6;
    public GameObject booth7;
    public GameObject booth8;
    public GameObject booth9;

    // to reference and make the buttons glow
    public GameObject button;
    public GameObject button2;

    // These are the glowing objects that surround the parts
    public GameObject cpuGlow;
    public GameObject ram1Glow;
    public GameObject ram2Glow;
    public GameObject nvmeGlow;
    public GameObject cpuFanGlow;
    public GameObject motherGlow;
    public GameObject HDDGlow;
    public GameObject PWGlow;
    public GameObject GPUGlow;
    public GameObject fanGlow;
    
    // this is used to reference the the actual text on the board
    [SerializeField] private TextMeshProUGUI BoardText;
    [SerializeField] private TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //sets the board text to the starting text to tell players to fetch the cpu
        BoardText.text = "Welcome, on the table you should see a green motherboard. This is like your PC's hub and most things on the computer must pass through here to get to its destination. Now when your ready co collect the CPU from the booth highlighted Gold and come back with it.";
        //highlights the booth so the player knows where to go
        booth1.GetComponent<MeshRenderer>().material = gold;
    }

    // Update is called once per frames
    void Update()
    {
        // makes the board face the players camera
        transform.LookAt(player, Vector3.up);

        // checks if the cpu booth has been opened
        if (cpuButton.cpuButtonPressed == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Now put the CPU into the CPU socket which is highlighted. Make sure to always get the correct rotation by checking that the yellow triangle on the CPU and the triangle on the Motherboard matches up. Most motherBoards will come with a lever that you must flip back to reveal the socket then flip it back to secure the cpu in place.";
            //turns off the booths highlight and turns on the components highlight
            booth1.GetComponent<MeshRenderer>().material = brown;
            cpuGlow.GetComponent<MeshRenderer>().enabled = true;
        }

        if (CPUScript.CpuInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Now you have installed the CPU you will need your main memory, go get the ram over at the Component booths";
            //turns on booth highlight and turns off the component highlight
            booth2.GetComponent<MeshRenderer>().material = gold;
            cpuGlow.GetComponent<MeshRenderer>().enabled = false;
        }
        // checks if the ram booth has been opened
        if (ramButton.ramButtonPressed == true)
        {
            //changes the board text to next instruction
            BoardText.text = "When installing Ram make sure to get the right orientation, this can be done by matching the notch in the Ram to the divider in the socket. All you have to do is line it up and push it in, sometimes your will have to push back a tab either on one or both sides.";
            //turns off the booths highlight and turns on the components highlight
            booth2.GetComponent<MeshRenderer>().material = brown;
            ram1Glow.GetComponent<MeshRenderer>().enabled = true;
            ram2Glow.GetComponent<MeshRenderer>().enabled = true;
        }

        if (ramscript.Pos1Filled == true || ramscript.Pos3Filled == true)
        {
            if (ramscript2.Pos1Filled == true || ramscript2.Pos3Filled == true)
            {
                //changes the board text to next instruction
                BoardText.text = "The next thing to go on the motherboard will be secondary memory or the NVME, you can find it at the componet booth highlighted.";
                //turns on booth highlight and turns off the component highlight
                booth3.GetComponent<MeshRenderer>().material = gold;
                ram1Glow.GetComponent<MeshRenderer>().enabled = false;
                ram2Glow.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        // checks if the nvme booth has been opened
        if (nvmeButton.nvmeButtonPressed == true)
        {
            //changes the board text to next instruction
            BoardText.text = "With most NVME's you would have first put a female screw in then the NVME then a male screw in the female to secure the NVME. You can see the red screw holes on the Board but for our one you just have to slot it in.";
            //turns off the booths highlight and turns on the components highlight
            booth3.GetComponent<MeshRenderer>().material = brown;
            nvmeGlow.GetComponent<MeshRenderer>().enabled = true;
        }

        if(NvmeScript.NvmeInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Now we have put all the componets onto the motherboard we can, lets go put the CPU fan on.";
            //turns on booth highlight and turns off the component highlight
            booth4.GetComponent<MeshRenderer>().material = gold;
            nvmeGlow.GetComponent<MeshRenderer>().enabled = false;
        }
        // checks if the cpu fan booth has been opened
        if (CpuFanButton.CpuFanButtonPressed == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Place the Fan gentlty on top of the cpu making sure to get the right orientation, this is important as the thermal paste will get spread between the CPU and plate and removing and retrying will reduce the CPU's effectiveness.";
            //turns off the booths highlight and turns on the components highlight
            booth4.GetComponent<MeshRenderer>().material = brown;
            cpuFanGlow.GetComponent<MeshRenderer>().enabled = true;
        }
        if(CpuFanScript.CpuFanInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "After placing the fan in the correct orientation its time to screw it in.";
            //turns on booth highlight and turns off the component highlight
            booth5.GetComponent<MeshRenderer>().material = gold;
            cpuFanGlow.GetComponent<MeshRenderer>().enabled = false;
        }
        // checks if the screwdriver booth has been opened
        if (ScrewDriverButton.ScrewDriverButtonPressed == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Now all you have to do is screw in a screw in all highlighted holes, Remember to NOT LOSE THE SCREWDRIVER.";
            //turns off the booths highlight and turns on the screw highlights
            booth5.GetComponent<MeshRenderer>().material = brown;
            GameObject[] cpuFanScrewGlow;
            cpuFanScrewGlow = GameObject.FindGameObjectsWithTag("cpuFanScrewGlow");
            foreach (GameObject glow in cpuFanScrewGlow)
            {
                glow.GetComponent<MeshRenderer>().enabled = true;
            }
            ScoreText.text = "You Have " + MagicScrewDriverScript.cpuFanCount.ToString() +"/4 Screws In";

        }
        if(MagicScrewDriverScript.cpuFanFullyInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Perfect, thats the motherboard done, now all you have to do is press the button to unstick the motherboard, this can be done by hitting the red button to the left of the motherboard.";
            //turns off screw highlights turns on button highlights
            button.GetComponent<MeshRenderer>().material = glowRed;
            GameObject[] cpuFanScrewGlow;
            cpuFanScrewGlow = GameObject.FindGameObjectsWithTag("cpuFanScrewGlow");
            foreach (GameObject glow in cpuFanScrewGlow)
            {
                glow.GetComponent<MeshRenderer>().enabled = false;
            }
            ScoreText.text = "";
        }
        if(ButtonMotherBoard.isMotherBoardStuck == false)
        {
            //changes the board text to next instruction
            BoardText.text = "Good, now place the motherboard into the case making sure to line the i/o sheild up with the corresponding hole aswell as any screw holes you may see.";
            //turns off the buttons highlight and turns on the comonents highlight
            button.GetComponent<MeshRenderer>().material = red;
            motherGlow.GetComponent<MeshRenderer>().enabled = true;
        }
        if(MotherBoardScript.MotherBoardInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Now the motherboard's in place you must screw in the 8 corresponding screws into the highlighted holes. Remember that your motherboard may have more or less holes in different places.";
            //turns on screw highlights and turns off the component highlight
            motherGlow.GetComponent<MeshRenderer>().enabled = false;
            GameObject[] motherScrewGlow;
            motherScrewGlow = GameObject.FindGameObjectsWithTag("motherScrewGlow");
            foreach (GameObject glow in motherScrewGlow)
            {
                glow.GetComponent<MeshRenderer>().enabled = true;
            }
            ScoreText.text = "You Have " + MagicScrewDriverScript.motherBoardCount.ToString() + "/8 Screws In";
        }
        if(MagicScrewDriverScript.motherBoardFullyInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Now the motherboard fully installed let's put the final componets in starting with the Hard Drive.";
            //turns off screw highlights and turns on the booth highlight
            booth6.GetComponent<MeshRenderer>().material = gold;
            GameObject[] motherScrewGlow;
            motherScrewGlow = GameObject.FindGameObjectsWithTag("motherScrewGlow");
            foreach (GameObject glow in motherScrewGlow)
            {
                glow.GetComponent<MeshRenderer>().enabled = false;
            }
            ScoreText.text = "";
        }
        // checks if the hdd booth has been opened
        if (HddButton.HddButtonPressed == true)
        {
            //changes the board text to next instruction
            BoardText.text = "For the HDD just slot the HHD and slider into the bottom slot on the other side of the case. Remember to put the sata slot facing outward for the wiring later";
            //turns off the booths highlight and turns on the components highlight
            booth6.GetComponent<MeshRenderer>().material = brown;
            HDDGlow.GetComponent<MeshRenderer>().enabled = true;
        }
        if(HddScript.HddInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Next we have the Power Supply, go get it from the component booths.";
            //turns on booth highlight and turns off the component highlight
            booth7.GetComponent<MeshRenderer>().material = gold;
            HDDGlow.GetComponent<MeshRenderer>().enabled = false;
        }
        // checks if the power supply booth has been opened
        if (PowerSupplyButton.PowerSupplyButtonPressed == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Put the Power Supply into the slot to the right of the HDD, remember to have the fab pointed down and the switch should come out the side of the case. There are other orientations for the PW Supply but they are for certain pc builds.";
            //turns off the booths highlight and turns on the components highlight
            booth7.GetComponent<MeshRenderer>().material = brown;
            PWGlow.GetComponent<MeshRenderer>().enabled = true;
        }
        if(PowerSupplyScript.PSInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Now get the screwdriver and screw in the 4 highlighted screw holes.";
            PWGlow.GetComponent<MeshRenderer>().enabled = false;
            GameObject[] PWScrewGlow;
            PWScrewGlow = GameObject.FindGameObjectsWithTag("PWScrewGlow");
            foreach (GameObject glow in PWScrewGlow)
            {
                glow.GetComponent<MeshRenderer>().enabled = true;
            }
            ScoreText.text = "You Have " + MagicScrewDriverScript.PWCount.ToString() + "/4 Screws In";
        }
        if (MagicScrewDriverScript.PowerSupplyFullyInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Normally by now you would have wired in many components and after the power supply you would plug in cables to the corresponding sockets, instead we will skip that and install the GPU and then go back after in a wiring mini-game.";
            booth8.GetComponent<MeshRenderer>().material = gold;
            GameObject[] PWScrewGlow;
            PWScrewGlow = GameObject.FindGameObjectsWithTag("PWScrewGlow");
            foreach (GameObject glow in PWScrewGlow)
            {
                glow.GetComponent<MeshRenderer>().enabled = false;
            }
            ScoreText.text = "";
        }
        // checks if the gpu booth has been opened
        if (GpuButton.GpuButtonPressed)
        {
            //changes the board text to next instruction
            BoardText.text = "Line up the GPU's chip with the socket of the motherboard, and press the GPU firmly into the socket. Remember that when installing the GPU to remove the side pannels where the gpu's i/o section will go.";
            //turns off the booths highlight and turns on the components highlight
            booth8.GetComponent<MeshRenderer>().material = brown;
            GPUGlow.GetComponent<MeshRenderer>().enabled = true;
        }
        if(GPUScript.GPUInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Nice, now before we close up the case lest install all three exterior fans.";
            booth9.GetComponent<MeshRenderer>().material = gold;
            GPUGlow.GetComponent<MeshRenderer>().enabled = false;
        }
        // checks if the fan booth has been opened
        if (FanButton.FanButtonPressed == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Put all three fans into the highlighted area.";
            //turns off the booths highlight and turns on the components highlight
            booth9.GetComponent<MeshRenderer>().material = brown;
            fanGlow.GetComponent<MeshRenderer>().enabled = true;
        }
        if(FanScript1.fanInstalled == true && FanScript2.fanInstalled == true && FanScript3.fanInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Now you have put the fans in place its time to screw in 4 screws for each fan.";
            fanGlow.GetComponent<MeshRenderer>().enabled = false;
            GameObject[] FanScrewGlow;
            FanScrewGlow = GameObject.FindGameObjectsWithTag("FanScrewGlow");
            foreach (GameObject glow in FanScrewGlow)
            {
                glow.GetComponent<MeshRenderer>().enabled = true;
            }
            ScoreText.text = "You Have " + MagicScrewDriverScript.FanCount.ToString() + "/12 Screws In";
        }
        if(MagicScrewDriverScript.Fan1FullyInstalled == true && MagicScrewDriverScript.Fan2FullyInstalled == true && MagicScrewDriverScript.Fan3FullyInstalled == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Perfect now press the red buttom to the right of the case which is glowing.";
            button2.GetComponent<MeshRenderer>().material = glowRed;
            GameObject[] FanScrewGlow;
            FanScrewGlow = GameObject.FindGameObjectsWithTag("FanScrewGlow");
            foreach (GameObject glow in FanScrewGlow)
            {
                glow.GetComponent<MeshRenderer>().enabled = false;
            }
            ScoreText.text = "";
        }
        if(caseButton.buttonPressed == true)
        {
            //changes the board text to next instruction
            BoardText.text = "Well done, you have made your PC now whenever you are ready put on the VR Headset and it will take you back to the menu. Make sure to play the Wire mini-game to get a full understanding of PC building. ";
            button2.GetComponent<MeshRenderer>().material = red;
        }
    }
}
