using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public Transform player;

    public float currentTime;

    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI BoardText;

    public caseButton caseButton;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player, Vector3.up);

        if (caseButton.buttonPressed == false)
        {
            currentTime = currentTime += Time.deltaTime;
            ScoreText.text = currentTime.ToString("0.00");
        }

        if (caseButton.buttonPressed == true)
        {
            BoardText.text = "Good job, You can put on the headset to go back to the Menu and retry for a better Time!";

            ScoreText.text = currentTime.ToString("0.00");
            if(currentTime < 91)
            {
                ScoreText.color = Color.green;
                star5.GetComponent<MeshRenderer>().enabled = true;
                star4.GetComponent<MeshRenderer>().enabled = true;
                star3.GetComponent<MeshRenderer>().enabled = true;
                star2.GetComponent<MeshRenderer>().enabled = true;
                star1.GetComponent<MeshRenderer>().enabled = true;
            }
            if (currentTime >= 91 && currentTime < 121)
            {
                ScoreText.color = Color.green;
                star4.GetComponent<MeshRenderer>().enabled = true;
                star3.GetComponent<MeshRenderer>().enabled = true;
                star2.GetComponent<MeshRenderer>().enabled = true;
                star1.GetComponent<MeshRenderer>().enabled = true;
            }
            if (currentTime >= 121 && currentTime < 181)
            {
                ScoreText.color = Color.yellow;
                star3.GetComponent<MeshRenderer>().enabled = true;
                star2.GetComponent<MeshRenderer>().enabled = true;
                star1.GetComponent<MeshRenderer>().enabled = true;
            }
            if (currentTime >= 181 && currentTime < 241)
            {
                ScoreText.color = Color.yellow;
                star2.GetComponent<MeshRenderer>().enabled = true;
                star1.GetComponent<MeshRenderer>().enabled = true;
            }
            if (currentTime >= 241)
            {
                ScoreText.color = Color.red;
                star1.GetComponent<MeshRenderer>().enabled = true;
            }





        }

    }
}
