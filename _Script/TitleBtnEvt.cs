using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleBtnEvt : MonoBehaviour {

	public GameObject blackBackImg, bookWindow, cardWindow, shopWindow, shopIWindow,optionWindow, startWindow,goGameWindow;
	public GameObject TitleSpr;


	//카드가없을때뜨는경고
	public string[] not_str;
	public Text warring_txt;
	public GameObject warringCard;

	//고유코드띄워주기
	public Text code_txt;

	// Use this for initialization
	void Start () {
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

	public void showBlackBack(){
		blackBackImg.SetActive (true);
	}

	public void showOptionWindow(){
		string str = PlayerPrefs.GetString ("code", "");
		Debug.Log(str);
		code_txt.text = "고유ID : " + str;
		optionWindow.SetActive (true);
		showBlackBack ();
	}

	public void showStartWindow(){
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

	public void loadGame1(){
		//여기서카드가 없을때를생각해주기
		int cc = 0;
		int f = 0;
		for (int j = 0; j < 6; j++) {

			for (int i = 0; i < DataLoad.data_list [j].Count; i++) {
				
				cc = cc+ PlayerPrefs.GetInt ("ch" + 1 + "cardnum" + i, 0);
			}
			if (cc == 0) {
				not_str[6] = not_str[6]  + not_str [j];
				f = 1;
			}
		}//endOfFor
		SceneManager.LoadScene ("Game");
		if (f == 1) {
			not_str [6] =not_str [6] +"\n카드가 없습니다.";
			warring_txt.text = not_str [6];
			warringCard.SetActive (true);
			StartCoroutine ("cardNotReady");////->코룬틴
		
		} else {
		
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


}
