using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleShopEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr;
	public GameObject shopWindow, chpBtn1,chpBtn2;
	int chpNum = 0;


	AllNumber allNum = new AllNumber ();

	//카드뽑기
	public GameObject[] getCards;
	public Sprite[] card_spr;
	public static int gameCoin;
	//카드뽑기카드이미지
	public GameObject blackBack;
	public GameObject showCard;


	//돈
	public Text coin_txt;
	string str;

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
			switch (num) {
			case 1:
				a = Random.Range (0, ran);

				break;
			case 5:
				a = Random.Range (0, ran);
				break;
			default:
				break;
			}
			blackBack.SetActive (true);
			showCard.SetActive (true);
		} else {
			//돈이부족하다
		}

	}

	public void touchShopCard(){
		
	}
}
