using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleShopEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr;
	public GameObject shopWindow, shopIWindow, chpBtn1,chpBtn2;

	public GameObject shopChoPop, cardChoPop;
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
	int number;


	//돈
	public Text coin_txt;
	string str;


	/// <summary>
	/// Shows the shop window.
	/// 처음띠워질때 챕터1을 띠움
	/// 장소,인물,행동,사물,엔딩
	/// 1돈뽑기2광고뽑기
	/// </summary>
	public void showShopWindow(){ //카드구매창
		//돈을리프레시

		str = PlayerPrefs.GetString ("code", "");
		coin_txt.text=""+PlayerPrefs.GetInt(str,1000);

		shopWindow.SetActive (true);
		chpNum = allNum.chapter1;
		changeChapter ();

	}

	public void showShopIWindow(){ //아이템 구매창
		shopIWindow.SetActive (true);		
	}

	public void showShopChoWindow(){ //종류창
		shopChoPop.SetActive (true);		
	}
	public void closeShopChoWindow(){
		shopChoPop.SetActive (false);		
	}

	public void showCardChoWindow(){ //카드선택창
		cardChoPop.SetActive (true);		
	}
	public void closeCardChoWindow(){
		cardChoPop.SetActive (false);		
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
	public void buyCard1(){
		number = 5;
		randomCard (4,5);
	}

	void oneCard(){

	}
	void fiveCard(){

	}

	//카드랜덤뽑기
	void randomCard(int type,int num){
		str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,1000);

		if (num == 5) {
			coin = coin + 100;
		}
		if (coin >= 200 * num) {
			int ran = DataLoad.data_list [type].Count;
			int a = 0;
			for (int i = 0; i < num; i++) {
				int r =DataLoad.data_list[type][Random.Range (0, ran)];
				randCard_i[i] = r;
				Debug.Log (randCard_i [i]);
				/*
				int k = PlayerPrefs.GetInt ("ch" + 1 + "cardnum" + r, 0);
				k++;
				PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + r, k);
				PlayerPrefs.Save ();
				*/
				coin_txt.text="100";
			}
			card_spr = GM.GetComponent<TitleCardEvt> ().cardImgReturnShop (randCard_i [0]);
			blackBack.SetActive (true);
			showCard.SetActive (true);
			showCard.GetComponent<Image> ().sprite = card_spr;
		} else {
			//돈이부족하다

		}

	}

	public void touchShopCard(){
		blackBack.SetActive (false);
		showCard.SetActive (false);
	}
}
