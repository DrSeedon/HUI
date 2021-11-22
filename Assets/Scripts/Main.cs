using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Main 
{

    //Main
   
    public static int Coin = 0;
    public static int Level = 1;
    public static float Time;
    public static bool TimerRun = false;
    public static bool TimerVisible = false;
    public static int RandomBackground = 1;
    public static string Language = "English";
    public static bool TardisMode = false;


    //Player
    
    public static bool PressingJump = false;    
    public static float JumpPower = 11f;
    public static float SpeedPower = 6f;   
    public static float Move = 0;

    //Shop

    public static bool BoosterJump = false;
    public static bool BoosterSpeed = false;
    public static bool BoosterCoin = false;    
    public static bool BoosterCompass = false;    


    //Bullet

    public static bool BulletRightMove = true;


    //Boss

    public static int BossHealth = 1000;
    public static int PlayerHealth = 200;


    //Global ColorShop

    public static Color32 Color;


    //Endless

    public static int ChunkBegin = 0;
    public static bool IsEndless = false;
    public static int CoinInRun = 0;

    //Car 
    public static bool InCar = false;

    //Monetka
    public static bool Monetka = false;
    public static int MonetkaDebt = 0;

    //PROMO

    public static bool DevelopMode = false;
    public static bool LevelSelect = false;
    

}
