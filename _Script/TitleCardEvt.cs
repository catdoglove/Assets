using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCardEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr, typeImgSpr;
	public GameObject cardWindow, chpBtn1,chpBtn2, typeBtn1, typeBtn2, typeBtn3, typeBtn4, typeBtn5, typeBtn6;
	int chpNum = 0, typeNum = 0;
	AllNumber allNum = new AllNumber ();
	//미리로드해둔 데이터를 가져오기위해서


	public GameObject mixCardWid, powderCardWid, newCardWid, infoCardWid;


	/// <summary>
	/// 카드오브젝트컨트롤
	/// 카드그림스프라이트인스펙터에서불러오기
	/// </summary>
	public GameObject[] cardBtn;
	public Sprite[] card_spr;

	public static int i_tp=0;

	public void showCardWindow(){
		

		//카드코딩을할것임
		//일단불러오기
		//처음1챕터와 인물로선택되어있음
		//List<Dictionary<string,object>> data = CSVReader.Read("CardData");
		//dtLoad.what_list_ch1.Add(1);

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
		initializeCard ();
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
		initializeCard ();
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

	public void newCard(){
		newCardWid.SetActive (true);
	}

	public void infoCard(){
		infoCardWid.SetActive (true);
	}

	public void infoCardclose(){
		infoCardWid.SetActive (false);
	}


	public void cardWidClose(){
		mixCardWid.SetActive (false);
		powderCardWid.SetActive (false);
		newCardWid.SetActive (false);
	}


	public void initializeCard(){//카드셋엑티브false로초기화
		/*
		for (int i = 0; i < 16; i++) {
			cardBtn [i].SetActive (true);
			cardBtn [i].GetComponent<Image> ().sprite = card_spr [i];
		}
		*/
		//배열에들어갈숫자계산
		i_tp = (chpNum-1) * 6 + typeNum-1;
		//전부초기화
		for (int i = 0; i < 16; i++) {
			cardBtn[i].SetActive (false);
		}
		for (int j = 0; j < DataLoad.data_list [i_tp].Count; j++) {
			int num = DataLoad.data_list [i_tp] [j];
			cardBtn [j].SetActive (true);
			cardBtn [j].GetComponent<Image> ().sprite = card_spr [num];
		}

			

	}
	//자신의이름을 불러와서몇번째버튼인지판단해서 맞는 그림을 띄워준다
	public void cardDetailShow(){
		//GameObject[] g_Obj = GameObject.FindGameObjectsWithTag ("Card");
		//자신의 이름을 불러옴
		string str=this.gameObject.name;
		//자신의 이름에 달린 번를 불러옴
		int c_Num = int.Parse(str.Substring (4)) - 1;
		//카드의 인덱스를불러옴
		int num = DataLoad.data_list [i_tp] [c_Num];
		//카드그림출력

	}



}
