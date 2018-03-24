using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleDecoEvt : MonoBehaviour {

    //titleSignSpr : 15, titleBackgSpr: 12
    public Sprite[] markImgSpr, titleSignSpr;
    public GameObject markTitle, markGame, titleView, gameView, warningPop;
    public GameObject[] titleSignGO, titleBackgGO, titleItemSpr, gameItemSpr;
    int MarkNum = 0;
    int signNum = 0;

	public int[] itemPrice_i;


	//돈
	public Text coin_txt;

    void Start()
    {
		
        changeSign();

        //뒷배경
        for (int i = 0; i < 12; i++)
        {
            if (PlayerPrefs.GetInt("decoBackG" + titleBackgGO[i], 0) == 1)
            {
                titleBackgGO[i].SetActive(true);
            }
        }
        /*
        //배경초기화코드! 나중에 지울것
        for (int i = 0; i < 12; i++)
        {
            PlayerPrefs.SetInt("decoBackG" + titleBackgGO[i], 0);
            titleBackgGO[i].SetActive(false);
        }
        */
    }

        public void clickTitleMark()
    {
        MarkNum = 1;
        changeMark();
    }

    public void clickGameMark()
    {
        MarkNum = 2;
        changeMark();
    }

    void changeMark()
    {
        switch (MarkNum)
        {
            case 1: //타이틀구매
                markTitle.GetComponent<Image>().sprite = markImgSpr[1];
                markGame.GetComponent<Image>().sprite = markImgSpr[2];
                titleView.SetActive(true);
                gameView.SetActive(false);
                break;
            case 2: //게임구매
                markTitle.GetComponent<Image>().sprite = markImgSpr[0];
                markGame.GetComponent<Image>().sprite = markImgSpr[3];
                titleView.SetActive(false);
                gameView.SetActive(true);
                break;
        }
    }

    //0~3 Sign, 4~15 Backg
    // 다른 스크립트가져다쓰기
    //GM.GetComponent<TitleDecoEvt클래스명>().MarkNum = 3;

    public void item_Sign0()
    { //기본
		int g = PlayerPrefs.GetInt("sing0",0);
		int p = itemPrice_i [0];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt ("decoSign", 0);
			changeSign ();
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("sing0", 1);
			PlayerPrefs.SetInt ("decoSign", 0);
			PlayerPrefs.SetInt (str, coin);
			changeSign ();
		} else {
			StartCoroutine("cardNotReady");
        }
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
       
    }

    public void item_Sign1()
    { //붉은
		int g = PlayerPrefs.GetInt("sing1",0);
		int p = itemPrice_i [0];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt ("decoSign", 3);
			changeSign ();
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("sing1", 1);
			PlayerPrefs.SetInt ("decoSign", 3);
			PlayerPrefs.SetInt (str, coin);
			changeSign ();
		} else {
			StartCoroutine("cardNotReady");
            Debug.Log("돈부족");
        }
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }

    public void item_Sign2()
    { //푸른
		int g = PlayerPrefs.GetInt("sing2",0);
		int p = itemPrice_i [1];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt ("decoSign", 6);
			changeSign ();
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("sing2", 1);
			PlayerPrefs.SetInt ("decoSign", 6);
			PlayerPrefs.SetInt (str, coin);
			changeSign ();
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }

    public void item_Sign3()
    { //덤뷸
		int g = PlayerPrefs.GetInt("sing3",0);
		int p = itemPrice_i [2];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt ("decoSign", 9);
			changeSign ();
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("sing3", 1);
			PlayerPrefs.SetInt ("decoSign", 9);
			PlayerPrefs.SetInt (str, coin);
			changeSign ();
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }

    public void item_Sign4()
    { //덩굴
		int g = PlayerPrefs.GetInt("sing4",0);
		int p = itemPrice_i [3];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt ("decoSign", 12);
			changeSign ();
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("sing4", 1);
			PlayerPrefs.SetInt ("decoSign", 12);
			PlayerPrefs.SetInt (str, coin);
			changeSign ();
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }

    public void changeSign()
    {
        signNum = PlayerPrefs.GetInt("decoSign", 0);
        titleSignGO[0].GetComponent<Image>().sprite = titleSignSpr[signNum];
        titleSignGO[1].GetComponent<Image>().sprite = titleSignSpr[signNum + 1];
        titleSignGO[2].GetComponent<Image>().sprite = titleSignSpr[signNum + 2];
        ////Debug.Log(i);
    }

    //배경꾸밈
    public void item_BackG1()
    {
		int g = PlayerPrefs.GetInt("BackG1",0);
		int p = itemPrice_i [4];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[0], 1);
			titleBackgGO[0].SetActive(true);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG1", 1);
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[0], 1);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[0].SetActive(true);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_BackG2()
    {
		int g = PlayerPrefs.GetInt("BackG2",0);
		int p = itemPrice_i [5];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[1], 1);
			titleBackgGO[1].SetActive(true);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG2", 1);
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[1], 1);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[1].SetActive(true);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);

    }
    public void item_BackG3()
    {
		int g = PlayerPrefs.GetInt("BackG3",0);
		int p = itemPrice_i [6];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[2], 1);
			titleBackgGO[2].SetActive(true);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG3", 1);
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[2], 1);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[2].SetActive(true);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_BackG4()
    {
		int g = PlayerPrefs.GetInt("BackG4",0);
		int p = itemPrice_i [7];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[3], 1);
			titleBackgGO[3].SetActive(true);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG4", 1);
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[3], 1);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[3].SetActive(true);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }

    public void item_BackG5()
    {
		int g = PlayerPrefs.GetInt("BackG5",0);
		int p = itemPrice_i [8];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[4], 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[5], 0);
			titleBackgGO[4].SetActive(true);
			titleBackgGO[5].SetActive(false);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG5", 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[4], 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[5], 0);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[4].SetActive(true);
			titleBackgGO[5].SetActive(false);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_BackG6()
    {
		int g = PlayerPrefs.GetInt("BackG6",0);
		int p = itemPrice_i [9];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[4], 0);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[5], 1);
			titleBackgGO[4].SetActive(false);
			titleBackgGO[5].SetActive(true);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG6", 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[4], 0);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[5], 1);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[4].SetActive(false);
			titleBackgGO[5].SetActive(true);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }

    public void item_BackG7()
    {
		int g = PlayerPrefs.GetInt("BackG7",0);
		int p = itemPrice_i [10];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[6], 1);
			titleBackgGO[6].SetActive(true);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG7", 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[6], 1);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[6].SetActive(true);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_BackG8()
    {
		int g = PlayerPrefs.GetInt("BackG8",0);
		int p = itemPrice_i [11];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[7], 1);
			titleBackgGO[7].SetActive(true);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG8", 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[7], 1);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[7].SetActive(true);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_BackG9()
    {
		int g = PlayerPrefs.GetInt("BackG9",0);
		int p = itemPrice_i [12];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[8], 1);
			titleBackgGO[8].SetActive(true);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG9", 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[8], 1);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[8].SetActive(true);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_BackG10()
    {
		int g = PlayerPrefs.GetInt("BackG10",0);
		int p = itemPrice_i [13];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[9], 1);
			titleBackgGO[9].SetActive(true);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG10", 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[9], 1);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[9].SetActive(true);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }

    public void item_BackG11()
    {

		int g = PlayerPrefs.GetInt("BackG11",0);
		int p = itemPrice_i [14];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[10], 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[11], 0);
			titleBackgGO[10].SetActive(true);
			titleBackgGO[11].SetActive(false);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG11", 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[10], 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[11], 0);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[10].SetActive(true);
			titleBackgGO[11].SetActive(false);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_BackG12()
    {
		int g = PlayerPrefs.GetInt("BackG12",0);
		int p = itemPrice_i [15];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[10], 0);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[11], 1);
			titleBackgGO[10].SetActive(false);
			titleBackgGO[11].SetActive(true);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("BackG12", 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[10], 0);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[11], 1);
			PlayerPrefs.SetInt (str, coin);
			titleBackgGO[10].SetActive(false);
			titleBackgGO[11].SetActive(true);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }

    //책꾸밈
    public void item_Book1()
    {
		int g = PlayerPrefs.GetInt("Book1",0);
		int p = itemPrice_i [16];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBook", 1);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("Book1", 1);
			PlayerPrefs.SetInt (str, coin);
			PlayerPrefs.SetInt("decoBook", 1);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_Book2()
    {
		int g = PlayerPrefs.GetInt("Book2",0);
		int p = itemPrice_i [17];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBook", 2);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("Book2", 1);
			PlayerPrefs.SetInt (str, coin);
			PlayerPrefs.SetInt("decoBook", 2);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_Book3()
    {
		int g = PlayerPrefs.GetInt("Book3",0);
		int p = itemPrice_i [18];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBook", 3);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("Book3", 1);
			PlayerPrefs.SetInt (str, coin);
			PlayerPrefs.SetInt("decoBook", 3);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_Book4()
    {
		int g = PlayerPrefs.GetInt("Book4",0);
		int p = itemPrice_i [19];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBook", 4);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("Book4", 1);
			PlayerPrefs.SetInt (str, coin);
			PlayerPrefs.SetInt("decoBook", 4);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }

    //책갈피꾸밈
    public void item_Bookmark1()
    {
		int g = PlayerPrefs.GetInt("Bookmark1",0);
		int p = itemPrice_i [20];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBookmark", 2);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("Bookmark1", 1);
			PlayerPrefs.SetInt (str, coin);
			PlayerPrefs.SetInt("decoBookmark", 2);
		} else {
			StartCoroutine("cardNotReady");
            Debug.Log("돈부족");
        }
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_Bookmark2()
    {
		int g = PlayerPrefs.GetInt("Bookmark2",0);
		int p = itemPrice_i [21];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBookmark", 4);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("Bookmark2", 1);
			PlayerPrefs.SetInt (str, coin);
			PlayerPrefs.SetInt("decoBookmark", 4);
		} else {
			StartCoroutine("cardNotReady");
        }
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_Bookmark3()
    {
		int g = PlayerPrefs.GetInt("Bookmark3",0);
		int p = itemPrice_i [22];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBookmark", 6);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("Bookmark3", 1);
			PlayerPrefs.SetInt (str, coin);
			PlayerPrefs.SetInt("decoBookmark", 6);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;

		//Debug.Log (p);
    }
    public void item_Bookmark4()
    {
		int g = PlayerPrefs.GetInt("Bookmark4",0);
		int p = itemPrice_i [23];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt("decoBookmark", 8);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("Bookmark4", 1);
			PlayerPrefs.SetInt (str, coin);
			PlayerPrefs.SetInt("decoBookmark", 8);
		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;
		//Debug.Log (p);

    }

    //임시초기화
    public void item_BookReload()
    {
        PlayerPrefs.SetInt("decoBook", 0);
        PlayerPrefs.SetInt("decoBookmark", 0);
    }



                
    //코룬틴<--
    IEnumerator cardNotReady()
    {
        warningPop.SetActive(true);
        yield return new WaitForSeconds(1f);
        warningPop.SetActive(false);
    }


}
