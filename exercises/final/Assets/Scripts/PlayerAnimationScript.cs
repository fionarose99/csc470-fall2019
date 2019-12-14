using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    // References Setup
    public Animator animator;
    public AudioClip WheelieSound;
    public AudioSource audio;
    public bool WheelieAnimationIsPlaying = false;
    public float WheelieVolume;

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
            Debug.Log("Before");
            animator.SetTrigger("WheelieActivated");
            Debug.Log("Set Trigger WheelieActivated In PlayerAnimScript");
            audio.PlayOneShot(WheelieSound, WheelieVolume);
            Debug.Log("WheelieAudioActive PlayerAnimScript");
        }
    }
}
