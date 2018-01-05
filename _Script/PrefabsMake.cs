using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsMake : MonoBehaviour {




	//프리펩
	public Transform prfCard;
	//챕터 넘버 1~~
	public static int chapter_num=1;
	public static int type_num=1;
	public GameObject obj;

	public static List<int> index_H_list =new List<int>();

	float lCardX = -6f;
	float rCardX = 6f;
	float[] CardY = {3f,1.5f,0f,-1.5f};

	//일러스트 보여주기

	public GameObject[] spr_illust;

	// Use this for initialization
	void Start () {
		//생성된 리스트에 받아온 데이터값을 넣어준다-1
		index_H_list = obj.GetComponent<DataHandler>().LoadData (chapter_num,type_num);
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
	}
	
	// Update is called once per frame
	void Update () {

		if (type_num > 1) {
			spr_illust [0].SetActive (true);
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
			while(i < 4){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			break;
		case 5:
			i = 0;
			while(i < 4){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			i = 0;
			while(i < 1){
				Instantiate (prfCard, new Vector3 (rCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}

			break;
		case 6:
			i = 0;
			while(i < 4){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			i = 0;
			while(i < 2){
				Instantiate (prfCard, new Vector3 (rCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			break;
		case 7:
			i = 0;
			while(i < 4){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			i = 0;
			while(i < 3){
				Instantiate (prfCard, new Vector3 (rCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			break;
		case 8:
			i = 0;
			while(i < 4){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			i = 0;
			while(i < 4){
				Instantiate (prfCard, new Vector3 (rCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			break;
		}
		if (cardcnt > 8) {
			i = 0;
			while(i < 4){
				Instantiate (prfCard, new Vector3 (lCardX, CardY[i], 0), Quaternion.identity);
				i++;
			}
			i = 0;
			while(i < 4){
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




}
