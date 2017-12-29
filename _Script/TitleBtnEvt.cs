using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBtnEvt : MonoBehaviour {

	public GameObject blackBackImg, bookWindow, cardWindow, shopWindow, optionWindow, startWindow;

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
		optionWindow.SetActive (false);
		startWindow.SetActive (false);
		blackBackImg.SetActive (false);
	}

}
