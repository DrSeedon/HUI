using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewScene : MonoBehaviour
{



    public bool TheEnd = false;
    public bool Active = false;
    public bool StartNewScene = false;
    AsyncOperation asyncOperation;

    public Text m_Text;
    // Start is called before the first frame update
    void Start()
    {
        //  asyncOperation = SceneManager.LoadSceneAsync("Scene" + (Main.Level + 1));
        //      asyncOperation.allowSceneActivation = false;
        StartCoroutine("LoadScene");
    }

    // Update is called once per frame


    void OnTriggerEnter2D(Collider2D trigger)
    {


        if (trigger.gameObject.tag == "Player")
        {

            if (Active == false)
                OpenNewScene();

        }
    }

    public void OpenNewScene()
    {

        Active = true;
        Main.Level += 1;



        if (Main.BoosterJump)
        {

        }
        else
        {
            Main.JumpPower = 11f;
        }


        PlayerPrefs.SetInt("Coin", Main.Coin);
        //SceneManager.LoadSceneAsync("Scene" + Main.Level);

        //SceneManager.LoadScene("Scene" + Level); 


        if (Main.Coin >= 1000)
        {
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_rich);
        }

        if (TheEnd)
        {
            SceneManager.LoadScene("End");
        }

        StartNewScene = true;
    }

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Scene" + (Main.Level + 1));
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress

            m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";


            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {

                m_Text.text = " ";

                if (StartNewScene)
                    asyncOperation.allowSceneActivation = true;

            }

            yield return null;
        }
    }



}

