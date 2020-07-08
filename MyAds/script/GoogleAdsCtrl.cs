using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using GoogleMobileAds.Api;
public class GoogleAdsCtrl : MonoBehaviour ,IAdsCtr  {

	private static string admobAppId = "ca-app-pub-2374435848940377~4766276481";// "ca-app-pub-2374435848940377~4175128124";
	private static string admobBannerId = "ca-app-pub-2374435848940377/7200868131";
	private static string admobPopupId = "ca-app-pub-2374435848940377/9635459785";
	private static string admobRewardId = "ca-app-pub-2374435848940377/5696214776";
	

	private static GoogleAdsCtrl _instance;
 
    public static GoogleAdsCtrl Instance {
        get { return _instance; }
    }



    private InterstitialAd interstitial = null;
    private BannerView bannerView;
	private RewardBasedVideoAd rewardBasedVideo;


    void Start () {
        _instance = this;
        Debug.Log("GOOGLE INITTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(admobAppId);
		this.rewardBasedVideo = RewardBasedVideoAd.Instance;
		rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;

		this.RequestRewardBasedVideo();
		this.RequestInterstitial ();


	}
	

	private void RequestRewardBasedVideo()
	{
		// Load the rewarded video ad with the request.
		this.rewardBasedVideo.LoadAd(getAdRequest(), admobRewardId);
	}

    public void ShowBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(admobBannerId, AdSize.Banner, AdPosition.Top);
        bannerView.OnAdLoaded += BannerView_OnAdLoaded;
        bannerView.OnAdFailedToLoad += BannerView_OnAdFailedToLoad;
        // Load the banner with the request.
		bannerView.LoadAd(getAdRequest());
    }

    private void BannerView_OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        AdsMediaAI.activeUnity();
    }

    private void BannerView_OnAdLoaded(object sender, EventArgs e)
    {
        AdsMediaAI.ShowBanner();
    }


    private AdRequest getAdRequest(){
		return new AdRequest.Builder()
		// .AddExtra("max_ad_content_rating", "T")
		.Build();
	}

	private void RequestInterstitial()
	{

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(admobPopupId);
 		this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Load the interstitial with the request.
		interstitial.LoadAd(getAdRequest());
    }

 	public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Debug.Log("sender  " + sender);
		
		interstitial.LoadAd(getAdRequest());
    }


	public bool ShowInterstitial()
	{
		if (interstitial != null && interstitial.IsLoaded())
		{
			interstitial.Show();
			return true;
		}
		return false;
	}

    public bool ShowRewardAds()
    {
        if (rewardBasedVideo != null && rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
            return true;
        }
        return false;
    }


    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
        MainCtrl.onX2Reward();
        this.rewardBasedVideo.LoadAd(getAdRequest(), admobRewardId);
        Debug.Log ("HandleRewardBasedVideoRewarded");
	}

    public void HideBanner()
    {
        if(bannerView != null)
        {
            bannerView.Hide();
        }
    }
}
