using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour {

	public GameObject newImg;


	List<int> index_list =new List<int>();



	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//엔딩을 로드
	public int LoadEnd(int ch_num, int[] end_num){

		List<Dictionary<string,object>> data;

		int k=0;
		if (ch_num >= 2) {
			k = 30 * (ch_num - 1) - 1;
			data = CSVReader.Read("StoryBook_2");
		} else {
			data = CSVReader.Read("StoryBook");
		}
		for (var i = 0; i < data.Count; i++) {
			int ch = (int)data[i]["Chapter"];
			int one = (int)data[i]["First"];
			if (ch == ch_num) {
				if (end_num [0] == one) {
					one = (int)data[i]["Second"];
					if (end_num [1] == one) {
						one = (int)data[i]["Third"];
						if (end_num [2] == one) {
							one = (int)data[i]["Fourth"];
							if (end_num [3] == one) {
								one = (int)data[i]["Fifth"];
								if (end_num [4] == one) {
									one = (int)data[i]["Sixth"];
									if (end_num [5] == one) {
										//SceneManager.LoadScene("title");

										k = i + 1;
										//새로얻은이야기인지확인해서뉴표시를띄워주자!
										//돈500+500
										if (PlayerPrefs.GetInt ("books" + k, 0) == 0) {
											newImg.SetActive (true);
											PlayerPrefs.SetInt ("new", 1);
										}
										PlayerPrefs.SetInt ("books" + k, 1);//도감에저장
										//Debug.Log ("---------------------------------------성공");
										//카드소모
										for (int j = 1; j < 6; j++) {
											end_num [j]--;
											int iscn = PlayerPrefs.GetInt ("ch" + 1 + "cardnum" + end_num [j], 0);
											iscn--;
											PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + end_num [j], iscn);
											PlayerPrefs.Save ();
										}//endOfFor

									} else {
										k = 0;
									}
								}
							}
						}
					}
				}
			}
		}//endOfFor
		return k;
	}


		
	//데이터를 불러오는 함수 불러오는값: 게임 플레이 순서별로 해당되는 타입의 배열반환하는 값 s -1
	public List<int> LoadData(int ch_num, int tp_num){


		List<Dictionary<string,object>> data;
		int help = 0;
		if (ch_num >= 2) {
			help = 60 * (ch_num - 1) - 1;
			data = CSVReader.Read("CardData_2");
			Debug.Log ("2스테이지");
		} else {
			data = CSVReader.Read("CardData");
			Debug.Log ("1스테이지");
		}

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
						i++;
						i = i + help;
						int h_Card = PlayerPrefs.GetInt ("ch"+1+"haveCard"+i,1);

						if (h_Card == 1) {
							if (ch_num >= 2) {
								index_list.Add (i+1);
							} else {
								index_list.Add (i);
							}
							ci++;
						}

						i = i - help;
						i--;
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
						i++;
						i = i + help;
						Debug.Log (i);
						int h_Card = PlayerPrefs.GetInt ("ch"+1+"haveCard"+i,1);
						if (h_Card == 1) {
							if (ch_num >= 2) {
								index_list.Add (i+1);
						} else {
							index_list.Add (i);
						}
							ci++;
						}
						i--;
						i = i - help;

					}
				}
			}//EndOfFor
			break;
		case 2://----------------------------3인물
			PrefabsMake.index_H_list.Clear();
			i_type = 1;//who카드번호

			for(var i=0; i< data.Count; i++){
				int ch = (int)data[i]["Chapter"];
				int tp = (int)data[i]["Type"];
				if (ch == i_chapter) {
					if (tp == i_type) {
						i++;
						i = i + help;
						int h_Card = PlayerPrefs.GetInt ("ch"+1+"haveCard"+i,1);
						if (h_Card == 1) {
							if (ch_num >= 2) {
								index_list.Add (i+1);
							} else {
								index_list.Add (i);
							}
							ci++;
						}
						i--;
						i = i - help;

					}
				}
			}//EndOfFor
			break;
		case 3://---------------------------4인물물건
			PrefabsMake.index_H_list.Clear();
			i_type = 4;//what카드번호
			for(var i=0; i< data.Count; i++){
				int ch = (int)data[i]["Chapter"];
				int tp = (int)data[i]["Type"];
				if (ch == i_chapter) {
					if (tp == i_type) {
						i++;
						i = i + help;
						int h_Card = PlayerPrefs.GetInt ("ch"+1+"haveCard"+i,1);


						i--;
						i = i - help;
						if (h_Card == 1) {
							i = i + help;
							if (ch_num >= 2) {
								index_list.Add (i+2);
							} else {
								index_list.Add (i+1);
							}
							i = i - help;
							int k=i+1;
							PlayerPrefs.SetInt (""+k,i_type);
							if (ch_num >= 2) {
								k = i + help+1;
								PlayerPrefs.SetInt (""+k,i_type);

								Debug.Log (i_type);
							}
							ci++;
						}

					}else if (tp == i_type-3) {
						i++;
						i = i + help;
						int h_Card = PlayerPrefs.GetInt ("ch"+1+"haveCard"+i,1);
						i--;
						i = i - help;
						if (h_Card == 1) {
							i = i + help;
							if (ch_num >= 2) {
								index_list.Add (i+2);
							} else {
								index_list.Add (i+1);
							}
							i = i - help;
							int k=i+1;
							PlayerPrefs.SetInt (""+k,i_type-3);
							if (ch_num >= 2) {
								k = i + help+1;
								PlayerPrefs.SetInt (""+k,i_type);

								Debug.Log (i_type);
							}
							ci++;

						}
					}
				}
			}//EndOfFor
			break;
		case 4://---------------------------------행동
			PrefabsMake.index_H_list.Clear ();
			int type_n = PlayerPrefs.GetInt ("" + PrefabsMake.card_index [3], 0);
                

				i_type = 5;//act카드번호
				for(var i=0; i< data.Count; i++){
					int ch = (int)data[i]["Chapter"];
					int tp = (int)data[i]["Type"];
					if (ch == i_chapter) {
						if (tp == i_type) {
							i++;
						i = i + help;
							int h_Card = PlayerPrefs.GetInt ("ch"+1+"haveCard"+i,1);
						i--;
						i = i - help;
						if (h_Card == 1) {
							i = i + help;
							if (ch_num >= 2) {
								index_list.Add (i+2);
							} else {
								index_list.Add (i+1);
							}
							i = i - help;
								int k=i+1;
								PlayerPrefs.SetInt (""+k,i_type);
							if (ch_num >= 2) {
								k = i + help+1;
								PlayerPrefs.SetInt (""+k,i_type);

								Debug.Log (i_type);
							}
								ci++;

							}
						}
					}
				}//EndOfFor
			break;

		case 5://---------------------------------배경인물+a+b+z
			PrefabsMake.index_H_list.Clear ();
			i_type = 6;//end카드번호
			for(var i=0; i< data.Count; i++){
				
				int ch = (int)data[i]["Chapter"];
				int tp = (int)data[i]["Type"];
				if (ch == i_chapter) {
					if (tp == i_type) {
						i++;
						i = i + help;
						int h_Card = PlayerPrefs.GetInt ("ch"+1+"haveCard"+i,1);
						i--;
						i = i - help;
						if (h_Card == 1) {
							i = i + help;
							if (ch_num >= 2) {
								index_list.Add (i+2);
							} else {
								index_list.Add (i+1);
							}
							i = i - help;
							int k=i+1;
							PlayerPrefs.SetInt (""+k,i_type);
							if (ch_num >= 2) {
								k = i + help+1;
								PlayerPrefs.SetInt (""+k,i_type);
								Debug.Log (i_type);
							}
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
