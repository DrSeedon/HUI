using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
public class MoneyInLevel : MonoBehaviour
{

    int MoneyLevel;
    public Text Text;

    public LeanToken Token;
    GameObject[] go;

    // Start is called before the first frame update
    void Start()
    {
        if (!Main.BoosterCompass)
        {
            this.gameObject.SetActive(false);
        }
        CheckMoney();

        go = GameObject.FindGameObjectsWithTag("Life");
        MoneyLevel = go.Length;
    }

    // Update is called once per frame
    void Update()
    {

        go = GameObject.FindGameObjectsWithTag("Life");
        if (go.Length < MoneyLevel)
        {
            CheckMoney();
            MoneyLevel = go.Length;
        }
        

    }

    public void CheckMoney()
    {
        if (Main.IsEndless)
        {
            Text.GetComponent<Text>().text = "Money collected: " + Main.CoinInRun.ToString();
            Token.Value = Main.CoinInRun.ToString();
        }
        else
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("Life");
            MoneyLevel = go.Length;
            Text.GetComponent<Text>().text = "Money in Level: " + MoneyLevel.ToString();
            Token.Value = MoneyLevel.ToString();
        }
    }
}
