using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    // References Setup
    public Animator animator;
    public bool WheelieAnimationIsPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Wheelie on W (handled in animation script)
        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("WheelieActivated");
        }
    }
}
