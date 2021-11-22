using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public int price = 1;
    public int priceText;
    public GameObject FlyText;
    public bool IsTouched = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D trigger)
    {

        if (trigger.gameObject.tag == "Player")
        {


            if (Main.BoosterCoin)
            {

                GiveCoin(price * 2);

                if (SceneManager.GetActiveScene().name == "Endless")
                {
                    Main.CoinInRun++;
                    Main.CoinInRun++;
                }

            }
            else
            {

                GiveCoin(price);

                if (SceneManager.GetActiveScene().name == "Endless")
                {
                    Main.CoinInRun++;
                }

            }
            DestroingCoin();
        }


    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {


            if (Main.BoosterCoin)
            {

                GiveCoin(price * 2);

                if (SceneManager.GetActiveScene().name == "Endless")
                {
                    Main.CoinInRun++;
                    Main.CoinInRun++;
                }

            }
            else
            {

                GiveCoin(price);

                if (SceneManager.GetActiveScene().name == "Endless")
                {
                    Main.CoinInRun++;
                }

            }
            DestroingCoin();
        }
    }


    public void GiveCoin(int num)
    {
        priceText = num;
        for (int i = 0; i < num; i++)
        {
            Main.Coin++;
        }


    }

    public void DestroingCoin()
    {
        if (!IsTouched)
        {
            Vector3 spawnPos2 = new Vector2(transform.position.x, transform.position.y);

            GameObject FlyTextClone = Instantiate(FlyText, spawnPos2, Quaternion.identity);

            var TextClone = FlyTextClone.GetComponent<TextMeshPro>();

            TextClone.text = "+" + priceText;

            IsTouched = true;

            Invoke("destroyy", 0.1f);

        }

    }

    void destroyy()
    {
        Destroy(this.gameObject);
    }



}
