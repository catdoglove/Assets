using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoad : MonoBehaviour {
<<<<<<< HEAD
	public static List<List<int>> data_list =new List<List<int>>();
	public static List<List<int>> story_list =new List<List<int>>();
=======
	public List<int[]> who_list_ch1 =new List<int[]>();

>>>>>>> parent of 1d27cbd... 데이터를 로딩화면에서 로드한다
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

<<<<<<< HEAD
	/// <summary>
	/// 배열에 저장되는규칙 who1when2where3what4atc5end6
	/// 이렇게하는 이유는 들갈방이 세가지 [챕터][타입][순서]=인덱스값으로 가져오기때문
	/// 0->1챕터who1->1,1  내용물->[0][0]=[챕터와타입][방번호]->저장된값인덱스번호
	/// ~
	/// 5->1챕터end6->1,6
	/// 6~11 2챕터
	/// 
	/// 도감 배열에 저장되는 규칙
	/// 0->1챕터 시리즈1->1,1
	/// </summary>

	public void dataLoadFirst(){
		//이야기로딩및도감모음여부확인
		List<Dictionary<string,object>> data1 = CSVReader.Read ("StoryBook");
		int ch_c = 1;
		int sr_c = 0;
		for (int j = 0; j < 10; j++) {
			story_list.Add(new List<int>());
			for (int i = 0; i < data1.Count; i++) {
				int ch = (int)data1 [i] ["Chapter"];
				int sr = (int)data1 [i] ["Series"];
				if (ch == ch_c) {
					if (sr == sr_c) {
						story_list [j].Add (i + 1);
					}
				}
			}//endOfFor
			sr_c++;
		}//endOfFor
		
=======
	public void dataLoadFirst(){
>>>>>>> parent of 1d27cbd... 데이터를 로딩화면에서 로드한다
		//1챕터 로드-------------------------------------1
		List<Dictionary<string,object>> data = CSVReader.Read ("StoryBook");
		//리스트1차배열생성[0][0]------------------------2
		//포문안에서2차열생성----------------------------3
		//다음챕터도 반복--------------------------------4
		int k = 0;
		for (var i = 0; i < data.Count; i++) {
			int ch = (int)data [i] ["Chapter"];
			int tp = (int)data [i] ["Type"];
			if (ch == 1) {
				if (tp == 1) {
					i++;
					//PlayerPrefs.SetInt ("who" + k, i);
					i--;
					k++;
				}
			}
		}
	}
}
