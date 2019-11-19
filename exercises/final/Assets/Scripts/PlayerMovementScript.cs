using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // References Setup
    public CharacterController cc;
    public GameManager gm;

    // Movement Setup
    public float minSpd;
    public float maxSpd;
    public float moveSpd;
    public float throttle;
    public float turnSpd;
    // set MAXSPD, MINSPD, moveSpd, turnSpd - also public (change in Unity editor)

    // Jumping Setup
    float yVelocity = 0;
    public float jumpForce = 2.5f;
    public float gravityModifier = 0.025f;
    bool prevIsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        prevIsGrounded = cc.isGrounded;
    }

    // Update is called once per frame
    void Update()
    {
        cc.Move(transform.forward * moveSpd * Time.deltaTime);

        // if LEVELSTART=true, set SPD=MINSPD
        if (gm.lvlStart)
        {
            moveSpd = minSpd;
            gm.lvlStart = false;
        }

        // while spacebar pressed, increase speed, stop if hit MAXSPD
        // manage similar to gravity in CharmanderJump
        if (moveSpd < maxSpd)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveSpd += throttle * Time.deltaTime;
            }
            else
            {
                if (moveSpd > minSpd)
                {
                    moveSpd -= throttle * Time.deltaTime;
                }
            }
        }

        // else, decrease speed, stop if hit MINSPD

        // while D pressed, rotate right
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1 * turnSpd * Time.deltaTime, 0);
        }
        // while A pressed, rotate left
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpd * Time.deltaTime, 0);
        }
        // jump on W (+ add animations)
    }
}
