using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCardEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr, typeImgSpr;
	public GameObject cardWindow, chpBtn1,chpBtn2, typeBtn1, typeBtn2, typeBtn3, typeBtn4, typeBtn5, typeBtn6;
	int chpNum = 0, typeNum = 0;
	AllNumber allNum = new AllNumber ();

	public GameObject mixCardWid, powderCardWid;

	public void showCardWindow(){
		cardWindow.SetActive (true);
		chpNum = allNum.chapter1;
		typeNum = allNum.typeWho;
		changeChapter ();
		changeType ();
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
		case 2 : //챕터2
			chpBtn1.GetComponent<Image> ().sprite = chpImgSpr [0];
			chpBtn2.GetComponent<Image> ().sprite = chpImgSpr [3];
			break;
		}
	}

	public void clickType1(){
		typeNum = allNum.typeWho;
		changeType ();
	}

	public void clickType2(){
		typeNum = allNum.typeWhen;
		changeType ();
	}

	public void clickType3(){
		typeNum = allNum.typeWhere;
		changeType ();
	}

	public void clickType4(){
		typeNum = allNum.typeAct;
		changeType ();
	}

	public void clickType5(){
		typeNum = allNum.typeWhat;
		changeType ();
	}

	public void clickType6(){
		typeNum = allNum.typeEnd;
		changeType ();
	}

	void changeType(){
		switch (typeNum) {
		case 1: //누가
			allTypeClose();
			typeBtn1.GetComponent<Image> ().sprite = typeImgSpr [1];
			break;
		case 2: //언제
			allTypeClose();
			typeBtn2.GetComponent<Image> ().sprite = typeImgSpr [3];
			break;
		case 3: //어디서
			allTypeClose();
			typeBtn3.GetComponent<Image> ().sprite = typeImgSpr [5];
			break;
		case 4: //행동
			allTypeClose();
			typeBtn4.GetComponent<Image> ().sprite = typeImgSpr [7];
			break;
		case 5: //무엇을
			allTypeClose();
			typeBtn5.GetComponent<Image> ().sprite = typeImgSpr [11];
			break;
		case 6: //결말
			allTypeClose();
			typeBtn6.GetComponent<Image> ().sprite = typeImgSpr [9];
			break;
		}
	}

	void allTypeClose(){
		typeBtn1.GetComponent<Image> ().sprite = typeImgSpr [0];
		typeBtn2.GetComponent<Image> ().sprite = typeImgSpr [2];
		typeBtn3.GetComponent<Image> ().sprite = typeImgSpr [4];
		typeBtn4.GetComponent<Image> ().sprite = typeImgSpr [6];
		typeBtn5.GetComponent<Image> ().sprite = typeImgSpr [10];
		typeBtn6.GetComponent<Image> ().sprite = typeImgSpr [8];
	}

	public void mixCard(){
		mixCardWid.SetActive (true);
	}


	public void powderCard(){
		powderCardWid.SetActive (true);
	}

	public void cardWidClose(){
		mixCardWid.SetActive (false);
		powderCardWid.SetActive (false);
	}


}
