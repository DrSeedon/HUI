using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DaylyGift : MonoBehaviour
{
    public GameObject GiftPanel;
    public TextMeshProUGUI GiftText;
    public int rex = 0;
    public DateTime RewardedDT;
    public string data;

    public GameObject Coin;
    public int SpawningCoin;

    void Start()
    {

        rex = PlayerPrefs.GetInt("rex1", 0);
        if (rex == 0)
        {
            RewardedDT = DateTime.Now;
            PlayerPrefs.SetInt("RewardedYear", RewardedDT.Year);
            PlayerPrefs.SetInt("RewardedMonth", RewardedDT.Month);
            PlayerPrefs.SetInt("RewardedDay", RewardedDT.Day);
            PlayerPrefs.SetInt("RewardedHour", RewardedDT.Hour);
            PlayerPrefs.SetInt("RewardedMinute", RewardedDT.Minute);
            PlayerPrefs.SetInt("RewardedSecond", RewardedDT.Second);

            rex = 1;
            PlayerPrefs.SetInt("rex1", rex);

            Gift(10);
        }


        dayCheck();
    }

    // Update is called once per frame
    void Update()
    {
        data = RewardedDT.ToString();
    }

    public void dayCheck()
    {

        RewardedDT = new DateTime(PlayerPrefs.GetInt("RewardedYear", DateTime.Now.Year), PlayerPrefs.GetInt("RewardedMonth", DateTime.Now.Month), PlayerPrefs.GetInt("RewardedDay", DateTime.Now.Day),
                                          PlayerPrefs.GetInt("RewardedHour", DateTime.Now.Hour), PlayerPrefs.GetInt("RewardedMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("RewardedSecond", DateTime.Now.Second));
        if (RewardedDT <= DateTime.Now && (DateTime.Now - RewardedDT).Hours >= 6)
        {
            RewardedDT = DateTime.Now.AddDays(1);
            PlayerPrefs.SetInt("RewardedYear", RewardedDT.Year);
            PlayerPrefs.SetInt("RewardedMonth", RewardedDT.Month);
            PlayerPrefs.SetInt("RewardedDay", RewardedDT.Day);
            PlayerPrefs.SetInt("RewardedHour", RewardedDT.Hour);
            PlayerPrefs.SetInt("RewardedMinute", RewardedDT.Minute);
            PlayerPrefs.SetInt("RewardedSecond", RewardedDT.Second);

            Debug.Log("New Reward!2");
            int money = UnityEngine.Random.Range(0, 50);
            Gift(money);
        }
    }



    public void Gift(int money)
    {
        SpawningCoin = money;
        GiftPanel.SetActive(true);
        GiftText.text = money.ToString();

    } 

    public void SpawnMoney()
    {
        for (int i = 0; i < SpawningCoin; i++)
        {
            Instantiate(Coin, this.transform);
        }
    }
}
