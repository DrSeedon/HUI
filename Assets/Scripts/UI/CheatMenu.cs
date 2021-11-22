using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheatMenu : MonoBehaviour
{

    public GameObject Panel;
    public bool IsOpen = false;

    public TextMeshProUGUI TextConsole;
    public GameObject developButton;
    // Start is called before the first frame update
    void Start()
    {
        if (Main.DevelopMode)
        {
            developButton.SetActive(true);
        }
        else
        {
            developButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var text = "Monetka: " + Main.Monetka + "\r\n"
            + "MonetkaDebt: " + Main.MonetkaDebt + "\r\n"
            + "Coin: " + Main.Coin + "\r\n";

        TextConsole.text = text;
    }

    public void Clicked()
    {
        if (IsOpen)
        {
            Panel.SetActive(false);
            IsOpen = false;
        }
        else
        {
            Panel.SetActive(true);
            IsOpen = true;
        }
    }

    public void MoneyClick()
    {
        Main.Coin += 1000;

    }
}
