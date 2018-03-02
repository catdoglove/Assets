using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBookEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr,bookpageSpr,bookstorySpr;
	public GameObject bookWindow,chpBtn1,chpBtn2,bookpageImg,pageImg;
	int chpNum = 0, bookNum = 0, pageNum = 1;
	public Text pageTxt;

	//도감데이터불러오기
	public int[] bookLoad = new int[23];
	public GameObject[] blind;
	public GameObject[] booksImg;
	public Sprite[] books_spr;
	public int[] bookLoadSeries;
	public int[] bookSeries;
	int k;

	//도감페이지넘버표시
	public GameObject[] bookPageNum;
	public Sprite[] page_spr;

	AllNumber allNum = new AllNumber ();

	public void showBookWindow(){


		blind [0].SetActive (true);
		blind [1].SetActive (true);
		List<Dictionary<string,object>> data = CSVReader.Read("StoryBook");

		k=0;
		int n=0;
		for (int i = 0; i < data.Count; i++) {
			k = i + 1;
			bookLoad [i] = PlayerPrefs.GetInt ("books"+k, 0);//도감모으기에 성공한걸불러오기

		}
		//이야기데이터불러오기
		//시리즈넘버가달라지는 부분을체크해서 어디서부터 어디까지가 하나 인지 확인해줌
		//가변2차원리스트배열로고치면될지도?
		k = 0;
		for (var i = 0; i < data.Count; i++) {
			int sr = (int)data[i]["Series"];
			bookLoadSeries [i] = sr;
			if (i != 0) {
				if (bookLoadSeries [i - 1] != bookLoadSeries [i]) {
					if (k == 0) {
						bookSeries [k] = i;
					} else {
						bookSeries [k] = i;
						for (int j = k; j > 0; j--) {
							bookSeries [k] = bookSeries [k] - bookSeries [k - j];
						}
					}
					k++;
				}
			}
		}//EndOfFor
		//도감완성여부판단
		PlayerPrefs.SetInt("k",k);
		int h = 0;
		for (int j = 0; j < k+1; j++) {
			int s = 0;
			for (int i = 0; i < bookSeries [j]; i++) {
				if (bookLoad [h] == 1) {
					s++;
					h++;
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

		booksImg [0].GetComponent<Image> ().sprite = books_spr[p]; //p 페이지넘버
		if (PlayerPrefs.GetInt ("clearbook" + p, 0) == 1) {
			blind [0].SetActive (false);
		}
		p=p+1;
		booksImg [1].GetComponent<Image> ().sprite = books_spr[p];
		if (PlayerPrefs.GetInt ("clearbook" + p, 0) == 1) {
			blind [1].SetActive (false);
		}
	}

	//총22페지
	public void showBookPage1(){
		//pageImg.GetComponent<Image> ().sprite = bookpageSpr[0];
		bookpageImg.SetActive (true);

		//도감에서 터치했을때 자세한내용을보여준다
		int p = pageNum;
		p = p * 2;
		p = p - 2;
		for (int i = 0; i < 5; i++) {
			bookPageNum [i].SetActive (false);
			bookPageNum [i].GetComponent<Image> ().sprite = page_spr [0];
		}

		for (int i = 0; i < DataLoad.story_list [p].Count; i++) {
			int st = DataLoad.story_list [p] [i]-1;
			bookPageNum [i].SetActive (true);
			if (bookLoad [st] == 1) {
				bookPageNum [i].GetComponent<Image> ().sprite = page_spr [i + 1];
			} 
		}
	}
	public void showBookPage2(){
		//pageImg.GetComponent<Image> ().sprite = bookpageSpr[0];
		bookpageImg.SetActive (true);

		//도감에서 터치했을때 자세한내용을보여준다
		int p = pageNum;
		p = p * 2;
		p = p - 1;
		for (int i = 0; i < 5; i++) {
			bookPageNum [i].SetActive (false);
			bookPageNum [i].GetComponent<Image> ().sprite = page_spr [0];
		}

		for (int i = 0; i < DataLoad.story_list [p].Count; i++) {
			int st = DataLoad.story_list [p] [i]-1;
			bookPageNum [i].SetActive (true);
			if (bookLoad [st] == 1) {
				bookPageNum [i].GetComponent<Image> ().sprite = page_spr [i + 1];
			} 
		}
	}

	public void closeBookPage(){
		bookpageImg.SetActive (false);
	}

}
