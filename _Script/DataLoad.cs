using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoad : MonoBehaviour {
	public List<int[]> who_list_ch1 =new List<int[]>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void dataLoadFirst(){
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
