using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Lean.Localization;

public class End : MonoBehaviour
{

    public Text YourTime;
    public Text YourCoins;
    public Text YourScore;

    public LeanToken tokenCoin;
    public LeanToken tokenTimer;
    public LeanToken tokenScore;

    public LeanLocalization Leans;
    
    public AudioSource audioSource;
    public AudioClip EndlessClip;

    

    // Thanks you!
    void Start()
    {
        float res = ((int)(Main.Time * 100)) / 100f;
        YourTime.text = "Your time: " + res.ToString() + " s";
        tokenTimer.Value = res.ToString();
        YourCoins.text = "Your coins: " + Main.Coin.ToString();
        tokenCoin.Value = Main.Coin.ToString();
        PlayerPrefs.SetInt("Coin", Main.Coin);

        if(Main.TardisMode == false)
        {
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_end_of_game);
        }

        if(Main.IsEndless){
            YourScore.gameObject.SetActive(true);
            YourScore.text = "Your score: " + Main.ChunkBegin.ToString();  
            tokenScore.Value = Main.ChunkBegin.ToString();
            YourCoins.text = "Your coins: " + Main.CoinInRun.ToString();
            tokenCoin.Value = Main.Coin.ToString();
            Main.CoinInRun = 0;
            audioSource.clip = EndlessClip;
            audioSource.Play();
            int coin = Main.CoinInRun + Main.Coin;
            PlayerPrefs.SetInt("Coin", coin);
            Main.IsEndless = false;
        }

      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
