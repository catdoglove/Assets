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
		int i_type = 0;//카드종류
		int ci = 0;

		switch (tp_num) {
		case 0://첫번째카드-------------------1
			i_type = 2;//when카드번호
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
			}//EndOfFor

			break;
		case 1://---------------------------2배경
			PrefabsMake.index_H_list.Clear();
			i_type = 3;//where카드번호

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
			}//EndOfFor
			break;
		case 2://----------------------------3배경인물
			PrefabsMake.index_H_list.Clear();
			i_type = 1;//who카드번호

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
			}//EndOfFor
			break;
		case 3://---------------------------4배경인물+A
			PrefabsMake.index_H_list.Clear();
			i_type = 4;//what카드번호
			for(var i=0; i< data.Count; i++){
				int ch = (int)data[i]["Chapter"];
				int tp = (int)data[i]["Type"];
				if (ch == i_chapter) {
					if (tp == i_type) {
						int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
						if (h_Card == 1) {
							index_list.Add(i + 1);
							int k=i+1;
							PlayerPrefs.SetInt (""+k,i_type);
							Debug.Log ("왜카드가안나오죠?"+i+1);
							Debug.Log (index_list[ci].ToString ()+"리스트"+index_list.Count);
							ci++;
						}
					}else if (tp == i_type+1) {
						int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
						if (h_Card == 1) {
							index_list.Add(i + 1);
							int k=i+1;
							PlayerPrefs.SetInt (""+k,i_type+1);
							Debug.Log ("왜카드가안나오죠?"+i+1);
							Debug.Log (index_list[ci].ToString ()+"리스트"+index_list.Count);
							ci++;
						}
					}else if (tp == i_type-3) {
						int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
						if (h_Card == 1) {
							index_list.Add(i + 1);
							int k=i+1;
							Debug.Log ("왜카드가안나오죠?"+i+1);
							PlayerPrefs.SetInt (""+k,i_type-3);
							Debug.Log (index_list[ci].ToString ()+"리스트"+index_list.Count);
							ci++;
						}
					}
				}
			}//EndOfFor
			break;
		case 4://---------------------------------배경인물+a+b
			PrefabsMake.index_H_list.Clear ();
			int type_n = PlayerPrefs.GetInt ("" + PrefabsMake.card_index [3], 0);

			Debug.Log ("왜"+PrefabsMake.card_index [3]);
			switch (type_n) {
			case 0:
				break;
			case 1:
				i_type = 5;//act카드번호
				for(var i=0; i< data.Count; i++){
					int ch = (int)data[i]["Chapter"];
					int tp = (int)data[i]["Type"];
					if (ch == i_chapter) {
						if (tp == i_type) {
							int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
							if (h_Card == 1) {
								index_list.Add(i + 1);
								int k=i+1;
								PlayerPrefs.SetInt (""+k,i_type);
								Debug.Log (index_list[ci].ToString ()+"리스트"+index_list.Count);
								ci++;
							}
						}else if (tp == i_type+1) {
							int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
							if (h_Card == 1) {
								index_list.Add(i + 1);
								int k=i+1;
								PlayerPrefs.SetInt (""+k,i_type+1);
								Debug.Log (index_list[ci].ToString ()+"리스트"+index_list.Count);
								ci++;
							}
						}
					}
				}//EndOfFor
				break;

			case 4:
				i_type = 5;//act카드번호
				for(var i=0; i< data.Count; i++){
					int ch = (int)data[i]["Chapter"];
					int tp = (int)data[i]["Type"];
					if (ch == i_chapter) {
						if (tp == i_type) {
							int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
							if (h_Card == 1) {
								index_list.Add(i + 1);
								int k=i+1;
								PlayerPrefs.SetInt (""+k,i_type);
								Debug.Log (index_list[ci].ToString ()+"리스트"+index_list.Count);
								ci++;
							}
						}else if (tp == i_type+1) {
							int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
							if (h_Card == 1) {
								index_list.Add(i + 1);
								int k=i+1;
								PlayerPrefs.SetInt (""+k,i_type+1);
								Debug.Log (index_list[ci].ToString ()+"리스트"+index_list.Count);
								ci++;
							}
						}
					}
				}//EndOfFor
				
				break;

			case 5:
				i_type = 4;//what카드번호
				for(var i=0; i< data.Count; i++){
					int ch = (int)data[i]["Chapter"];
					int tp = (int)data[i]["Type"];
					if (ch == i_chapter) {
						if (tp == i_type) {
							int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
							if (h_Card == 1) {
								index_list.Add(i + 1);
								int k=i+1;
								PlayerPrefs.SetInt (""+k,i_type);
								Debug.Log (index_list[ci].ToString ()+"리스트"+index_list.Count);
								ci++;
							}
						}else if (tp == i_type+2) {
							int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
							if (h_Card == 1) {
								index_list.Add(i + 1);
								int k=i+1;
								PlayerPrefs.SetInt (""+k,i_type+1);
								Debug.Log (index_list[ci].ToString ()+"리스트"+index_list.Count);
								ci++;
							}
						}
					}
				}//EndOfFor
				break;
			}//EndOfSwitch

			break;

		case 5://---------------------------------배경인물+a+b+z
			PrefabsMake.index_H_list.Clear ();
			i_type = 6;//end카드번호
			for(var i=0; i< data.Count; i++){
				
				int ch = (int)data[i]["Chapter"];
				int tp = (int)data[i]["Type"];
				if (ch == i_chapter) {
					if (tp == i_type) {
						int h_Card = PlayerPrefs.GetInt ("ch"+i_chapter+"haveCard"+i,1);
						if (h_Card == 1) {
							index_list.Add(i + 1);
							int k=i+1;
							PlayerPrefs.SetInt (""+k,i_type);
							Debug.Log (index_list[ci].ToString ()+"마지막리스트"+index_list.Count);
							ci++;
						}
					}
				}
			}//EndOfFor
			break;
		}//EndOfSwitch

		return index_list;
	}//EndOfLoadData
}
