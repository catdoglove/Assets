using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBookEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr;
	public GameObject bookWindow,chpBtn1,chpBtn2;
	int chpNum = 0, bookNum = 0, pageNum = 0;
	public Text pageTxt;

	//도감데이터불러오기
	public int[] bookLoad = new int[22];
	public GameObject[] blind;
	public GameObject[] booksImg;
	public Sprite[] books_spr;
	public int[] bookLoadSeries;
	public int[] bookSeries;

	AllNumber allNum = new AllNumber ();

	public void showBookWindow(){
		blind [0].SetActive (true);
		blind [1].SetActive (true);
		List<Dictionary<string,object>> data = CSVReader.Read("StoryBook");

		int k=0;
		int n=0;
		for (int i = 0; i < data.Count; i++) {
			k = i + 1;
			bookLoad [i] = PlayerPrefs.GetInt ("books"+k, 0);//도감모으기에 성공한걸불러오기
		}
		//데이터불러오기
		k = 0;
		for (var i = 0; i < data.Count; i++) {
			int sr = (int)data[i]["Series"];
			bookLoadSeries [i] = sr;
			if (i != 0) {
				if (bookLoadSeries [i - 1] != bookLoadSeries [i]) {
					bookSeries [k] = i;
					k++;
				}
			}
		}//EndOfFor
		//도감완성여부판단
		for (int j = 0; j < k+1; j++) {
			int s = 0;
			for (int i = 0; i < bookSeries [j]; i++) {
				if (bookLoad [i] == 1) {
					s++;
				}
			}
			if (s == bookSeries [j]) {
				PlayerPrefs.SetInt ("clearbook" + j, 1);
			}
		}
		//다모은건 없ㅐ기\
		booksImg [0].GetComponent<Image> ().sprite = books_spr[0];
		if (PlayerPrefs.GetInt ("clearbook" + 0, 0) == 1) {
			blind [0].SetActive (false);
		}
		booksImg [1].GetComponent<Image> ().sprite = books_spr[1];
		if (PlayerPrefs.GetInt ("clearbook" + 1, 0) == 1) {
			blind [1].SetActive (false);
		}


		//그림표시하기
		//int l=0;
		//for (int i = 0; i < k; i++) {
			//booksImg [i].GetComponent<Image> ().sprite = books_spr[i];
		//}


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
		else if(pageNum <= 5){
			pageNum = pageNum - 1;
			pageTxt.text = "여기는 " + pageNum + "페이지";
			//다모은건 없ㅐ기
			closeBlind();


		
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
			//다모은건 없ㅐ기
			closeBlind();



		}
	}

	public void closeBlind(){
		int p = pageNum;
		p = p*2;
		blind [0].SetActive (true);
		blind [1].SetActive (true);
		p=p-2;
		booksImg [0].GetComponent<Image> ().sprite = books_spr[p];
		if (PlayerPrefs.GetInt ("clearbook" + p, 0) == 1) {
			blind [0].SetActive (false);
		}
		p=p+1;
		booksImg [1].GetComponent<Image> ().sprite = books_spr[p];
		if (PlayerPrefs.GetInt ("clearbook" + p, 0) == 1) {
			blind [1].SetActive (false);
		}
	}

}
