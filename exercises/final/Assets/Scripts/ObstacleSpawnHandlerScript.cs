using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnHandlerScript : MonoBehaviour
{
    float randomRangeVal;
    int[] plusorminusarray;
    int negorpos;
    public float posModulator;

    // Start is called before the first frame update
    void Start()
    {
        plusorminusarray = new int[2];
        plusorminusarray[0] = -1;
        plusorminusarray[1] = 1;

        negorpos = plusorminusarray[Random.Range(0,plusorminusarray.Length)];
        Debug.Log("negorpos value = " + negorpos);
        Debug.Log("initial z val = " + transform.position.z);
        randomRangeVal = (posModulator) * negorpos;
        Debug.Log("Random Range Val = " + randomRangeVal);
        transform.position += new Vector3(0, 0, randomRangeVal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
