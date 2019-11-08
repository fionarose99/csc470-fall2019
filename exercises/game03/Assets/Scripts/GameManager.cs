using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    // Hold reference to whatever unit was selected last
    public FinchScript selectedUnit;

    // References to handful of UI elements
    //public GameObject talkBox;
    //public Text talkText;
    //public ToggleGroup actionSelectToggleGroup;
    //public GameObject selectedPanel;
    //public Text nameText;
    //public Image portraitImage;

    public GameObject letterPrefab;
    public Vector3 RosemaryBoxCoords;
    public Vector3 BudBoxCoords;
    //public Vector3 letterRotVector;

    void Start()
    {
        //Quaternion letterRotQuat = Quaternion.Euler(letterRotVector); // Allows for specific angle declared in Vector3 format in the inspector
        //Instantiate(letterPrefab, RosemaryBoxCoords, letterRotQuat);
        Instantiate(letterPrefab, RosemaryBoxCoords, Quaternion.identity);
        Instantiate(letterPrefab, BudBoxCoords, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetMouseButtonDown(0) how to detect left mouse has been clicked
        // IsPointerOverGameObject makes sure pointer is over UI.
        if (Input.GetMouseButtonDown(0))// && !EventSystem.current.IsPointerOverGameObject())
        {
            // Create ray from mouse position (in camera/UI space) to 3D space
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("1");
            // After Raycast, 'hit' will store info about what raycast hit
            RaycastHit hit;

            // Shoot line from mouse position into world, if hits something marked
            // with layer 'ground' and return true
            if (Physics.Raycast(ray, out hit, 9999))
            {
                Debug.Log("2");
                // Check to see if raycast hit was marked w/ layer 'ground'
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
                {
                    Debug.Log("3");
                    // If true, set destination of selectedUnit to point on ground
                    // that raycast hit
                    if (selectedUnit != null)
                    {
                        Debug.Log("4");
                        selectedUnit.destination = hit.point;
                    }
                }
                //else
                //{
                    // If we're here, raycast hit nothing, deselect
                   // if (selectedUnit != null)
                    //{
                        //selectedUnit.selected = false;
                        //selectedUnit.setColorOnMouseState();
                        //selectedUnit = null;
                        //updateSelectedPanelUI();
                    //}
                //}
                // [COMMENTED OUT DESELECT PROTOCOL - ONLY 1 CONTROLLABLE UNIT ANYWAY]
            }
        }
    }

    // If something selected previously, unselect it, update color
    //public void selectUnit(FinchScript unit)
    //{
        //if (selectedUnit != null)
        //{
            //selectedUnit.selected = false;
            //selectedUnit.setColorOnMouseState();
        //}

        // Set selected unit to one we just passed in
      //  selectedUnit = unit;

        //if (selectedUnit != null)
        //{
            // If there is a selected unit update (color)
          //  selectedUnit.selected = true;
            //selectedUnit.setColorOnMouseState();
        //}

        //updateSelectPanelUI();
}
