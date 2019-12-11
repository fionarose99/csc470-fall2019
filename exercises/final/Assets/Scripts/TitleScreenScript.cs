using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    // References Setup
    GameManager gm;
    //public Text StartButtonText;
    public Button StartButton;
    bool colorCycle;
    float colorPosition = 0;
    public float colorChangeSpeed;
    // public Renderer rend;

    public Image startButtonImage;
    public AudioClip StartSound;
    AudioSource audio;

    //float rVal = 1.0f;
    //float gVal = 1.0f;
    //float bVal = 1.0f;
    //Color nextColor = new Color(1.0f,1.0f,1.0f,1.0f);

    // Start is called before the first frame update
    void Start()
    {
        //gm = GameObject.Find("GameManagerObject");
        //StartButtonText = gameObject.GetComponent<StartButtonText>();
        colorCycle = true;
        PlayerPrefs.SetInt("lvlStart", 0);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(colorCycle == true)
        {
            colorPosition += colorChangeSpeed * Time.deltaTime;
            startButtonImage.color = Color.HSVToRGB(colorPosition % 1.0f, 0.8f, 1);
            // colorPosition % 1.0 b/c we want the value of Hue to be b/w 0 & 1 the whole time

            // rend.material.color = ... for cubes

            //nextColor = new Color(rVal, gVal, bVal, 1.0f);
            //ColorBlock cb = Button.colors;
            //cb.normalColor = nextColor;
            //rVal -= 0.5f;

            //// PURPLE
            //nextColor.r = 0.58f;
            //nextColor.g = 0f;
            //nextColor.b = 0.83f;

            //// VIOLET
            //nextColor.r = 0.29f;
            //// g = 0
            //nextColor.b = 0.5f;

            //// BLUE
            //nextColor.r = 0.0f;
            //// g = 0
            //nextColor.b = 1.0f;

            //// GREEN
            //// r = 0
            //nextColor.g = 1.0f;
            //nextColor.b = 0.0f;

            //// YELLOW
            //nextColor.r = 1.0f;
            //// g = 1
            //// b = 0

            //// ORANGE
            //// r = 1
            //nextColor.g = 0.5f;
            //// b = 0

            //// RED
            //// r = 1
            //nextColor.g = 0.0f;
            //// b = 0;
        }
    }

    public void StartButtonPressed()
    {
        //AudioSource.PlayClipAtPoint(StartSound, transform.position);
        audio.PlayOneShot(StartSound, 1.0f);
        PlayerPrefs.SetInt("lvlStart", 1);
        Debug.Log("Button Pressed Function Activated in Title Screen Script");
        SceneManager.LoadScene("Lvl1", LoadSceneMode.Single);
    }
}
