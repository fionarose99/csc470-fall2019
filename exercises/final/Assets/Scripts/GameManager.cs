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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("lvlStart value = " + lvlStart);

        SetLivesText();
        SetCoinsText();

        DontDestroyOnLoad(gameObject);
        if(PlayerPrefs.GetInt("lvlStart") == 1)
        {
            lvlStart = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn Range: + or - 2 in z-direction
        //RawImage onUI
    }

    public void SetCoinsText()
    {
        CointsText.text = Coins.ToString();
    }
    public void SetLivesText()
    {
        LivesText.text = Lives.ToString();
    }
}
