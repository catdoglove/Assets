﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobADS : MonoBehaviour {

    //전면
    InterstitialAd interstitial;
    AdRequest request;

    //영상
    private RewardBasedVideoAd rewardBasedVideo;
    string adUnitIdvideo;

    // Use this for initialization
    void Start () {

#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713"; //ID바ㄲ기★★★
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);


      //  RequestInterstitial();

        rewardBasedVideo = RewardBasedVideoAd.Instance;
        
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;

        RequestRewardedVideo();
    }

    /* 전면광고
   private void RequestInterstitial()
   {
       //ca-app-pub-9179569099191885/5213228385 우리id바꿀것★
       string adUnitId = "ca-app-pub-3940256099942544/1033173712";
       // Initialize an InterstitialAd.
       interstitial = new InterstitialAd(adUnitId);
       // Create an empty ad request.
       request = new AdRequest.Builder().Build();
       // 광고가 닫힐 때 호출됩니다.
       interstitial.OnAdClosed += EventAdClose;
       // Load the interstitial with the request.
       interstitial.LoadAd(request);
   }


   public void showAdmob()
   {
       if (interstitial.IsLoaded())
       {
           interstitial.Show();
           Debug.Log("보고왔습니다");
           string str = PlayerPrefs.GetString ("code", "");
           int coin = PlayerPrefs.GetInt (str, 0);
           coin = coin + 500;
           PlayerPrefs.SetInt (str, coin);
           interstitial.Destroy();
       }
   }


   // 전면닫음
   private void EventAdClose(object sender, System.EventArgs args)
   {
       //GM.GetComponent<TitleShopEvt>().adCardPop.SetActive(false);
       interstitial.LoadAd(request);// 전면 광고 요청	
   }
   */

    private void RequestRewardedVideo()
    {
        adUnitIdvideo = "ca-app-pub-3940256099942544/5224354917"; //ID바꿀것★★★★
        // Create an empty ad request.
        request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        rewardBasedVideo.LoadAd(request, adUnitIdvideo);
    }

    //시청보상
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
    }

    //동영상닫음
    private void HandleRewardBasedVideoClosed(object sender, System.EventArgs args)
    {
        string str = PlayerPrefs.GetString("code", "");
        int coin = PlayerPrefs.GetInt(str, 0);
        coin = coin + 500;
        PlayerPrefs.SetInt(str, coin);
        RequestRewardedVideo();
    }

    public void showAdmobVideo()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
            //Debug.Log("영상보고왔습니다");
        }
        else
        {
            //시청안된다는 메세지라도 띄워야하나 허엄
        }
    }


}
