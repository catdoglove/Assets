using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBookEvt : MonoBehaviour {
	
	public Sprite [] chpImgSpr,bookpageSpr,bookstorySpr;
	public GameObject bookWindow,chpBtn1,chpBtn2,bookpageImg,pageImg;
	int chpNum = 1, bookNum = 1, pageNum = 1;
	public Text pageTxt;

	//도감데이터불러오기
	public int[] bookLoad;
	public GameObject[] blind;
	public GameObject[] booksImg;
	public Sprite[] books_spr;
	public int[] bookLoadSeries;
	public int[] bookSeries;
	int k;
	int p;

	//도감자세히표시
	public Sprite[] bookPage_spr;
	public Sprite[] bookExplain_spr;
	public GameObject bookStoryImg;
	public GameObject bookExplainImg;
	public Sprite[] bookHint_spr;

	//도감페이지넘버표시
	public GameObject[] bookPageNum;
	public Sprite[] page_spr;

	AllNumber allNum = new AllNumber ();

	public void showBookWindow(){

		//chpNum = allNum.chapter1;

		pageTxt.text = "- " + pageNum + " -";
        bookWindow.SetActive (true);

		blind [0].SetActive (true);
		blind [1].SetActive (true);

		List<Dictionary<string,object>> data;

		//k는스토리북의 인덱스넘버 데이터핸들러에서 저장됨
		int si=0; 
		if (chpNum >= 2) {
			si = 30 * (chpNum - 1) - 1;
			data = CSVReader.Read ("StoryBook_2");
			Debug.Log ("2챕터도감");
		} else {
			data = CSVReader.Read("StoryBook");
		}

		k=0;
		int n=0;
		for (int i = si; i < data.Count+si; i++) {
			k = i + 1;
			bookLoad [i] = PlayerPrefs.GetInt ("books"+k, 0);//도감모으기에 성공한걸불러오기

		}
		//이야기데이터불러오기
		//시리즈넘버가달라지는 부분을체크해서 어디서부터 어디까지가 하나 인지 확인해줌
		//가변2차원리스트배열
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
			PlayerPrefs.SetInt ("clearbook" + j, 0);
			int s = 0;
			for (int i = 0; i < bookSeries [j]; i++) {
				if (bookLoad [h] == 1) {
					
					s++;

				}
				h++;
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

		changeChapter ();
	}

	public void clickCh1(){
		pageTxt.text = "- " + pageNum + " -";
		chpNum = allNum.chapter1;
		showBookWindow ();
		changeChapter ();
		closeBlind ();
	}

	public void clickCh2(){
		pageTxt.text = "- " + pageNum + " -";
		chpNum = allNum.chapter2;
		showBookWindow ();
		chpNum = allNum.chapter2;
		changeChapter ();
		closeBlind ();
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
			pageTxt.text = "- " + pageNum + " -";
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
			pageTxt.text = "- " + pageNum + " -";
			//다모은건 없ㅐ기
			closeBlind();



		}
	}

	public void closeBlind(){
		p = pageNum;
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
		//페이지넘버를불러와 모은 도감커버를 보여준다
		p = pageNum;
		p = p * 2;
		p = p - 2;
		//이야기안에페이지가몇개있는지수를세어주는변수
		int d = 0;


		for (int i = 0; i < 5; i++) {
			bookPageNum [i].SetActive (false);
			bookPageNum [i].GetComponent<Image> ().sprite = page_spr [0];
		}

		bookStoryImg.GetComponent<Image> ().sprite = bookPage_spr [22];
		//bookExplainImg.GetComponent<Image> ().sprite = bookExplain_spr [d];

		int instant;
		if (chpNum >= 2) {
			instant = DataLoad.story_list_2 [p].Count;
		} else {
			Debug.Log (p);
			instant = DataLoad.story_list [p].Count;
		}
		Debug.Log (instant);
		for (int i = 0; i < instant; i++) {
			int st = DataLoad.story_list [p] [i]-1;
			if (chpNum >= 2) {
				st = DataLoad.story_list_2 [p] [i]-1;
			} else {
				st = DataLoad.story_list [p] [i]-1;
			}
			bookPageNum [i].SetActive (true);
			if (bookLoad [st] == 1) {
				bookPageNum [i].GetComponent<Image> ().sprite = page_spr [i + 1];
				//이야기안에페이지그림변경하기
				if (i == 0) {
					for (int g = 0; g < p; g++) {
						d = d + bookSeries [g];
					}
					bookStoryImg.GetComponent<Image> ().sprite = bookPage_spr [d];
					bookExplainImg.GetComponent<Image> ().sprite = bookExplain_spr [d];
				}
			} else {
				if (i == 0) {
					for (int g = 0; g < p; g++) {
						d = d + bookSeries [g];
					}
					bookExplainImg.GetComponent<Image> ().sprite = bookHint_spr [d];
				}
			}
			 
		}
	}
	public void showBookPage2(){
		//pageImg.GetComponent<Image> ().sprite = bookpageSpr[0];
		bookpageImg.SetActive (true);

		//도감에서 터치했을때 자세한내용을보여준다
		p = pageNum;
		p = p * 2;
		p = p - 1;
		//이야기안에페이지그림변경하기
		int d = 0;

		for (int i = 0; i < 5; i++) {
			bookPageNum [i].SetActive (false);
			bookPageNum [i].GetComponent<Image> ().sprite = page_spr [0];
		}
		bookStoryImg.GetComponent<Image> ().sprite = bookPage_spr [22];
		int instant;
		if (chpNum >= 2) {
			instant = DataLoad.story_list_2 [p].Count;
		} else {
			instant = DataLoad.story_list [p].Count;
		}
		for (int i = 0; i < instant; i++) {
			int st = DataLoad.story_list [p] [i]-1;
			if (chpNum >= 2) {
				st = DataLoad.story_list_2 [p] [i]-1;
			} else {
				st = DataLoad.story_list [p] [i]-1;
			}
			bookPageNum [i].SetActive (true);
			if (bookLoad [st] == 1) {
				bookPageNum [i].GetComponent<Image> ().sprite = page_spr [i + 1];
				//이야기안에페이지그림변경하기
				if (i == 0) {
					for (int g = 0; g < p; g++) {
						d = d + bookSeries [g];
					}
					bookStoryImg.GetComponent<Image> ().sprite = bookPage_spr [d];
					bookExplainImg.GetComponent<Image> ().sprite = bookExplain_spr [d];
				}
			} else {
				if (i == 0) {
					for (int g = 0; g < p; g++) {
						d = d + bookSeries [g];
					}
					bookExplainImg.GetComponent<Image> ().sprite = bookHint_spr [d];
				}
			} 
		}
	}

	public void closeBookPage(){
		bookpageImg.SetActive (false);
	}

	//도감이야기 자세히볼때 페이지별로보기 - bookPageChange
	#region
	public void bookPageChange1(){
		int s = 0;
		bookPageChangeShot (s);
	}
	public void bookPageChange2(){
		int s = 1;
		bookPageChangeShot (s);
	}
	public void bookPageChange3(){
		int s = 2;
		bookPageChangeShot (s);
	}
	public void bookPageChange4(){
		int s = 3;
		bookPageChangeShot (s);
	}
	public void bookPageChange5(){
		int s = 4;
		bookPageChangeShot (s);
	}
	#endregion

	//bookPageChange에서중복코드
	public void bookPageChangeShot(int s){
		int d = 0;
		int instant;

		if (chpNum >= 2) {
			instant = DataLoad.story_list_2 [p].Count;
		} else {
			instant = DataLoad.story_list [p].Count;
		}
		for (int i = 0; i < instant; i++) {
			int st = DataLoad.story_list [p] [i]-1;
			if (chpNum >= 2) {
				st = DataLoad.story_list_2 [p] [i]-1;
			} else {
				st = DataLoad.story_list [p] [i]-1;
			}
			bookPageNum [i].SetActive (true);
			if (bookLoad [st] == 1) {
				bookPageNum [i].GetComponent<Image> ().sprite = page_spr [i + 1];
				//이야기안에페이지그림변경하기
				if (i == s) {
					for (int g = 0; g < p; g++) {
						d = d + bookSeries [g];
					}
					d = d + s;
					bookStoryImg.GetComponent<Image> ().sprite = bookPage_spr [d];
					bookExplainImg.GetComponent<Image> ().sprite = bookExplain_spr [d];
				}
			} else {
				if (i == s) {
					for (int g = 0; g < p; g++) {
						d = d + bookSeries [g];
					}
					d = d + s;
					bookStoryImg.GetComponent<Image> ().sprite = bookPage_spr [22];
					bookExplainImg.GetComponent<Image> ().sprite = bookHint_spr [d];
				} 
			}
		}
	}
}
