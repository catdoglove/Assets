using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoad : MonoBehaviour {
	public static List<List<int>> data_list =new List<List<int>>();
	public static List<List<int>> story_list =new List<List<int>>();
	// Use this for initialization
	void Start () {
		dataLoadFirst ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
		
		//1챕터 로드-------------------------------------1
		List<Dictionary<string,object>> data = CSVReader.Read ("CardData");
		int ch_i = 1;
		int tp_i = 1;
		for (int j = 0; j < 6; j++) {
			//리스트1차배열생성[0][0]------------------------2
			data_list.Add(new List<int>());
			//포문안에서2차열생성----------------------------3
			for (int i = 0; i < data.Count; i++) {
				int ch = (int)data [i] ["Chapter"];
				int tp = (int)data [i] ["Type"];
				if (ch == ch_i) {
					if (tp == tp_i) {
						data_list [j].Add (i);
					}
				}
			}//endOfFor
			tp_i++;
		}//endOfFor

		//다음챕터도 반복--------------------------------4

	}
}
