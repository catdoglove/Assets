using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLoad : MonoBehaviour {
	public static List<List<int>> data_list = new List<List<int>> ();
	public static List<List<int>> story_list_2 = new List<List<int>> ();
	public static List<List<int>> story_list =new List<List<int>>();
	string str;


    public GameObject[] titleSignGO, titleBackgGO;
    public Sprite[] titleSignSpr;
    // Use this for initialization
    void Start () {

        //PlayerPrefs.SetInt("tutorial", 0);
        //PlayerPrefs.SetInt("tutorial_i", 0);

        //언제카드처음부터가지고있게하기
        PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 8, 1);
		PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 11, 1);
		PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 10, 1);
		PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 8, 2);
		PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 11, 2);
		PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 10, 2);

		PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 67, 1);
		PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 68, 1);
		PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 67, 2);
		PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 68, 2);



        //표지판
        titleSignGO[0].GetComponent<Image>().sprite = titleSignSpr[PlayerPrefs.GetInt("decoSign", 0)];
        titleSignGO[1].GetComponent<Image>().sprite = titleSignSpr[PlayerPrefs.GetInt("decoSign", 0) + 1];
        titleSignGO[2].GetComponent<Image>().sprite = titleSignSpr[PlayerPrefs.GetInt("decoSign", 0) + 2];

        //뒷배경
        for(int i = 0; i < 12; i++)
        {
            if(PlayerPrefs.GetInt("decoBackG" + titleBackgGO[i], 0) == 1)
            {
                titleBackgGO[i].SetActive(true);
            }
        }

        dataLoadFirst ();

		//처음할때 자신만의 코드를 만들어줌
		int c=0;
		if (c == PlayerPrefs.GetInt ("first", 0)) {
			for (int i = 0; i < 16; i++) {
				int a = Random.Range (0, 16);//0~15

				switch (a) {
				case 0:
					str = str + "0";
					break;
				case 1:
					str = str + "1";
					break;
				case 2:
					str = str + "2";
					break;
				case 3:
					str = str + "3";
					break;
				case 4:
					str = str + "4";
					break;
				case 5:
					str = str + "5";
					break;
				case 6:
					str = str + "6";
					break;
				case 7:
					str = str + "7";
					break;
				case 8:
					str = str + "8";
					break;
				case 9:
					str = str + "9";
					break;
				case 10:
					str = str + "a";
					break;
				case 11:
					str = str + "b";
					break;
				case 12:
					str = str + "c";
					break;
				case 13:
					str = str + "d";
					break;
				case 14:
					str = str + "e";
					break;
				case 15:
					str = str + "f";
					break;
				default:
					break;
				}

				//코인이 저장되는 이름을 자기의 코드로해줌
				//PlayerPrefs.SetInt (str, 0);
				//튜토리얼 보여주기
			}

			PlayerPrefs.SetString ("code", str);
			Debug.Log(str);
			PlayerPrefs.SetInt ("first", 1);

			//언제카드처음부터가지고있게하기
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 8, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 11, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 10, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 8, 2);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 11, 2);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 10, 2);

			PlayerPrefs.Save ();

		}
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

		int series_2=0;
		List<Dictionary<string,object>> dataStory = CSVReader.Read ("StoryBook_2");
		for(int j=0;j<8;j++){
			story_list_2.Add (new List<int> ());
			for(int i=0;i<dataStory.Count;i++){
				int sr = (int)dataStory [i] ["Series"];
				if (sr == series_2) {
					story_list_2 [j].Add ((int)dataStory [i] ["Index"]);
					Debug.Log (dataStory [i] ["Index"]);
				} else if(sr==series_2+1){
					story_list_2 [j].Add ((int)dataStory [i] ["Index"]);
					series_2++;
					Debug.Log (dataStory [i] ["Index"]+"끝");
					break;
				}
			}
			series_2++;
		}



		
		//1챕터 로드-------------------------------------1
		List<Dictionary<string,object>> data = CSVReader.Read ("CardData");
		PlayerPrefs.SetInt ("datacount",data.Count);
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


		//1챕터 로드-------------------------------------1
		List<Dictionary<string,object>> data2 = CSVReader.Read ("CardData_2");
		PlayerPrefs.SetInt ("datacount2",data2.Count);
		int ch_i2 = 2;
		int tp_i2 = 1;
		for (int j = 6; j < 12; j++) {
			//리스트1차배열생성[0][0]------------------------2
			data_list.Add(new List<int>());
			//포문안에서2차열생성----------------------------3
			for (int i = 0; i < data2.Count; i++) {
				int ch = (int)data2 [i] ["Chapter"];
				int tp = (int)data2 [i] ["Type"];
				if (ch == ch_i2) {
					if (tp == tp_i2) {
						data_list [j].Add ((int)data2 [i] ["Index"]);
					}
				}
			}//endOfFor
			tp_i2++;
		}//endOfFor

	}
}
