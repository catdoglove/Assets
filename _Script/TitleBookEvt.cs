using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBookEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr;
	public GameObject bookWindow,chpBtn1,chpBtn2;
	int chpNum = 0, bookNum = 0, pageNum = 0;
	public Text pageTxt;
	public int[] bookLoad = new int[22];
	public GameObject[] blind;

	AllNumber allNum = new AllNumber ();

	public void showBookWindow(){
		int k;
		int n=0;
		for (int i = 0; i < 22; i++) {
			k = i + 1;
			bookLoad [i] = PlayerPrefs.GetInt ("books"+k, 0);//도감모으기에 성공한걸불러오기
		}
		//if (bookLoad[0] == 1) {
				//blind [0].SetActive (false);
			//}
		//여기에서 불러온값을 확인해서 도감의책 모든페이지 완성여부판단
		//data핸들러로간다 n/5 다모으면 max



		bookWindow.SetActive (true);
		chpNum = allNum.chapter1;
		bookNum = 1;
		pageNum = 1;
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

	public void clickLeft(){
		if (pageNum <= 1) {
			//pageTxt.text = "끝 " + pageNum + "페이지";
		}
		else 
			if(pageNum <= 5){
			pageNum = pageNum - 1;
			pageTxt.text = "여기는 " + pageNum + "페이지";
			switch (pageNum) {
				case 1:
					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
			}
		}
		//해당 페이지 내용을 보여주는 함수 추가할것
	}

	public void clickRight(){
		if(pageNum >= 5){
			//pageTxt.text = "끝 " + pageNum + "페이지";
		}
		else if(pageNum > 0){
			pageNum = pageNum + 1;
			pageTxt.text = "여기는 " + pageNum + "페이지";
			switch (pageNum) {
			case 1:
				break;
			case 2:
				break;
			case 3:
				break;
			case 0:
				break;
			}

		}
	}

}
