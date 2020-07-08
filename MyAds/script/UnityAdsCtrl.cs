using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class UnityAdsCtrl : MonoBehaviour, IAdsCtr
{
    // Start is called before the first frame update
    private static UnityAdsCtrl _instance;

    public static UnityAdsCtrl Instance
    {
        get { return _instance; }
    }

    public static string banner_placementId = "banner";
    public static string rewardedVideo_placementId = "rewardedVideo";

#if UNITY_IOS
	public static string gameId = "2813448";
#elif UNITY_ANDROID
    public static string gameId = "2813447";
#else
    string gameId = "2813447";
#endif
    bool testMode = false;

    void Start()
    {
        Debug.Log("UNITY INITTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
        _instance = this;
        
        Advertisement.Initialize(gameId, testMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    
    public bool ShowInterstitial()
    {
        Debug.Log("ShowInterstitial   =====================> UNITY ");
        Advertisement.Show();
        return true;
    }

    public bool ShowRewardAds()
    {
        Advertisement.Show(rewardedVideo_placementId);
        return true;
    }

    public void ShowBanner()
    {
        Debug.Log("ShowBanner   =====================> UNITY ");
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(banner_placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(banner_placementId);
       
    }



    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }
}
