using System;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;

public abstract class AbstractAppodealAdsManager : MonoBehaviourUndestroyableSingleton<AbstractAppodealAdsManager>, IInterstitialAdListener 
{
    protected abstract String APP_KEY { get; }

    public static Action OnInterstitialLoaded;
    public static Action OnInterstitialFailedToLoad;
    public static Action OnInterstitialShown;
    public static Action OnInterstitialClosed;
    public static Action OnInterstitialClicked;

    void Awake() 
    {
        base.Awake(); if (_destroyed) return;

        Appodeal.initialize(APP_KEY, Appodeal.INTERSTITIAL);

        SubscribeToEvents();
    }

    void OnDestroy()
    {
        UnsubscribeToEvents();
    }

    protected void ShowInterstitial()
    {
        if (Appodeal.isLoadedWithPriceFloor(Appodeal.INTERSTITIAL))
            Appodeal.showWithPriceFloor(Appodeal.INTERSTITIAL);
    }

    public void onInterstitialLoaded()          { OnInterstitialLoaded.Emit(); }
    public void onInterstitialFailedToLoad()    { OnInterstitialFailedToLoad.Emit(); }
    public void onInterstitialShown()           { OnInterstitialShown.Emit(); }
    public void onInterstitialClosed()          { OnInterstitialClosed.Emit(); }
    public void onInterstitialClicked()         { OnInterstitialClicked.Emit(); }


    protected abstract void SubscribeToEvents();
    protected abstract void UnsubscribeToEvents();
}
