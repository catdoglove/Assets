﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabsMake : MonoBehaviour {




	//프리펩
	public Transform prfCard;
	//챕터 넘버 1~~
	public static int chapter_num=2;
	public static int type_num=0;
	public static int call_card = 0;
	public GameObject obj;
	public Sprite[] cardIllust_spr;

	//카드의 인덱스넘버를기억할께! when where who what what end 
	public static int[] card_index= new int[6] {0,0,0,0,0,0}; 

	//엔딩
	public static int end_mach=0;

	public static List<int> index_H_list =new List<int>();

	float lCardX = -7f;
	float rCardX = 7f;
	float[] CardY = {3.5f,1.05f,-1.4f,-1.5f};

	//일러스트 보여주기
	public GameObject[] spr_illust;
	//엔딩 보여주기
	public Sprite[] endIllust_spr;
	//엔딩페이드
	Color color, colorS;


	//성공,실패
	public static int soundck =0;
	public Sprite[] succfail_spr;
	public GameObject succfailImg;
	public GameObject succfailSpace, coinImg;
	public Text succfail_text;
	string succfail_str;
	public GameObject addAdReward_obj;
	public GameObject rewardYesNo_obj;
    public GameObject reloadCard;

    //튜토리얼
    public GameObject GM;


    //팁
    public GameObject tipBox;
    public Text tipTxt;
    int tipPageNum;
    List<Dictionary<string, object>> tipList;



    Vector3 scalee;
    public GameObject resultImg;

    // Use this for initialization
    void Start () {
		chapter_num=PlayerPrefs.GetInt ("savestage", 1);

		//생성된 리스트에 받아온 데이터값을 넣어준다-1
		index_H_list = obj.GetComponent<DataHandler>().LoadData (chapter_num,type_num);/////////////////매우중요스태틱이아닌다른함수부르기
		//리스트에 입력된 데이터를 랜덤으로 섞어준다-2
		index_H_list = obj.GetComponent<CardShuffler> ().ShuffleHandler (index_H_list);
		//카드를 클론으로 처음 생성해준다-3
		MakingCard(index_H_list.Count);

        /*
		List<Dictionary<string,object>> data = CSVReader.Read("CardData");
		for(var i=0; i< data.Count; i++){
			//Debug.Log("Index" + (i).ToString() + " : " + data[i]["Chapter"] + " " + data[i]["Type"] + " " + data[i]["Name"]);
		}
		//_exp = (int)data[0]["EXP"];
		*/

        //팁
        //PlayerPrefs.SetInt("tipnum", 12);
		tipList = CSVReader.Read("tipdata");
		if(PlayerPrefs.GetInt("tipnum", tipPageNum) < tipList.Count-1)
        {
            tipPageNum = PlayerPrefs.GetInt("tipnum", tipPageNum) + 1;
            PlayerPrefs.SetInt("tipnum", tipPageNum);
        }
        else
        {
            PlayerPrefs.SetInt("tipnum", 0);
        }        
        
        tipTxt.text = (string)tipList[tipPageNum]["tip"];

    }//End of Start
	// Update is called once per frame
	void Update () {

		//엔딩확인하기
		if(end_mach == 1){
			if (PlayerPrefs.GetInt ("tutorial", 0) == 99) {
				
			} else {
				GM.GetComponent<TutorialEvt> ().tutorialSpace_obj.SetActive (true);
			}
			int end;
			end=obj.GetComponent<DataHandler> ().LoadEnd(chapter_num,card_index);
			if (end != 0) { //성공

				//Debug.Log("성공----------------------");
                coinImg.SetActive(true);
				spr_illust [4].SetActive (true);
			
				//페이드인
				StartCoroutine ("imgFadeIn");
				spr_illust [4].GetComponent<SpriteRenderer> ().sprite = endIllust_spr [end-1];
				succfailImg.GetComponent<Image> ().sprite = succfail_spr [0];
		
				//페이드인
				StartCoroutine ("imgFadeInS");
				succfail_str="500";
                if (PlayerPrefs.GetInt("new", 0) == 1)
                {
                    succfail_str = "500 + 500";
                    PlayerPrefs.SetInt("new", 0);
                }
                succfail_text.text = succfail_str;
				soundck = 11;

				//int adRand = Random.Range (0, 3);
				//if (adRand == 1) {
				if (PlayerPrefs.GetInt ("tutorial", 0) >= 99) {
					addAdReward_obj.SetActive (true);
				}
				//}


			}else { //실패
				//페이드인
				//Debug.Log("실패----------------------");
                tipBox.SetActive(true);
                coinImg.SetActive(false);
				StartCoroutine ("imgFadeInS");
                StartCoroutine("popupZoomIn");
                succfailImg.GetComponent<Image> ().sprite = succfail_spr [1];
				succfail_str="";
				succfail_text.text = succfail_str;
				soundck = 22;	
                


			}
			spr_illust [5].SetActive (true);
			end_mach = 0;
			call_card = 0;
			
		}else if (call_card == 1) {
			if (PlayerPrefs.GetInt ("tutorial", 0) == 99) {

			} else {
				GM.GetComponent<TutorialEvt> ().tutorialSpace_obj.SetActive (true);
				PlayerPrefs.SetInt ("dontmove", 1);
			}

			//카드를 놓았을때 그림을띄워준다
			int type_check = 0;
			switch (PrefabsMake.type_num) {
			case 1:
				break;
			case 2://배경
				spr_illust [0].SetActive (true);
				spr_illust [0].GetComponent<SpriteRenderer> ().sprite = cardIllust_spr [PrefabsMake.card_index[PrefabsMake.type_num-1]-1];
				break;
			case 3://인물

				spr_illust [1].SetActive (true);
				spr_illust [1].GetComponent<SpriteRenderer> ().sprite = cardIllust_spr [PrefabsMake.card_index[PrefabsMake.type_num-1]-1];
				break;
			case 4:
				type_check = PlayerPrefs.GetInt ("" + PrefabsMake.card_index [PrefabsMake.type_num - 1], 0);
				//Debug.Log (type_check+"??????");
					spr_illust [2].SetActive (true);
					spr_illust [2].GetComponent<SpriteRenderer> ().sprite = cardIllust_spr [PrefabsMake.card_index [PrefabsMake.type_num - 1] - 1];

				break;
			case 5:
				type_check = PlayerPrefs.GetInt ("" + PrefabsMake.card_index [PrefabsMake.type_num-1], 0);
				//Debug.Log (type_check+"??????");
				if (type_check == 5) {
					spr_illust [3].SetActive (true);
					spr_illust [3].GetComponent<SpriteRenderer> ().sprite = cardIllust_spr [PrefabsMake.card_index[PrefabsMake.type_num-1]-1];
				}
					spr_illust [3].SetActive (true);
					spr_illust [3].GetComponent<SpriteRenderer> ().sprite = cardIllust_spr [PrefabsMake.card_index[PrefabsMake.type_num-1]-1];
				break;


			}

			index_H_list.Clear ();
				//생성된 리스트에 받아온 데이터값을 넣어준다-1
				index_H_list = obj.GetComponent<DataHandler> ().LoadData (chapter_num, type_num);

				index_H_list = obj.GetComponent<CardShuffler> ().ShuffleHandler (index_H_list);
				//카드를 클론으로 처음 생성해준다-3
				MakingCard (index_H_list.Count);
				call_card--;
		}
		
		
	}

	//-카드를 클론으로 처음 생성해준다-3
	public void MakingCard(int cardcnt){
		int i = 0;

		switch (cardcnt) {
		case 1:
			i = 0;
			while(i < 1){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			break;
		case 2:
			i = 0;
			while(i < 2){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			break;
		case 3:
			i = 0;
			while(i < 3){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			break;
		case 4:
			i = 0;
			while(i < 3){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			i = 0;
			while(i < 1){
				Instantiate (prfCard, new Vector3 (rCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}

			break;
		case 5:
			i = 0;
			while(i < 3){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			i = 0;
			while(i < 2){
				Instantiate (prfCard, new Vector3 (rCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			break;
		case 6:
			i = 0;
			while(i < 3){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			i = 0;
			while(i < 3){
				Instantiate (prfCard, new Vector3 (rCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			break;
		}
		if (cardcnt > 6) {
			i = 0;
			while(i < 3){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			i = 0;
			while(i < 3){
				Instantiate (prfCard, new Vector3 (rCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
		}

		/*
		Instantiate (prfCard, new Vector3 (-6f, 2.4f, 0), Quaternion.identity);
		Instantiate (prfCard, new Vector3 (-6f, 1.2f, 0), Quaternion.identity);
		Instantiate (prfCard, new Vector3 (-6f, -0.4f, 0), Quaternion.identity);
		Instantiate (prfCard, new Vector3 (-6f, -2f, 0), Quaternion.identity);
		*/	
	}


	IEnumerator imgFadeIn(){

		color = spr_illust [4].GetComponent<SpriteRenderer>().color;	

		for (float i = 0f; i < 1f; i += 0.05f) {
			color.a = Mathf.Lerp (0f, 1f, i);
			spr_illust [4].GetComponent<SpriteRenderer>().color = color;
			yield return null;
		}
	}
	IEnumerator imgFadeInS(){

		colorS = succfailImg.GetComponent<Image>().color;	

		for (float i = 0f; i < 1f; i += 0.05f) {
			colorS.a = Mathf.Lerp (0f, 1f, i);
			succfailImg.GetComponent<Image>().color = colorS;
			succfailSpace.GetComponent<Image>().color = colorS;
			yield return null;
		}
	}
	public void rewardYesNoShow(){
		rewardYesNo_obj.SetActive (true);
	}

	public void rewardYesNoClose(){
		rewardYesNo_obj.SetActive (false);
	}

	public void showAd(){
		//영상보여주기
		addAdReward_obj.SetActive (false);
		rewardYesNo_obj.SetActive (false);

		//string str = PlayerPrefs.GetString ("code", "");
		//succfail_text.text = succfail_str;
		//int coin = PlayerPrefs.GetInt (str,0); 
		//coin= coin + 500;
		//PlayerPrefs.SetInt (str, coin);
		//PlayerPrefs.Save ();
	}

    public void reloadYesNoShow()
    {
        if (PlayerPrefs.GetInt("reloadCard", 0)==16)
        {
            reloadCard.SetActive(true);
        }
        
    }

    public void reloadYesNoClose()
    {
        reloadCard.SetActive(false);
    }

    


    public void showTipLeft()
    {
        tipList = CSVReader.Read("tipdata");
        if (tipPageNum > 0)
        {
            tipPageNum--;
            tipTxt.text = (string)tipList[tipPageNum]["tip"];
        }
        else
        {
			tipPageNum = tipList.Count;
            tipTxt.text = (string)tipList[tipPageNum]["tip"];
        }
    }

    public void showTipRight()
    {
        tipList = CSVReader.Read("tipdata");
		if (tipPageNum < tipList.Count-1)
        {
            tipPageNum++;
            tipTxt.text = (string)tipList[tipPageNum]["tip"];
        }
        else
        {
            tipPageNum = 0;
            tipTxt.text = (string)tipList[tipPageNum]["tip"];
        }
    }



    IEnumerator popupZoomIn()
    {
        scalee = resultImg.transform.localScale;
        while (scalee.x >= 0.9f)
        {
            yield return new WaitForSeconds(0.01f);
            scalee.x = scalee.x - 0.008f;
            scalee.y = scalee.y - 0.008f;
            resultImg.transform.localScale = scalee;
        }
    }
}
