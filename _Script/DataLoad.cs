using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoad : MonoBehaviour {
	public static List<List<int>> data_list =new List<List<int>>();

	// Use this for initialization
	void Start () {
		dataLoadFirst ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// 배열에 저장되는규칙 who1when2where3what4atc5end6
	/// 0->1챕터who1->1,1
	/// ~
	/// 5->1챕터end6->1,6
	/// 6~11 2챕터
	/// 
	/// </summary>

	public void dataLoadFirst(){
		
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
						data_list [j].Add (i + 1);
					}
				}
			}//endOfFor
			tp_i++;
		}//endOfFor

		//다음챕터도 반복--------------------------------4

	}
}
