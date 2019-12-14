using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    // References & Colors Setup
    public CharacterController cc;
    public GameManager gm;
    public Renderer PlayerBodyRend;
    public GameObject PlayerBody;
    public GameObject PlayerModel;
    public bool colorCycle;
    public AudioClip CoinSound;
    public AudioClip DamageSound;
    public AudioSource audio;
    public float CoinVolume;
    public float DamageVolume;
    bool IsWheelieAnimationPlaying;
    float colorPosition = 0;
    float colorChangeSpeed;
    public Animator DamageAnimator;
    public Animator GameOverAnimator;
    float GameOverScreenTime = 0;
    public AudioSource ExciteBikeAudio;
    public Animator LevelCompleteAnimator;
    float LevelCompleteScreenTime = 0;
    public Animator HighScoreAnimator;
    public GameObject FinishLinePrefab;
    bool FinishLineCross = false;
    public Collider FinishLineCollider;
    float FinishLineCrossTime = 0;

    // Movement Setup
    public float minSpd;
    public float maxSpd;
    public float moveSpd;
    public float throttle;
    public float turnSpd;
    // set MAXSPD, MINSPD, moveSpd, turnSpd - also public (change in Unity editor)

    //// Jumping Setup
    //float yVelocity = 0;
    //public float jumpForce = 2.5f;
    //public float gravityModifier = 0.025f;
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
        if(gm.Lives == 0)
        {
            GameOverAnimator.SetTrigger("GameOverTriggered");
            gm.HighScore = (gm.LapCounter * gm.LapsMultiplier) + (gm.Coins * gm.CoinsMultiplier);
            HighScoreAnimator.SetTrigger("HighScoreTriggered");
            ExciteBikeAudio.volume = 0;

            GameOverScreenTime += Time.deltaTime;
            if(GameOverScreenTime >= 5)
            {
                SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
            }
        }

        FinishLineCrossTime += Time.deltaTime;

        if (gm.LapCounter >= gm.TotalLaps)
        {
            LevelCompleteAnimator.SetTrigger("LevelCompleteTriggered");
            gm.HighScore = (gm.TimeToBeat - Mathf.RoundToInt(gm.FloatTimer)) + (gm.Coins * gm.CoinsMultiplier);
            gm.SetHighScoreText();
            HighScoreAnimator.SetTrigger("HighScoreTriggered");
            ExciteBikeAudio.volume = 0.8f;
            audio.volume = 0.3f;

            LevelCompleteScreenTime += Time.deltaTime;
            Debug.Log("LevelCompleteScreenTime = " + LevelCompleteScreenTime);
            if(LevelCompleteScreenTime >= 5)
            {
                ExciteBikeAudio.volume = 0;
                audio.volume = 0;
                SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
            }
        }

        colorChangeSpeed = moveSpd / (throttle * 1.5f);

        if (colorCycle)
        {
            colorPosition += colorChangeSpeed * Time.deltaTime;
            PlayerBodyRend.material.color = Color.HSVToRGB(colorPosition % 1.0f, 0.8f, 1);
        }


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

        // while A pressed, rotate left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1 * turnSpd * Time.deltaTime, 0);
        }

        // while D pressed, rotate right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpd * Time.deltaTime, 0);
        }

        // Wheelie on W (handled in animation script)
        //if(Input.GetKeyDown(KeyCode.W))
        //{
        //    animator.SetTrigger("WheelieActivated");
        //}

        cc.Move(transform.forward * moveSpd * Time.deltaTime);

        //// jump on W (+ add animations)
        //if (cc.isGrounded)
        //{
        //    if (!prevIsGrounded && cc.isGrounded)
        //    {
        //        yVelocity = 0;
        //    }
        //    if (Input.GetKeyDown(KeyCode.W))
        //    {
        //        yVelocity = jumpForce;
        //    }
        //}
        //else
        //{
        //    if (Input.GetKeyUp(KeyCode.W))
        //    {
        //        yVelocity = 0;
        //    }

        //    yVelocity += Physics.gravity.y * gravityModifier;
        //}

        //float vAxis = Input.GetAxis("Vertical");
        //Vector3 amountToMove = transform.forward * moveSpd * Time.deltaTime * vAxis;
        //amountToMove.y = yVelocity;
        //cc.Move(amountToMove);
        //prevIsGrounded = cc.isGrounded;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine"))
        {
            FinishLineCrossTime = 0f;
            gm.LapCounter += 1;
            gm.SetLapCounterText();
            FinishLineCollider.enabled = false;
            Debug.Log("Collider enabled status = " + FinishLineCollider.enabled);
            FinishLineCross = true;

            Debug.Log("FinishLineCollisionRegistered");

            //if (FinishLineCross)
            //{
            Vector3 FinishLinePos = new Vector3(-9.19f, -0.03f, -24.98f);
            GameObject FinishLine = Instantiate(FinishLinePrefab, FinishLinePos, transform.rotation);
            Debug.Log("New FinishLine Generated");
            //}

            if(FinishLineCrossTime >= 3f)
            {
                FinishLineCollider.enabled = true;
            }
            
            Debug.Log("New Collider enabled status = " + FinishLineCollider.enabled);
            //FinishLineCross = false;

        }

        if (other.gameObject.CompareTag("Coin"))
        { 
            audio.PlayOneShot(CoinSound, CoinVolume);
            Debug.Log("CoinCollisionRegistered");
            Destroy(other.gameObject);

            if (gm.Lives >= 1 && gm.LapCounter < gm.TotalLaps)
            {
                gm.Coins += 1;
                gm.SetCoinsText();
            }
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            collideFlag = true;
            Debug.Log("Obstacle collideFlag = true");
            IsWheelieAnimationPlaying = PlayerModel.GetComponent<PlayerAnimationScript>().WheelieAnimationIsPlaying;
            Debug.Log("IsWheelieAnimationPlaying? PlayerMoveScript: " + IsWheelieAnimationPlaying);

            if (gm.Lives >= 1 && gm.LapCounter < gm.TotalLaps)
            {
                if (collideFlag && !IsWheelieAnimationPlaying)
                {
                    DamageAnimator.SetTrigger("DamageTriggered");
                    gm.Lives -= 1;
                    gm.SetLivesText();
                    Debug.Log("ObstacleCollisionRegistered");
                    audio.PlayOneShot(DamageSound, DamageVolume);
                    collideFlag = false;
                }
            }
            

            // OLD CODE

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
