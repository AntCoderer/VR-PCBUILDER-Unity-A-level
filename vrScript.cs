using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vrScript : MonoBehaviour
{
    //where the headset will be placed when put on
    public Transform facePos;
    //to see when the headset is colliding with the players head
    public Collider Face;

    private void OnTriggerEnter(Collider other)
    {
        // checks if the headset is colliding with the palyers head
        if(other == Face)
        {
            //this makes the it so the headset cannot be picked up
            this.tag = "Untagged";
            // this changes the position and roation of the headset to keep it on the head
            this.transform.position = facePos.transform.position;
            this.transform.parent = GameObject.Find("Main Camera").transform;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            // this stops the headset for falling due to gravity
            this.GetComponent<Rigidbody>().isKinematic = true;
            //this starts a external function
            StartCoroutine(OnCollisionWithObstacle());
        }
    }

    public IEnumerator OnCollisionWithObstacle()
    {
        //this waits for 3 seconds befor perfoming the next line of code
        yield return new WaitForSeconds(3);
        //this loads the menu scene
        SceneManager.LoadScene(0);
    }

}
