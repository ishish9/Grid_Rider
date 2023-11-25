using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdMob : MonoBehaviour
{
    [SerializeField] private int AdCounter = 0;
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;

    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {

        });
    }

    public void AdMobCounter()
    {
        AdCounter = AdCounter + 1;
    }

    public int GetAdCount(int v)
    {
        return v + AdCounter;
    }   

    public void ResetCounter()
    {
        AdCounter = 0;
    }
}