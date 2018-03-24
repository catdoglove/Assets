using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEvt : MonoBehaviour {
	public Text tutorial_txt;
	public GameObject tutorialSpace_obj, tutorialreward_obj, tutotialdel_btn;
	public GameObject tutorialTalk_btn;
	public GameObject[] tutorialBack_obj;
	public int tutorial_i, game_i;
	List<Dictionary<string,object>> data;
	int b = 0;

	public GameObject[] closeall;

	// Use this for initialization
	void Start () {
		int s = PlayerPrefs.GetInt ("tutorial_i", 0);
		if (s == 4 && game_i == 4) {
			data = CSVReader.Read ("tutorial");
			tutorial_i = PlayerPrefs.GetInt ("tutorial_i", 0);

			tutorialSpace_obj.SetActive (true);
			tutorial_i++;
			tutorial_txt.text = "" + data [tutorial_i] ["txt"];
			tutotialdel_btn.SetActive (false);
		} else {
			int c = PlayerPrefs.GetInt ("tutorial", 0);
			if (c == 0) {
				data = CSVReader.Read ("tutorial");
				tutorialSpace_obj.SetActive (true);

				tutorial_txt.text = "" + data [0] ["txt"];
				//tutorialBack_obj.SetActive (true);
			}else if(c==2){
				data = CSVReader.Read ("tutorial");
				tutorialSpace_obj.SetActive (true);
				PlayerPrefs.SetInt ("tutorial_i", 25);
				tutorial_i=PlayerPrefs.GetInt ("tutorial_i", 0);
				tutorial_txt.text = "다시 모닥불로 돌아왔어요.";

			}
		}
		if (PlayerPrefs.GetInt ("tutorial", 0) == 99) {
			PlayerPrefs.SetInt ("dontmove", 2);
			tutorial_i = PlayerPrefs.GetInt ("tutorial_i", 0);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void tutorialTalkBtn(){
		if (tutorial_i < 46) {
			switch (tutorial_i) {
			case 1:
				tutorialBack_obj [0].SetActive (true);
				tutorialSpace_obj.SetActive (false);
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				break;
			case 2:
				if (b == 0) {
					tutorialBack_obj [0].SetActive (false);
					tutorialSpace_obj.SetActive (true);
					b++;
				} else {
					tutorial_i++;
					tutorial_txt.text = "" + data [tutorial_i] ["txt"];
					b = 0;
				}
				break;
			case 4:
				if (b == 0) {
					tutorialBack_obj [1].SetActive (true);
					tutorialSpace_obj.SetActive (false);
					b++;
				} else {
					tutorialBack_obj [1].SetActive (false);
					tutorialBack_obj [2].SetActive (true);
					//처음에나올카드들
					for(int i=0;i<54;i++){
						PlayerPrefs.SetInt ("ch"+1+"haveCard"+i,0);
					}
					PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 8, 1);
					PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 12, 1);
					PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 6, 1);
					PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 4, 1);
					PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 33, 1);
					PlayerPrefs.SetInt ("ch" + 1 + "cardnum" + 52, 1);

					PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 9, 1);
					PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 13, 1);
					PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 7, 1);
					PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 5, 1);
					PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 34, 1);
					PlayerPrefs.SetInt ("ch" + 1 + "haveCard" + 53, 1);
					PlayerPrefs.SetInt ("tutorial_i", tutorial_i);
					PlayerPrefs.SetInt ("dontmove", 1);
					PlayerPrefs.Save ();
					b = 0;
				}
				break;
			case 9:
				PlayerPrefs.SetInt ("dontmove", 2);
				tutorialSpace_obj.SetActive (false);
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				break;
			case 11:
				PlayerPrefs.SetInt ("dontmove", 2);
				tutorialSpace_obj.SetActive (false);
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				PlayerPrefs.SetInt ("tutorial_i", tutorial_i);
				break;
			case 12:
				PlayerPrefs.SetInt ("dontmove", 2);
				tutorialSpace_obj.SetActive (false);
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				PlayerPrefs.SetInt ("tutorial_i", tutorial_i);
				break;
			case 14:
				PlayerPrefs.SetInt ("dontmove", 2);
				tutorialSpace_obj.SetActive (false);
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				PlayerPrefs.SetInt ("tutorial_i", tutorial_i);
				break;
			case 17:
				PlayerPrefs.SetInt ("dontmove", 2);
				tutorialSpace_obj.SetActive (false);
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				PlayerPrefs.SetInt ("tutorial_i", tutorial_i);
				break;
			case 20:
				PlayerPrefs.SetInt ("dontmove", 2);
				tutorialSpace_obj.SetActive (false);
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				PlayerPrefs.SetInt ("tutorial_i", tutorial_i);
				PlayerPrefs.Save ();
				break;
			case 25:
				//씬이동
				if (PlayerPrefs.GetInt ("tutorial", 0) == 2) {
					
					tutorial_i++;
					tutorial_txt.text = "" + data [tutorial_i] ["txt"];

				} else {
					PlayerPrefs.SetInt ("dontmove", 2);
					tutorialSpace_obj.SetActive (false);
					PlayerPrefs.SetInt ("tutorial_i", tutorial_i);
					PlayerPrefs.SetInt ("tutorial", 2);
					PlayerPrefs.Save ();
				}
				break;
			case 26:
				tutorialBack_obj [3].SetActive (true);
				tutorialSpace_obj.SetActive (false);
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				break;
			case 27:
				if (b == 0) {
					tutorialBack_obj [3].SetActive (false);
					tutorialSpace_obj.SetActive (true);
					b++;
				} else {
					tutorialBack_obj [4].SetActive (true);
					tutorialSpace_obj.SetActive (false);
					tutorial_i++;
					tutorial_txt.text = "" + data [tutorial_i] ["txt"];
					b = 0;
				}


				break;
			case 28:
				if (b == 0) {
					tutorialBack_obj [4].SetActive (false);
					tutorialSpace_obj.SetActive (true);
					b++;
				} else {
					tutorial_i++;
					tutorial_txt.text = "" + data [tutorial_i] ["txt"];
					b = 0;
				}
				break;
			case 30:
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				closeall [0].SetActive (false);
				closeall [1].SetActive (false);
				closeall [2].SetActive (false);
				break;
			case 31:
				if (b == 0) {
					tutorialBack_obj [5].SetActive (true);
					tutorialSpace_obj.SetActive (false);
					b++;
				} else {
					tutorialBack_obj [5].SetActive (false);
					tutorialSpace_obj.SetActive (true);
					tutorial_i++;
					tutorial_txt.text = "" + data [tutorial_i] ["txt"];
					b = 0;
				}
				break;

                case 35:
                    data = CSVReader.Read("tutorial");
                    if (b == 0)
                    {
                        tutorialBack_obj[11].SetActive(true);
                        tutorialSpace_obj.SetActive(false);
                        b++;
                    }
                    else
                    {
                        tutorialBack_obj[11].SetActive(false);
                        tutorialSpace_obj.SetActive(true);
                        tutorial_i++;
                        tutorial_txt.text = "" + data[tutorial_i]["txt"];
                        b = 0;
                        
                    }
                    break;

                case 36:
                    data = CSVReader.Read("tutorial");
                    
                        tutorial_i++;
                        tutorial_txt.text = "" + data[tutorial_i]["txt"];
                       
                        closeall[3].SetActive(false);
                        closeall[2].SetActive(false);
                        closeall[7].SetActive(false);
                    
				
				break;
			case 37:
                    data = CSVReader.Read("tutorial");
                    if (b == 0) {
					tutorialBack_obj [6].SetActive (true);
					tutorialSpace_obj.SetActive (false);
					b++;
				} else {
					tutorialBack_obj [6].SetActive (false);
					tutorialSpace_obj.SetActive (true);
					tutorial_i++;
					tutorial_txt.text = "" + data [tutorial_i] ["txt"];
					b = 0;
				}
				break;
			case 39:
                    data = CSVReader.Read("tutorial");
                    if (b == 0) {
					tutorialBack_obj [7].SetActive (true);
					tutorialSpace_obj.SetActive (false);
					b++;
				} else {
					tutorialBack_obj [7].SetActive (false);
					tutorialSpace_obj.SetActive (true);
					tutorial_i++;
					tutorial_txt.text = "" + data [tutorial_i] ["txt"];
					string str = PlayerPrefs.GetString ("code", "");
                        int coins= PlayerPrefs.GetInt(str, 0);
                        coins = coins + 900;
                        PlayerPrefs.SetInt(str,coins);
					b = 0;
				}
				break;
			case 42:
                    data = CSVReader.Read("tutorial");
                    if (b == 0) {
					tutorialBack_obj [8].SetActive (true);
					tutorialSpace_obj.SetActive (false);
					b++;
				} else {
					tutorialBack_obj [8].SetActive (false);
					tutorialSpace_obj.SetActive (true);
					tutorial_i++;
					tutorial_txt.text = "" + data [tutorial_i] ["txt"];
					b = 0;
				}
				break;
			case 43:
                    data = CSVReader.Read("tutorial");
                    if (b == 0) {
					tutorialBack_obj [9].SetActive (true);
					tutorialSpace_obj.SetActive (false);
					b++;
				} else {
					tutorialBack_obj [9].SetActive (false);
					tutorialSpace_obj.SetActive (true);
					tutorial_i++;
					//tutorial_txt.text = "" + data [tutorial_i] ["txt"];
					b = 0;
				}
				break;
			case 44:
                    data = CSVReader.Read("tutorial");
                    if (b == 0) {
					tutorialBack_obj [10].SetActive (true);
					tutorialSpace_obj.SetActive (false);
					b++;
				} else {
					tutorialBack_obj [10].SetActive (false);
					//tutorialSpace_obj.SetActive (true);
					tutorial_i++;
					//tutorial_txt.text = "" + data [tutorial_i] ["txt"];
					b = 0;
				}
				break;
			case 48:
                    data = CSVReader.Read("tutorial");
                    tutorialSpace_obj.SetActive (false);
				tutorial_i++;
				break;
			case 45:
				data = CSVReader.Read ("tutorial");
				tutorialSpace_obj.SetActive (false);
				tutorialreward_obj.SetActive (true);
				closeall [2].SetActive (false);
				closeall [4].SetActive (false);
				closeall [5].SetActive (false);
				closeall [6].SetActive (false);
				closeall [8].SetActive (false);
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

				PlayerPrefs.SetInt ("tutorial", 99);
				PlayerPrefs.SetInt ("tutorial_i", 99);
				tutorial_i = 99;
				break;
			case 99:
				break;

			default:
				tutorial_i++;
				tutorial_txt.text = "" + data [tutorial_i] ["txt"];
				PlayerPrefs.SetInt ("tutorial_i", tutorial_i);
				PlayerPrefs.Save ();
				break;
			}
		} else {
			tutorialSpace_obj.SetActive (false);
			//tutorialBack_obj.SetActive (false);
			//tutorialreward_obj.SetActive (true);

		}
	}

	public void closeReward(){
		tutorialreward_obj.SetActive (false);
	}
}
