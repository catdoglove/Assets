using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleShopEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr;
	public GameObject shopWindow, chpBtn1,chpBtn2;
	int chpNum = 0;

	AllNumber allNum = new AllNumber ();

	public void showShopWindow(){
		shopWindow.SetActive (true);
		chpNum = allNum.chapter1;
		changeChapter ();
	}

	public void clickCh1(){
		chpNum = allNum.chapter1;
		changeChapter ();
	}

	public void clickCh2(){
		chpNum = allNum.chapter2;
		changeChapter ();
	}

	void changeChapter(){
		switch(chpNum){
		case 1 : //챕터1
			chpBtn1.GetComponent<Image> ().sprite = chpImgSpr [1];
			chpBtn2.GetComponent<Image> ().sprite = chpImgSpr [2];
			break;
		case 2: //챕터2
			chpBtn1.GetComponent<Image> ().sprite = chpImgSpr [0];
			chpBtn2.GetComponent<Image> ().sprite = chpImgSpr [3];
			break;
		}
	}
}
