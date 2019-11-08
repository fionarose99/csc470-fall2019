using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinchScript : MonoBehaviour
{
    // Movement, Collisions, Particle Effects
    // ******
    // Movement same as ClickOnUnitsPlusUI. 
    // CharacterController for bumping past things
    // Point and click movement for moving
    // Pick up letters on Collision
    // Letters need to push into stack when collision, pop out on collision w/ Messenger

    // TAGS
    // ******
    // Finch

    // Meters and Timers
    // ******
    // METER - LettersFull

    // SETUP
    public bool selected = false;
    bool hover = false;
    public string name;
    public Sprite portrait;
    //Color defaultColor;
    //public Color hoverColor;
    //public Color selectedColor;
    CharacterController cc;
    public Vector3 destination;
    public Renderer rend;
    GameManager gm;
    public float LetterCounter;

    void Start()
    {
        int LetterCounter = 0;

        // 1. Get reference to a gameObject using GameObject.Find()
        // 2. Use GetComponent() function to get reference to a 
        // component on GameObject
        GameObject gmObj = GameObject.Find("GameManagerObject");
        gm = gmObj.GetComponent<GameManager>();

        // Get reference to CharacterController component on gameObject
        cc = gameObject.GetComponent<CharacterController>();

        // Initialize destination to current position (so units don't
        // move on start)
        destination = transform.position;

        // Store defaul color
        //defaultColor = rend.material.color;

        // Set the initial color
        //setColorOnMouseState();

        // Give each random rotation so not all facing same way
        //transform.eulerAngles = new Vector3(0, Random.Range(0,360), 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate and move towards destination
        if (destination != null && Vector3.Distance(destination, transform.position) > 0.5f)
        {
            destination.y = transform.position.y;
            Vector3 vecToDest = (destination - transform.position).normalized;
            float step = 3 * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, vecToDest, step, 1);
            transform.rotation = Quaternion.LookRotation(newDir);

            cc.Move(transform.forward * 5 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RosemaryLetter")
        {
            // In Finch: Add a pink increment to on-screen stack representation
            LetterCounter += 1.0f;
        }
        if (other.gameObject.tag == "BudLetter")
        {
            // In Finch: Add a blue increment to on-screen stack representation
            LetterCounter += 1.0f;
        }
    }

    // Set color based on hover and select variables
    //public void setColorOnMouseState()
    //{
    //if (selected)
    //{
    //rend.material.color = selectedColor;
    //}
    //else if (hover)
    //{
    //rend.material.color = hoverColor;
    //}
    //else
    //{
    //rend.material.color = defaultColor;
    //}


    // Following functions called based on what mouse is doing
    // with regards to the gameObject this script is attached to
    private void OnMouseOver()
    {
        hover = true;
        //setColorOnMouseState();
    }
    private void OnMouseExit()
    {
        hover = false;
        //setColorOnMouseState();
    }

    //private void OnMouseDown()
    //{
     //   selected = !selected;
       // if (selected)
        //{
          //  gm.selectUnit(this);
        //}
        //else
        //{
          //  gm.selectUnit(null);
        //}
        //setColorOnMouseState();
    //}
}