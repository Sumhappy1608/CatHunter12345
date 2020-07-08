using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityRewardListener : MonoBehaviour, IUnityAdsListener
{
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("OnUnityAdsDidFinish   =====================> " + showResult);
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            // If the ready Placement is rewarded, show the ad:
            if (placementId == UnityAdsCtrl.rewardedVideo_placementId)
            {
                MainCtrl.onX2Reward();
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        Debug.Log("OnUnityAdsReady   =====================> " + placementId);
        AdsMediaAI.ShowBanner();
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("OnUnityAdsDidError   =====================> " + message);
        // Log the error.
        AdsMediaAI.activeGoolge();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("OnUnityAdsDidStart   =====================> " + placementId);
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Debug.Log("OnDestroy   =====================> UNITY");
        Advertisement.RemoveListener(this);
    }


}
