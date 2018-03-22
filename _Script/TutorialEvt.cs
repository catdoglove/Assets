using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEvt : MonoBehaviour {
	public Text tutorial_txt;
	public GameObject tutorialSpace_obj, tutorialreward_obj;
	public GameObject tutorialTalk_btn;
	public GameObject[] tutorialBack_obj;
	public int tutorial_i;
	List<Dictionary<string,object>> data;

	// Use this for initialization
	void Start () {
		int c = PlayerPrefs.GetInt ("tutorial", 0);
		if (c == 0) {
			data = CSVReader.Read ("tutorial");
			tutorialSpace_obj.SetActive (true);
			tutorial_txt.text =""+data [0] ["txt"];
			//tutorialBack_obj.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void tutorialTalkBtn(){
		if (tutorial_i < 44) {
			
			switch (tutorial_i) {
			case 91:
				break;
			case 94:
				break;
			case 99:
				break;
			case 911:
				break;
			case 912:
				break;
			case 914:
				break;
			case 920:
				break;
			case 925:
				//씬이동
				break;
			case 926:
				break;
			case 927:
				break;
			case 930:
				break;
			case 931:
				break;
			case 936:
				break;
			case 937:
				break;
			case 939:
				break;
			case 942:
				break;
			case 943:
				break;
			case 9199:
				//처음에나올카드들
				PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 9, 1);
				PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 13, 1);
				PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 5, 1);
				PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 7, 1);
				PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 34, 1);
				PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 53, 1);
				break;

			default:
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				break;
			}
		} else {
			tutorialSpace_obj.SetActive (false);
			//tutorialBack_obj.SetActive (false);
			tutorialreward_obj.SetActive (true);
			/*
		//토끼
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 4, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 4, 3);
			//거북이
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 6, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 6, 3);
			//돌
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 28, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 28, 1);
			//간
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 25, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 25, 1);
			//자다
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 45, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 45, 1);
			//속다
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 34, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 34, 1);
			//따가다
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 44, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 44, 1);
			//도망가다
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 35, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 35, 1);
			//그리고
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 52, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 52, 1);
			//지다
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 53, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 53, 1);
			//떠나다
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 46, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 46, 1);
			//돌아오다
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 47, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 47, 1);
			//당하다
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 50, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 50, 1);
			//들판
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 12, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 12, 3);
			//숲
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 22, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 22, 3);
			//바닷가
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 13, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 13, 3);
			//용궁
			PlayerPrefs.SetInt ("ch" + 1 + "newcard" + 14, 1);
			PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 14, 3);


			*/
		}
	}
}
