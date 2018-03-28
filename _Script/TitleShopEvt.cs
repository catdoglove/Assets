using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleShopEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr;
	public GameObject shopWindow, shopIWindow, chpBtn1,chpBtn2;

	public GameObject shopChoPop, adCardWnd, oneCardWnd, fiveCardWnd, buyCardPop, adCardPop;
	int chpNum = 0;



	AllNumber allNum = new AllNumber ();

	//카드뽑기
	public GameObject[] getCards;
	//public Sprite[] card_spr;
	public static int gameCoin;
	//카드뽑기카드이미지
	public GameObject blackBack;
	public GameObject showCard;
	public int[] randCard_i;
	public GameObject GM;
	public Sprite card_spr;
	public GameObject newCard;
	//카드뽑기정보전달
	int type_i, cardNum_i;
	int num_i;
	//카드페이드인
	Color color;

	//돈
	public Text coin_txt;
	string str;

	public Text coind_txt;


	//광고시간


	System.DateTime lastAdTime,nowAdTime;


	System.DateTime lastDateAdTime;
	System.TimeSpan compareAdTime;

	public Text AdTime_txt;
	public GameObject AdTime_obj;

	public void showShopChoWindow(){ //상점선택열기
		shopChoPop.SetActive (true);		
	}
	public void closeShopChoWindow(){
		shopChoPop.SetActive (false);		
	}

	/// <summary>
	/// Shows the shop window.
	/// 처음띠워질때 챕터1을 띠움
	/// 장소,인물,행동,사물,엔딩
	/// 1돈뽑기2광고뽑기
	/// </summary>
	public void showShopWindow(){ 
		//돈을리프레시

		str = PlayerPrefs.GetString ("code", "");
		coin_txt.text=""+PlayerPrefs.GetInt(str,1000);

		shopWindow.SetActive (true);
		chpNum = allNum.chapter1;
		changeChapter ();

	}//카드상점열기

	public void showShopIWindow(){ //꾸미기상점열기
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		coind_txt.text = "" + coin;
		shopIWindow.SetActive (true);		
	}
	public void showAdCardWindow(){ //광고카드
		cardNum_i = 2;
		adCardWnd.SetActive (true);		

		//광고시간
		/*
		nowAdTime=new System.DateTime(1970,1,1,0,0,0,System.DateTimeKind.Utc);
		lastAdTime = PlayerPrefs.GetString ("saveAdtime",nowAdTime.ToString());
		lastDateAdTime = System.DateTime.Parse(lastAdTime);
		compareAdTime =  System.DateTime.Now - lastDateAdTime;
		sG = (int)compareAdTime.TotalHours;
		mG = (int)compareAdTime.TotalMinutes;
		sG = sG-(sG / 60)*60;
		mG = 5 - mG;
		hG = 59- hG;
		if (hG < 0) {
			btn_gudoc.GetComponent<Button> ().interactable = true;
			hG = 0;
			mG = 0;

		} else {
			btn_gudoc.GetComponent<Button> ().interactable = false;
			string stru= string.Format(@"{0:00}"+":",hG)+string.Format(@"{0:00}",mG);
			txt_gudoc.text = stru;
		}
		*/
	}

	public void showOneCardWindow(){ //1장카드
		cardNum_i = 1;
		oneCardWnd.SetActive (true);		
	}

	public void showFiveCardWindow(){ //5장카드
		cardNum_i = 5;
		fiveCardWnd.SetActive (true);		
	}

	public void closeAOFWindow(){
		adCardWnd.SetActive (false);		
		oneCardWnd.SetActive (false);	
		fiveCardWnd.SetActive (false);		
	}

	//구매확인창들
	public void showBuyCard(){
		buyCardPop.SetActive (true);
	}

	public void showADSCard(){
		adCardPop.SetActive (true);
	}

	public void FalseBuyAdCard(){
		adCardPop.SetActive (false);
		buyCardPop.SetActive (false);
	}

	public void buyCardYes(){
		cardNumCk ();
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



	//구매버튼12개
	//구매시뽑은카드를 쭉보여준다
	public void buyAct(){
		type_i = 4;
	}
	public void buyWho(){
		type_i = 0;
	}
	public void buyEnding(){
		type_i = 5;
	}
	public void buyWhat(){
		type_i = 3;
	}
	public void buyWhere(){
		type_i = 2;
	}

	void cardNumCk(){
		num_i = cardNum_i;
		int cc = 0;
		for (int i = 0; i < PlayerPrefs.GetInt ("datacount",0); i++) {
			cc = cc + PlayerPrefs.GetInt ("ch" + 1 + "cardnum" + i, 0);
		}
		//Debug.Log ("total" + cc);
		if (cc < 100) {
			randomCard (type_i, cardNum_i);
		} else {
			//카드수가너무많음ㄷ
			GM.GetComponent<TitleCardEvt>().shopWarring();
			GM.GetComponent<TitleCardEvt>().warringWord_txt.text="카드의 수가 너무 많아요";
		}
	}


	//카드랜덤뽑기
	public void randomCard(int type,int num){
		str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);

		//할인되는 가격미리더해주기
		if (num == 5) {
			coin = coin + 100;
		}
		if (num == 2) {
			coin = coin + 400;
		}
		if (coin >= 200 * num) {
			buyCardPop.SetActive (false);
			int ran = DataLoad.data_list [type].Count;
			int a = 0;
			for (int i = 0; i < num; i++) {
				int r =DataLoad.data_list[type][Random.Range (0, ran)];
				randCard_i[i] = r;
				//Debug.Log (randCard_i [i]);

				int k = PlayerPrefs.GetInt ("ch" + 1 + "cardnum" + r, 0);
				k++;
				PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + r, k);
				PlayerPrefs.Save ();


			}
			switch (num) {
			case 1:
				coin = coin - 200;
				break;
			case 2:
				coin = coin - 400;
				break;
			case 5:
				coin = coin - 1000;
				break;
			default:
				break;
			}
			PlayerPrefs.SetInt (str, coin);
			PlayerPrefs.Save ();
			coin_txt.text=""+coin;

			//옆집에서스프라이트가져오기
			card_spr = GM.GetComponent<TitleCardEvt> ().cardImgReturnShop (randCard_i [0]);
			blackBack.SetActive (true);
			showCard.SetActive (true);
			StartCoroutine ("imgFadeIn");
			showCard.GetComponent<Image> ().sprite = card_spr;
			//지금 뽑은 카드가 새 카드인지 확인해보자
			int isnc = 0;
			isnc = PlayerPrefs.GetInt ("ch" + 1 + "newcard" + randCard_i [0], 0);
			if (isnc == 0) {
				//뉴 표시를 보여줌
				newCard.SetActive (true);
				PlayerPrefs.SetInt ("ch" + 1 + "newcard" + randCard_i [0], 1);
				PlayerPrefs.Save();
			}
		} else {
			//돈이부족하다
			GM.GetComponent<TitleCardEvt>().shopWarring();
			GM.GetComponent<TitleCardEvt>().warringWord_txt.text="코인이 부족해요";
			if (num == 5) {
				coin = coin - 100;
			}
		}


	}

	//뽑은카드와검은화면을터치했을때
	public void touchShopCard(){
		newCard.SetActive (false);
		blackBack.SetActive (false);
		showCard.SetActive (false);

		switch (num_i) {
		case 1:
			GM.GetComponent<TutorialEvt> ().tutorialTalkBtn ();
			break;
		default:
			num_i--;
			card_spr = GM.GetComponent<TitleCardEvt> ().cardImgReturnShop (randCard_i [num_i]);
			showCard.GetComponent<Image> ().sprite = card_spr;
			blackBack.SetActive (true);
			showCard.SetActive (true);
			StartCoroutine ("imgFadeIn");
			//지금 뽑은 카드가 새 카드인지 확인해보자
			int isnc = 0;
			isnc = PlayerPrefs.GetInt ("ch" + 1 + "newcard" + randCard_i [num_i], 0);
			if (isnc == 0) {
				//뉴 표시를 보여줌
				newCard.SetActive (true);
				PlayerPrefs.SetInt ("ch" + 1 + "newcard" + randCard_i [num_i], 1);
				PlayerPrefs.Save();
			}

			break;
		}

	}


	//그거할것임페이드인
	IEnumerator imgFadeIn(){

		color = showCard.GetComponent<Image>().color;	

		for (float i = 0f; i < 1f; i += 0.05f) {
			color.a = Mathf.Lerp (0f, 1f, i);
			showCard.GetComponent<Image>().color = color;
			yield return null;
		}
	}

}
