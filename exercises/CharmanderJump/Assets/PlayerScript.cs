using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public int Lives;
    public Text LivesText;
    public int Points;
    public Text PointsText;
    public Text GameOverText;

    public CharacterController CharController;
    public float moveSpeed = 9;
    public float rotSpeed = 85;

    float yVelocity = 0;
    public float jumpForce = 2.5f;
    public float gravityModifier = 0.025f;
    bool prevIsGrounded;

    Vector3 StartingPlatformCoords = new Vector3 (38, 16, 38);

    // Start is called before the first frame update
    void Start()
    {
        Lives = 3;
        SetLivesText();
        Points = 0;
        SetPointsText();

        prevIsGrounded = CharController.isGrounded;
        //CharController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // L-R Forward-Back Motion
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, rotSpeed * Time.deltaTime * hAxis, 0);
        Vector3 amountToMove = transform.forward * moveSpeed * Time.deltaTime * vAxis;

        // Jump Motion
        if (CharController.isGrounded)
        {
            if (!prevIsGrounded && CharController.isGrounded)
            {
                yVelocity = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                yVelocity = 0;
            }

            yVelocity += Physics.gravity.y * gravityModifier;
        }

        amountToMove.y = yVelocity;
        // Modify the y-value within this Vector3 (which contains an x, y, z, and some utility functions like distance etc.) manually

        // Final Motion
        CharController.Move(amountToMove);

        // Update
        prevIsGrounded = CharController.isGrounded;

        // Camera
        Vector3 camPos = transform.position + transform.forward * -10 + Vector3.up * 3;
        Camera.main.transform.position = camPos;
        Camera.main.transform.LookAt(transform);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //yVelocity = jumpForce;
        //}

        //yVelocity += Physics.gravity.y * gravityModifier;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FloorTag"))
        {
            CharController.enabled = false;
            transform.position = StartingPlatformCoords;
            CharController.enabled = true;

            Lives -= 1;
            SetLivesText();
            //Debug.Log(transform.position);
        }

        if (other.gameObject.CompareTag("CellTag"))
        {
            Points += 1;
            SetPointsText();
        }
    }

    void SetLivesText()
    {
        LivesText.text = "Lives: " + Lives.ToString();
        if (Lives <= 0)
        {
            GameOverText.text = "Game Over";
        }
    }

    void SetPointsText()
    {
        PointsText.text = "Score: " + Points.ToString();
    }
}
