using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityADS : MonoBehaviour {

    private string gameId = "1744485";//★테스트ID , Window > Services 설정 테스트 바꿀것 1744485 test1486550
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
		int cc = 0;
		if (GM.GetComponent<TitleShopEvt>().chpNum >= 2) {
			for (int i = 60; i < PlayerPrefs.GetInt ("datacount2", 0)+60; i++) {
				cc = cc + PlayerPrefs.GetInt ("ch" + 1 + "cardnum" + i, 0);
			}
		} else {
			for (int i = 0; i < PlayerPrefs.GetInt ("datacount", 0); i++) {
				cc = cc + PlayerPrefs.GetInt ("ch" + 1 + "cardnum" + i, 0);
			}
		}
		//Debug.Log ("total" + cc);
		if (cc < 100) {
			if (Advertisement.IsReady("rewardedVideo"))
			{
				ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
				Advertisement.Show("rewardedVideo", options);
            }
            else
            {
                //광고끝
                GM.GetComponent<TitleCardEvt>().shopWarring();
                GM.GetComponent<TitleCardEvt>().warringWord_txt.text = "일일 광고 소진\n 24시간 후 사용";
            }
		} else {
			//카드수가너무많음ㄷ
			GM.GetComponent<TitleCardEvt>().shopWarring();
			GM.GetComponent<TitleCardEvt>().warringWord_txt.text="카드의 수가 너무 많아요";
		}
        
    }

    /*
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                //Debug.Log("The ad was successfully shown.");
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
            //Debug.Log("보상");
			PlayerPrefs.SetString ("saveAdtime",System.DateTime.Now.ToString());
			GM.GetComponent<TitleShopEvt> ().buyCardYes ();
            GM.GetComponent<TitleShopEvt>().adCardPop.SetActive(false);
        }
        else
        {

        }
    }


}
