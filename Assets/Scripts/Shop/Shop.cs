using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{

    public static int ShopButton;
    public Text MoneyText;
    public Transform SpawnPoint;
    public GameObject prod;
    public Sprite[] Sprites;
    Sprite Sprite;

    int IDSkin;

    public Text thxText;
    public Image ThxImage;
    public Sprite ThxSprite;
    public Button ThxButton;

    public LeanLocalizedText LocText;

    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    public void Buy(int IdSkins)
    {

       
       Sprite = Sprites[IdSkins];

       Transform spawnPos =  SpawnPoint.GetComponent<Transform>();
       GameObject SpawningItem = Instantiate(prod);
       SpawningItem.name = IdSkins.ToString();
       SpawningItem.GetComponent<SpriteRenderer>().sprite = Sprite;
       SpawningItem.transform.position = new Vector2(spawnPos.position.x, spawnPos.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.GetComponent<Text>().text = "Money: " + Main.Coin + "\r\nSaves: ";
    }
    //Бустеры
    public void BoosterBuyJump()
    {  
        int prise = 50;
        if(Main.Coin > prise)
        {
            Main.JumpPower = 15f;
            Main.BoosterJump = true;
            Main.Coin -= prise;
            
        }
    }

    public void BoosterBuySpeed()
    {  
        int prise = 40;
        if(Main.Coin > prise)
        {
            Main.SpeedPower = 10f;
            Main.BoosterSpeed = true;
            Main.Coin -= prise;
        }
    }

    public void BoosterBuyCoin()
    {  
        int prise = 100;
        if(Main.Coin > prise)
        {
             Main.BoosterCoin = true;
             Main.Coin -= prise;
        }
    }
    public void BoosterBuyCompass()
    {  
        int prise = 50;
        if(Main.Coin > prise)
        {
             Main.BoosterCompass = true;
             Main.Coin -= prise;
        }
    }


    //Скины
    public void SkinBuyRemove()
    {   
        int prise = 1;
        if(Main.Coin >= prise)
        {
            GameObject.Find("Player").SendMessage("RemoveHat");
            Main.Coin -= prise;
        }
    }

    public void SkinBuyMace()
    {   
        int prise = 50;
        if(Main.Coin >= prise)
        {
            IDSkin = 0;     
            Main.Coin -= prise;       
            Buy(IDSkin);            
        }
    }

    public void SkinBuyCat()
    {   
        int prise = 500;
        if(Main.Coin >= prise)
        {
            IDSkin = 1;
            Main.Coin -= prise;
            Buy(IDSkin);
        }
    }

    public void SkinBuySans()
    {   
        int prise = 1000;
        if(Main.Coin >= prise)
        {
            IDSkin = 2;
            Main.Coin -= prise;
            Buy(IDSkin);
        }
    }

    public void SkinBuyAnime()
    {   
        int prise = 2000;
        if(Main.Coin >= prise)
        {
            IDSkin = 3;
            Main.Coin -= prise;
            Buy(IDSkin);
        }
    }
    
    public void SkinBuyPotato()
    {
        IDSkin = 4;
        Buy(IDSkin);
    }

    public void SkinBuyDurka()
    {
        int prise = 3000;
        if (Main.Coin >= prise)
        {
            IDSkin = 5;
            Main.Coin -= prise;
            Buy(IDSkin);
        }
    }

    public void Money(int money){
        
       
        thxText.text = "Thanks! :3";
        ThxImage.sprite = ThxSprite;
        Main.Monetka = true;
        Main.MonetkaDebt = Main.Coin;
        Main.Coin = 0;
        LocText.TranslationName = "ThanksShop";
        ThxButton.interactable = false;
    }

    
}
