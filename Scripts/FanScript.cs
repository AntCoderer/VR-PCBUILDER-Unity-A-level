using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FanScript : MonoBehaviour
{
    public AudioSource Click1;
    // these are the colliders to detect if the fan is put in the right place
    public Collider Pos1Col;
    public Collider Pos2Col;
    public Collider Pos3Col;
    
    // these are to check if the position the fan is enetering is allready filled
    public bool Pos1Filled;
    public bool Pos2Filled;
    public bool Pos3Filled;

    // this is where the fan will be positioned
    public Transform Pos1Dest;
    public Transform Pos2Dest;
    public Transform Pos3Dest;

    // this is so the script can check if the other fans have filled another location
    public FanScript script1;
    public FanScript script2;

    public bool fanInstalled = false;

    private void OnTriggerEnter(Collider other)
    {
        // this checks if the fan is colliding with the first position
        if (other == Pos1Col)
        {
            // if so then it will check if one of the other fans are in that position or if the current fan should be in another position
            if (script1.Pos1Filled == false && script2.Pos1Filled == false && Pos2Filled == false && Pos3Filled == false)
            {
                // all code bellow is moving the current component to the Case
                // and makes sure that it wont move or be picked up
                fanInstalled = true;
                Pos1Filled = true;
                this.tag = "Untagged";
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.position = Pos1Dest.transform.position;
                
                transform.localRotation = Quaternion.Euler(0,-90, 0);
                Click1.Play(0);
                StartCoroutine(OnCollisionWithObstacle());
            }

        }

        // same as above but with the 2nd fan position
        if (other == Pos2Col)
        {
            if (script1.Pos2Filled == false && script2.Pos2Filled == false && Pos1Filled == false && Pos3Filled == false)
            {
                fanInstalled = true;
                Pos2Filled = true;
                this.tag = "Untagged";
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.position = Pos2Dest.transform.position;
                
                transform.localRotation = Quaternion.Euler(0,-90, 0);
                Click1.Play(0);
                StartCoroutine(OnCollisionWithObstacle());
            }

        }

        // same as above but with the 3rd fan position
        if (other == Pos3Col)
        {
            if (script1.Pos3Filled == false && script2.Pos3Filled == false && Pos1Filled == false && Pos2Filled == false)
            {
                fanInstalled = true;
                Pos3Filled = true;
                this.tag = "Untagged";
                this.transform.position = Pos3Dest.transform.position;
                
                transform.localRotation = Quaternion.Euler(0,-90, 0);
                this.GetComponent<Rigidbody>().isKinematic = true;
                Click1.Play(0);
                StartCoroutine(OnCollisionWithObstacle());
            }

        }
    }

    private IEnumerator OnCollisionWithObstacle()
    {
        if (Pos1Filled)
        {
            yield return new WaitForSeconds(2);
            this.transform.position = Pos1Dest.transform.position;
            this.transform.parent = GameObject.Find("CaseParent").transform;
            transform.localRotation = Quaternion.Euler(0, -90, 0);
            
        }
        if (Pos2Filled)
        {
            yield return new WaitForSeconds(2);
            this.transform.position = Pos2Dest.transform.position;
            this.transform.parent = GameObject.Find("CaseParent").transform;
            transform.localRotation = Quaternion.Euler(0, -90, 0);
            
        }
        if (Pos3Filled)
        {
            yield return new WaitForSeconds(2);
            this.transform.position = Pos3Dest.transform.position;
            this.transform.parent = GameObject.Find("CaseParent").transform;
            transform.localRotation = Quaternion.Euler(0, -90, 0);
            
        }

    }



    private void ReSnap()
    {
        if (Pos1Filled)
        {
            this.transform.position = Pos1Dest.transform.position;
            this.transform.parent = GameObject.Find("CaseParent").transform;
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
        if (Pos2Filled)
        {
            this.transform.position = Pos2Dest.transform.position;
            this.transform.parent = GameObject.Find("CaseParent").transform;
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
        if (Pos3Filled)
        {
            this.transform.position = Pos3Dest.transform.position;
            this.transform.parent = GameObject.Find("CaseParent").transform;
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
    }


}
