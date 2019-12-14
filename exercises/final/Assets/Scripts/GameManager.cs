using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool lvlStart;
    public int Lives;
    public Text LivesText;
    public int Coins;
    public Text CointsText;
    public float FloatTimer = 0.0f;
    public Text TimerText;
    public Text HighScoreText;
    public int HighScore = 0;
    public int LapCounter;
    public Text LapCounterText;
    public int TotalLaps;
    public int TimeToBeat;
    public int CoinsMultiplier;
    public int LapsMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("lvlStart value = " + lvlStart);

        SetLivesText();
        SetCoinsText();
        SetTimerText();

        Debug.Log("LapCounterInt = " + LapCounter);
        Debug.Log("LapCounterText before function = " + LapCounterText.text);
        SetLapCounterText();
        Debug.Log("LapCounterText after function = " + LapCounterText.text);

        SetHighScoreText();

        DontDestroyOnLoad(gameObject);
        if(PlayerPrefs.GetInt("lvlStart") == 1)
        {
            lvlStart = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //TimerScore = Mathf.RoundToInt(FloatTimer)
        //HighScore = TimerScore
        //Spawn Range: + or - 2 in z-direction
        //RawImage onUI
        if(Lives >= 0 && LapCounter < TotalLaps)
        {
            FloatTimer += Time.deltaTime;
            FloatTimer *= 100;
            FloatTimer = Mathf.RoundToInt(FloatTimer);
            FloatTimer /= 100;
            SetTimerText();
        }
    }

    public void SetCoinsText()
    {
        CointsText.text = Coins.ToString();
    }
    public void SetLivesText()
    {
        LivesText.text = Lives.ToString();
    }

    public void SetTimerText()
    {
        TimerText.text = FloatTimer.ToString();
    }

    public void SetLapCounterText()
    {
        LapCounterText.text = "LAP: " + LapCounter.ToString() + "/" + TotalLaps.ToString();
    }

    public void SetHighScoreText()
    {
        HighScoreText.text = "HIGH SCORE: " + HighScore.ToString();
    }
}
