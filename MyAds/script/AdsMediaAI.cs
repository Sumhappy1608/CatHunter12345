using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AdsType
{
    GOOGLE,
    UNITY
}
public class AdsMediaAI : MonoBehaviour
{

    void Start()
    {
        activeGoolge();
        Debug.Log("AdsMediaAI INITTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
    }

    private static AdsType type = AdsType.GOOGLE;

    public static bool ShowInterstitial()
    {
       return GetAdsCtr().ShowInterstitial();
    }
    public static bool ShowRewardAds()
    {
        return GetAdsCtr().ShowRewardAds();
    }
    public static void ShowBanner()
    {
        Debug.Log("AdsMediaAI ShowBanner  " + GetAdsCtr());
        GetAdsCtr().ShowBanner();
    }

    private static IAdsCtr GetAdsCtr()
    {
        if (type == AdsType.GOOGLE)
            return GoogleAdsCtrl.Instance;
        return UnityAdsCtrl.Instance;
    }

    public static void activeGoolge()
    {
        type = AdsType.GOOGLE;
        if(UnityAdsCtrl.Instance != null)
            UnityAdsCtrl.Instance.HideBanner();
        if (GoogleAdsCtrl.Instance != null)
            GoogleAdsCtrl.Instance.ShowBanner();
    }

    public static void activeUnity()
    {
        type = AdsType.UNITY;
        if (GoogleAdsCtrl.Instance != null)
            GoogleAdsCtrl.Instance.HideBanner();
        if (UnityAdsCtrl.Instance != null)
            UnityAdsCtrl.Instance.ShowBanner();
    }
}
