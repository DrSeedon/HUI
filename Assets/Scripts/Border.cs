using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Border : MonoBehaviour
{

    public bool StartNewScene = false;


    private void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D trigger)
    {

        if (!(trigger.gameObject.tag == "Unbreakable"))
        {


            Destroy(trigger.gameObject);


        }



        if (trigger.gameObject.tag == "Player")
        {

            Reload();

        }



    }

    void Reload()
    {

        if (SceneManager.GetActiveScene().name == "Endless")
        {
            PlayerPrefs.SetInt("Coin", Main.Coin);

            StartNewScene = true;
        }
        else
        {

            Main.Level = 1;
            Main.JumpPower = 11f;
            Main.Time = 0;
            Main.BoosterJump = false;
            Main.BoosterSpeed = false;
            Main.BoosterCoin = false;
            SceneManager.LoadScene("Scene1");
        }


    }

  



}
