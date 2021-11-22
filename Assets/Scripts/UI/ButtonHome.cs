using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
//using UnityEngine.Monetization;

public class ButtonHome : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    // Start is called before the first frame update
    void Start()
    {
        //if(Monetization.isSupported) Monetization.Initialize("3446679",false);
        Main.Move = 0;
        
    }

    private void Update()
    {
       
    }


    /* void HandleShowResult(ShowResult result){

         if(result==ShowResult.Finished){
             GameObject.Find("Player").GetComponent<Hero>().AllCoin += 100;
         }
         else if (result==ShowResult.Skipped){

         }
         else if (result==ShowResult.Failed){

         }


     }*/


    public void OnPointerEnter(PointerEventData eventData)
    {

        if (gameObject.name == "ButtonRight")
        {
            Main.Move = 1;
        }
        else if (gameObject.name == "ButtonLeft")
        {
            Main.Move = -1;
        }

        /*else if(gameObject.name == "ButtonAds"){

            if(Monetization.IsReady("rewardedVideo")){
              ShowAdCallbacks option = new ShowAdCallbacks();
              option.finishCallback = HandleShowResult;
              ShowAdPlacementContent ad = Monetization.GetPlacementContent("rewardedVideo") as ShowAdPlacementContent;
              ad.Show(option);
            }

        }*/




    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Main.Move = 0;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
        PlayerPrefs.SetInt("Coin", Main.Coin);
        Main.IsEndless = false;
        Main.Level = 1;
    }
}
