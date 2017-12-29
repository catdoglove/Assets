using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBookEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr;
	public GameObject bookWindow,chpBtn1,chpBtn2;
	int chpNum = 0, bookNum = 0, pageNum = 0;
	public Text pageTxt;

	AllNumber allNum = new AllNumber ();

	public void showBookWindow(){
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
		}
	}

}
