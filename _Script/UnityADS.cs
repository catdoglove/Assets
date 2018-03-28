using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityADS : MonoBehaviour {

    private string gameId = "1486550";//★테스트ID , Window > Services 설정 테스트 바꿀것 1744485
    public string placementId = "rewardedVideo";

    public GameObject GM;

    // Use this for initialization
    void Start () {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    /*
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
    */

    private void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            //Add code to reward your player here!
            //Give coins, etc
            Debug.Log("보상");
			PlayerPrefs.SetString ("saveAdtime",System.DateTime.Now.ToString());
			GM.GetComponent<TitleShopEvt> ().buyCardYes ();
            GM.GetComponent<TitleShopEvt>().adCardPop.SetActive(false);
        }
    }


}
