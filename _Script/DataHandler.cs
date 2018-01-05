using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour {


	List<int> index_list =new List<int>();


	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//데이터를 불러오는 함수 불러오는값: 게임 플레이 순서별로 해당되는 타입의 배열반환하는 값 s -1
	public List<int> LoadData(int ch_num, int tp_num){
		List<Dictionary<string,object>> data = CSVReader.Read("CardData");

		int i_chapter = ch_num;
		int i_type = tp_num;


		switch (tp_num) {
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;

		}
		int ci = 0;
		for(var i=0; i< data.Count; i++){
			int ch = (int)data[i]["Chapter"];
			int tp = (int)data[i]["Type"];
			if (ch == i_chapter) {
				if (tp == i_type) {
					int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
					if (h_Card == 1) {
						index_list.Add(i + 1);
						Debug.Log (index_list[ci].ToString ()+"리스트"+index_list.Count);
						ci++;
					}
				}
			}

		}
		return index_list;
	}//EndOfLoadData
}
