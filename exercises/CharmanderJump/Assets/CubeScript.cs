using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var cubeRenderer = gameObject.GetComponent<Renderer>();
        //cubeRenderer.material.SetColor("_EmissionColor", Color.blue);

        //Create a new cube primitive to set the color on
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //Get the Renderer component from the new cube
        var cubeRenderer = cube.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        cubeRenderer.material.SetColor("_EmissionColor", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
