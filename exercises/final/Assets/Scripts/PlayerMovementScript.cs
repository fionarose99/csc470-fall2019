﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // References & Colors Setup
    public CharacterController cc;
    public GameManager gm;
    public Renderer PlayerBodyRend;
    public GameObject PlayerBody;
    public bool colorCycle;
    float colorPosition = 0;
    float colorChangeSpeed;

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

    // Collision Handling
    public float skipVel;
    bool collideFlag;

    // Start is called before the first frame update
    void Start()
    {
        prevIsGrounded = cc.isGrounded;
    }

    // Update is called once per frame
    void Update()
    {
        colorChangeSpeed = moveSpd / (throttle * 1.5f);

        if(colorCycle)
        {
            colorPosition += colorChangeSpeed * Time.deltaTime;
            PlayerBodyRend.material.color = Color.HSVToRGB(colorPosition % 1.0f, 0.8f, 1);
        }

        cc.Move(transform.forward * moveSpd * Time.deltaTime);

        // if LEVELSTART=true, set SPD=MINSPD
        if (gm.lvlStart)
        {
            moveSpd = minSpd;
            gm.lvlStart = false;
        }

        // while spacebar pressed, increase speed, stop if hit MAXSPD
        // manage similar to gravity in CharmanderJump
        if (moveSpd >= maxSpd)
        {
            moveSpd = maxSpd - 0.001f;
        }

        if (moveSpd < maxSpd)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveSpd += throttle * Time.deltaTime;
            }
            
            // else, decrease speed, stop if hit MINSPD
            else
            {
                if (moveSpd > minSpd)
                {
                    moveSpd -= throttle * Time.deltaTime;
                }
            }
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gm.Coins += 1;
            gm.SetCoinsText();
            Debug.Log("CoinCollisionRegistered");
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            collideFlag = true;
            if (collideFlag)
            {
                gm.Lives -= 1;
                gm.SetLivesText();
                Debug.Log("ObstacleCollisionRegistered");
                collideFlag = false;
            }

            

            //Vector3 skipDir;
            //skipDir.x = transform.forward.x;
            //skipDir.y = 0;
            //skipDir.z = transform.forward.z;
            //cc.Move(skipDir * skipVel);

            //float x = transform.forward.x;
            //float z = transform.forward.z;
            //Vector3 skipDir = transform.forward;
            //Vector3 skipDir = (x, 0f, z); "Cannnot implicitly convert type '(float x, float, float z)' to UnityEngine.Vector3"
            //cc.enabled = false;
            //transform.position += transform.forward * skipVel;
            //cc.enabled = true;
        }
    }
}
