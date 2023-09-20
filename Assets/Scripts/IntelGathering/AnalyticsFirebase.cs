using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Analytics;

public  class AnalyticsFirebase : MonoBehaviour
{
    private static bool readyToUse = false;

    void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //  var app = FirebaseApp.DefaultInstance;
                // Set a flag here to indicate whether Firebase is ready to use by your app.
                readyToUse = true;
            }
            else
            {
                Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public static void InAppPurchaseEvent()
    {
        if (!readyToUse) return;
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventPurchase);
    }


    public static void InterstitialAdEvent()
    {
        if (!readyToUse) return;
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAdImpression, new Parameter("Ad_Type", "Interstitial_Ad"));
    }
    public static void RewardedAdEvent()
    {
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAdImpression, new Parameter("Ad_Type", "Rewarded_Ad"));
    }
    public void BannerAd()
    {
        if (!readyToUse) return;
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAdImpression, new Parameter("Ad_Type", "Banner_Ad"));
    }

    public void LogEvent(string eventName)
    {
        if (!readyToUse) return;
        FirebaseAnalytics.LogEvent(eventName);

    }
    public void LevelUp(int eventName)
    {
        if (!readyToUse) return;
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelUp, new Parameter(FirebaseAnalytics.ParameterLevel, eventName));
    }
}
