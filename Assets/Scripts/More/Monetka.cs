using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monetka : MonoBehaviour
{


    public string text;

    // Start is called before the first frame update
    void Start()
    {
        if (!Main.Monetka)
        {
            this.gameObject.SetActive(false);
        }
        GetComponentInChildren<Coin>().price = Main.MonetkaDebt * 3;

        if (Main.Language == "Russian")
        {
            text = "<b>Привет!</b> Извини, что задержал долг. Вот твои <color=#ffea00> " + Main.MonetkaDebt * 3 + " </color> монет!";
        }
        else if (Main.Language == "English")
        {
            text = "<b>Hello!</b> Sorry to delay your debt. Here are your <color=#ffea00> " + Main.MonetkaDebt * 3 + " </color> coins!";
        }


        this.gameObject.GetComponent<ObjectNameView>().text = text;
        Main.Monetka = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
