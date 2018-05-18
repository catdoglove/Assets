using System.Collections;
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
    
    //public GameObject GM;



    // Use this for initialization
    void Start () {
        RequestInterstitial();

        rewardBasedVideo = RewardBasedVideoAd.Instance;
        
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;

        RequestRewardedVideo();
    }
	

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
			coin = coin + 50;
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


    private void RequestRewardedVideo()
    {
        adUnitIdvideo = "ca-app-pub-3940256099942544/5224354917";
        // Create an empty ad request.
        request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        rewardBasedVideo.LoadAd(request, adUnitIdvideo);
    }

    //시청보상
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
       // string type = args.Type;
      //  double amount = args.Amount;
      //  print("User rewarded with: " + amount.ToString() + " " + type);
    }

    //동영상닫음
    private void HandleRewardBasedVideoClosed(object sender, System.EventArgs args)
    {
        //GM.GetComponent<TitleShopEvt>().adCardPop.SetActive(false);
        RequestRewardedVideo();
    }

    public void showAdmobVideo()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
            Debug.Log("영상보고왔습니다");
        }
        else
        {
            //testImg.SetActive(true);
        }
    }


}
