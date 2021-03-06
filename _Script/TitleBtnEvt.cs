﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleBtnEvt : MonoBehaviour {

	public GameObject blackBackImg, bookWindow, cardWindow, shopWindow, shopIWindow,optionWindow, startWindow,goGameWindow;
	public GameObject TitleSpr, goOutPop;
    

    //카드가없을때뜨는경고
    public string[] not_str;
	public Text warring_txt;
	public GameObject warringCard;

	//고유코드띄워주기
	public Text code_txt;

	//챕터확인
	public int chNum=0;

    public Sprite[] windowBGImg;
    public GameObject[] windowBG;


    // Use this for initialization
    void Start () {
        //PlayerPrefs.SetInt(PlayerPrefs.GetString("ㅗ", ""), 0); //돈코딩★★★★

        //화면 해상도
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
		float screenNum =(float)Screen.height/(float)Screen.width;
		if (screenNum < 0.57f) {						
			Screen.SetResolution (Screen.width, Screen.width / 16 * 9, true);
		} else if (screenNum >= 0.57f && screenNum < 0.62f) {
			Screen.SetResolution (Screen.width, Screen.width / 5 * 3, true);
		} else if (screenNum >= 0.62f && screenNum < 0.65f) {
			Screen.SetResolution (Screen.width, Screen.width / 16 * 10, true);
		} else if (screenNum >= 0.65f && screenNum < 0.7f) {
			Screen.SetResolution (Screen.width, Screen.width / 3 * 2, true);
		} else if (screenNum >= 0.7f) {
			Screen.SetResolution (Screen.width, Screen.width / 4 * 3, true);
		} else {
			Screen.SetResolution (Screen.width, Screen.width / 3 * 2, true);
		}
    }


    // Update is called once per frame
    void Update()
    {
        //나가기 팝업듸우고 4번에 1번씩 전면광고?
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            goOutPop.SetActive(true);
        }
    }

    //나가기팝업
    public void outYes()
    {
        Application.Quit();
    }
    public void OutNo()
    {
        goOutPop.SetActive(false);
    }


    public void showBlackBack(){
		blackBackImg.SetActive (true);
	}

	public void showOptionWindow(){
		string str = PlayerPrefs.GetString ("code", "");
		//Debug.Log(str);
		code_txt.text = "고유ID : " + str;
		optionWindow.SetActive (true);
		showBlackBack ();
	}

	public void showStartWindow(){
		PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 8, 1);
		PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 11, 1);
		PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 10, 1);
		startWindow.SetActive (true);
		showBlackBack ();
	}

	public void closeWindow(){
		bookWindow.SetActive (false);
		cardWindow.SetActive (false);
		shopWindow.SetActive (false);
		shopIWindow.SetActive (false);
		optionWindow.SetActive (false);
		startWindow.SetActive (false);
		blackBackImg.SetActive (false);
		goGameWindow.SetActive (false);
	}

	public void chanter1(){
		chNum = 1;
	}

	public void chanter2(){
		chNum = 2;
	}


	public void loadGame1(){
		//여기서카드가 없을때를생각해주기
		int cc = 0;
		int f = 0;
		int k = 1;
		int chs = 0;
		if (chNum >= 2) {
			chs = 6 * (chNum - 1);
		}
		PlayerPrefs.SetInt ("savestage", chNum);

		for (int j = chs; j < 6+chs; j++) {
			cc = 0;
			for (int i = 0; i < DataLoad.data_list [j].Count; i++) {
				k = DataLoad.data_list [j] [i];
				cc = cc+ PlayerPrefs.GetInt ("ch" + 1 + "cardnum" + k, 0);
				//Debug.Log (k+"=========="+cc);
			}
			if (cc == 0) {
				//Debug.Log (j);
				if (chNum >= 2) {
					not_str [6] = not_str [6] + not_str [j-6];
				} else {
					not_str [6] = not_str [6] + not_str [j];
				}
				f = 1;
			}
		}//endOfFor

		if (f == 1) {
			if (PlayerPrefs.GetInt ("tutorial", 0) == 0) {
				SceneManager.LoadScene ("Game");
			} else {
				not_str [6] = not_str [6] + "\n카드가 없습니다.";
				warring_txt.text = not_str [6];
				warringCard.SetActive (true);
				StartCoroutine ("cardNotReady");
			}
		} else {
			//카드초기화
			int h = 1;
			for (int i = 0; i < 150; i++) {
				PlayerPrefs.SetInt ("ch"+1+"haveCard"+h,0);
			}
			List<Dictionary<string,object>> data;
			if (chNum >= 2) {
				data = CSVReader.Read ("CardData_2");
				chs = 60 * (chNum - 1);
			} else {
				data = CSVReader.Read("CardData");
			}
			for (var i = 0; i < data.Count; i++) {
				
				//PlayerPrefs.SetInt ("ch" + h + "haveCard" + i, 1);
				int hm = (int)data[i]["Index"];
				i = i + chs;
				h = i + 1;
				if (chNum >= 2) {
					h = i;
				}
				if (PlayerPrefs.GetInt ("tutorial_i", 0) == 4) {

				} else {
					PlayerPrefs.SetInt ("ch"+1+"haveCard"+h,0);//가지고있는카드초기화
				}
				int ccc = PlayerPrefs.GetInt ("ch"+1+"cardnum"+i,0);//카드수
				ccc--;
				//Debug.Log ("i=" + i + "cc" + ccc);


				if (PlayerPrefs.GetInt ("tutorial_i", 0) == 4) {

				}else if (ccc >= 0) {
					PlayerPrefs.SetInt ("ch"+1+"haveCard"+h,1);
				}//EndOfIf
				i = i - chs;
				PlayerPrefs.Save();

			}//EndOfFor
			SceneManager.LoadScene ("Game");
			//SceneManager.LoadScene ("Game");
		}
	}


	public void titleSprFalse(){
		TitleSpr.SetActive (false);
	}

	//코룬틴<--
	IEnumerator cardNotReady(){
		
		yield return new WaitForSeconds (2f);
		warringCard.SetActive (false);
		not_str [6] = "";
	}

	public void goGameWidT(){
		goGameWindow.SetActive (true);
	}

	public void goGameWidF(){
		goGameWindow.SetActive (false);
	}


    public void changeChapterBG1()
    {
        for(int i = 0; i < 3; i++)
        {
            windowBG[i].GetComponent<Image>().sprite = windowBGImg[i];
        }
    }

    public void changeChapterBG2()
    {
        for (int i = 3; i < 6; i++)
        {
            windowBG[i-3].GetComponent<Image>().sprite = windowBGImg[i];
        }
    }

}
