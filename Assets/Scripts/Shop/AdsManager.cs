using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;


public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    private string gameId = "3446679";
    private bool testMode = false;

    public Button myButton;
    public string myPlacementId = "rewardedVideo";
    

    public GameObject RewardPanel;
    public TextMeshProUGUI RewardText;
    public TextMeshProUGUI RewardTextCoin;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            gameId = "3446678";
        else if (Application.platform == RuntimePlatform.Android)
            gameId = "3446679";
        
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);


        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);

        Advertisement.Initialize(gameId, testMode);


    }

    private void OnDisable()
    {
        Advertisement.RemoveListener(this);
    }

    // Implement a function for showing a rewarded video ad:
    public void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            RewardPanel.SetActive(true);
            RewardText.text = "Thanks You for support!";
            RewardTextCoin.text = "25";
            Main.Coin += 25;
        }
        else if (showResult == ShowResult.Skipped)
        {
            RewardPanel.SetActive(true);
            RewardText.text = "You skipped ad. But thanks anyway!";
            RewardTextCoin.text = "5";
            Main.Coin += 5;
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("error!");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }



}
