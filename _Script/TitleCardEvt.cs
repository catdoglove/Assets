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
	public GameObject[] cardBlind;
	public Sprite[] card_spr;
	public static int i_tp=0;
	public GameObject cardInfoImg;
	// 카드의 갯수를표시해주는변수들
	public Text[] cardNum_txt;
	//카드가루
	public Text cardDust_txt;
	//페이드
	Color color;

	public GameObject cardWarring_obj;
	public Text warringWord_txt;

	public GameObject whenno_btn1,whenno_btn2;

	public void showCardWindow(){
		

		//카드코딩을할것임
		//일단불러오기
		//처음1챕터와 인물로선택되어있음
		//List<Dictionary<string,object>> data = CSVReader.Read("CardData");
		//dtLoad.what_list_ch1.Add(1);

		int d = PlayerPrefs.GetInt ("dust", 0);
		cardDust_txt.text = d.ToString ();

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
		for (int j = 0; j <15; j++) {
			cardNum_txt [j].text = "∞";
		}
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
		whenno_btn1.SetActive (true);
		whenno_btn2.SetActive (true);
        cardBtn[0].GetComponent<Button>().interactable = true;
        cardBtn[1].GetComponent<Button>().interactable = true;
        cardBtn[2].GetComponent<Button>().interactable = true;
        switch (typeNum) {
		case 1: //누가
			allTypeClose();
			typeBtn1.GetComponent<Image> ().sprite = typeImgSpr [1];
			break;
		case 2: //언제
                cardBtn[0].GetComponent<Button>().interactable = false;
                cardBtn[1].GetComponent<Button>().interactable = false;
                cardBtn[2].GetComponent<Button>().interactable = false;
                //whenno_btn1.SetActive (false);
                //whenno_btn2.SetActive (false);
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
			cardBlind [i].SetActive (false);
		}
		for (int j = 0; j < DataLoad.data_list [i_tp].Count; j++) {
			int num = DataLoad.data_list [i_tp] [j];
			cardBtn [j].SetActive (true);
			cardBtn [j].GetComponent<Image> ().sprite = card_spr [num];
			//카드의숫자를 띄워준다
			int h =PlayerPrefs.GetInt("ch"+1+"cardnum"+num,0);//카드갯수
			//Debug.Log(h+"====------"+num);
			cardNum_txt [j].text = ""+ h;
			//카드가 얻은 적있는 카드인지 확인해준다

			int iscb = PlayerPrefs.GetInt ("ch" + 1 + "newcard" + num, 0);
			if (iscb == 0) {
				cardBlind [j].SetActive (true);
			}

		}



			

	}
	//자신의이름을 불러와서몇번째버튼인지판단해서 맞는 그림을 띄워준다
	public void cardDetailShow(){
		//GameObject[] g_Obj = GameObject.FindGameObjectsWithTag ("Card");
		//자신의 이름을 불러옴
		string str=this.gameObject.name;
		//자신의 이름에 달린 번호를 불러옴
		int c_Num = int.Parse(str.Substring (4)) - 1;
		//카드의 인덱스를불러옴
		int num = DataLoad.data_list [i_tp] [c_Num];
		//카드그림출력
		cardInfoImg.GetComponent<Image>().sprite=card_spr[num];
		//카드번호저장
		PlayerPrefs.SetInt ("cinstantnum", c_Num);
		PlayerPrefs.SetInt ("instantnum", num);
	}

	//다른곳으로스프라이트빌려주기
	public Sprite cardImgReturnShop(int nums){
		return card_spr [nums];
	}

	//카드갈기
	public void cardChangeToDust(){
		//카드가언제카드일때는못함
		int swt = PlayerPrefs.GetInt ("instantnum", 0);
		switch (swt) {
		case 8:
			break;
		case 10:
			break;
		case 11:
			break;
		default:
			//카드불러옴 가루불러옴
			int iscn = PlayerPrefs.GetInt ("ch" + 1 + "cardnum" + PlayerPrefs.GetInt ("instantnum", 0), 0);
			int dust = PlayerPrefs.GetInt ("dust", 0);
			if (iscn > 0) {
				//카드갈기
				iscn--;
				dust = dust + 10;
				PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + PlayerPrefs.GetInt ("instantnum", 0), iscn);
				PlayerPrefs.SetInt ("dust", dust);
				PlayerPrefs.Save ();
				cardNum_txt [PlayerPrefs.GetInt ("cinstantnum", 0)].text = ""+iscn;
				cardDust_txt.text = ""+dust;
				powderCardWid.SetActive (false);
				StartCoroutine ("imgFadeOut");
			}else{
				//카드가 없어서 못갈아
				StartCoroutine ("NotReady");
				warringWord_txt.text = "카드가 없어요";
			}
			break;
		}


	}

	//카드생성
	public void dustChangeToCard(){
		//카드가언제카드일때는못함
		int swt = PlayerPrefs.GetInt ("instantnum", 0);
		switch (swt) {
		case 8:
			break;
		case 10:
			break;
		case 11:
			break;
		default:
			int iscn = PlayerPrefs.GetInt ("ch" + 1 + "cardnum" + PlayerPrefs.GetInt ("instantnum", 0), 0);
			int dust = PlayerPrefs.GetInt ("dust", 0);
			if (dust >= 100) {
				dust = dust - 100;
				iscn++;
				PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + PlayerPrefs.GetInt ("instantnum", 0), iscn);
				PlayerPrefs.SetInt ("dust", dust);
				PlayerPrefs.SetInt ("ch" + 1 + "newcard" + PlayerPrefs.GetInt ("instantnum", 0), 1);
				PlayerPrefs.Save ();
				cardNum_txt [PlayerPrefs.GetInt ("cinstantnum", 0)].text = ""+iscn;
				cardBlind [PlayerPrefs.GetInt ("cinstantnum", 0)].SetActive (false);
				cardDust_txt.text = ""+dust;
				newCardWid.SetActive (false);
				StartCoroutine ("imgFadeIn");
			} else {
				//가루가 없서 못만들어
				StartCoroutine ("NotReady");
				warringWord_txt.text = "재료가 부족해요";
			}
			break;
		}

	}


	//그거할것임페이드인
	IEnumerator imgFadeIn(){

		color = cardInfoImg.GetComponent<Image>().color;	

		for (float i = 0f; i < 1f; i += 0.05f) {
			//Debug.Log (i);
			color.a = Mathf.Lerp (0f, 1f, i);
			cardInfoImg.GetComponent<Image>().color = color;
			yield return null;
		}
		//infoCardWid.SetActive (false);
	}

	IEnumerator imgFadeOut(){

		color = cardInfoImg.GetComponent<Image>().color;	

		for (float i = 1f; i > 0f; i -= 0.05f) {
			color.a = Mathf.Lerp (0f, 1f, i);
			cardInfoImg.GetComponent<Image>().color = color;
			yield return null;
		}
		color.a = Mathf.Lerp (0f, 1f, 1f);
		cardInfoImg.GetComponent<Image>().color = color;
		//infoCardWid.SetActive (false);
	}

	//준비중
	IEnumerator NotReady(){
		cardWarring_obj.SetActive (true);
		yield return new WaitForSeconds (1f);
		cardWarring_obj.SetActive (false);
	}

	public void shopWarring(){
		StartCoroutine ("NotReady");
	}
}
