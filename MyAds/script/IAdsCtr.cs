using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAdsCtr 
{
    bool ShowInterstitial();
    bool ShowRewardAds();
    void ShowBanner();
    void HideBanner();
}
