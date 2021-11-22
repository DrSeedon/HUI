using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromoCode : MonoBehaviour
{

    public InputField Text;

    public GameObject levelSelect;


    public AudioSource audioSource;
    public AudioClip Bell;

    /*
      PROMO-CODES

        IDDQD - Unlimit Hp;
        
        IDKFA - 10000 money

        TARDIS - unlock level select

        IMGOD - Develop mode

        Clear - clear all;
     */



    void Start()
    {
        Text.text = "";
        audioSource.clip = Bell;

        if (Main.LevelSelect)
        {
            levelSelect.SetActive(true);
        }

    }


    // Update is called once per frame
    void Update()
    {

    }

    public void CheckPromo()
    {

        switch (Text.text)
        {
            case "IDDQD":
                Main.PlayerHealth = 1000000;
                audioSource.Play();
                break;
            case "IDKFA":
                Main.Coin += 10000;
                audioSource.Play();
                break;
            case "TARDIS":
                Main.LevelSelect = true;
                levelSelect.SetActive(true);
                audioSource.Play();
                break;
            case "IMGOD":
                Main.DevelopMode = true;
                audioSource.Play();
                break;
            case "Clear":
                Clear();
                audioSource.Play();
                break;
            default:
                Text.text = "not found"; 
                break;
        }

    }

    void Clear()
    {



        Main.PlayerHealth = 200;
        Main.Coin = 0;
        PlayerPrefs.SetInt("Coin", Main.Coin);
        levelSelect.SetActive(false);
        Main.BoosterJump = false;
        Main.BoosterSpeed = false;
        Main.BoosterCoin = false;
        Main.Monetka = false;
        Main.MonetkaDebt = 0;
        Main.DevelopMode = false;
        Main.LevelSelect = false;

    }
}
