using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript : MonoBehaviour
{
    public GameObject Finch;
    private bool OnFinch;
    FinchScript finchScript;
    

    // Start is called before the first frame update
    void Start()
    {
        Finch = GameObject.Find("Finch");
        OnFinch = false;
        finchScript = Finch.GetComponent<FinchScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnFinch == true)
        {
            transform.position = new Vector3(Finch.transform.position.x, transform.position.y, Finch.transform.position.z);
            // y-value still based on what's set in the collider/for stacks, but x and z follow Finch
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RosemaryBox")
        {
            // In Finch: Add a pink increment to on-screen stack representation
            gameObject.tag = "RosemaryLetter";
        }
        if (other.gameObject.tag == "BudBox")
        {
            gameObject.tag = "BudLetter";
        }

        if (other.gameObject.tag == "Finch")
        {
            //float height = finchScript.LetterCounter;
            transform.position = Finch.transform.position + Vector3.up * finchScript.LetterCounter;
            OnFinch = true;
        }
    }
}
