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

	public GameObject itemBuy;
	public int[] itemPrice_i;
	public int ip,dn;
	public string pk,dk,dk2;

	//돈
	public Text coin_txt;

    //아이템보유체크
    public GameObject[] itemBuyCK_sign, itemBuyCK_titleBG, itemBuyCK_book, itemBuyCK_bookmark;
    

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


        //아이템 재배치
    public void item_re()
    {
        PlayerPrefs.SetInt("decoSign", 0);
        changeSign();

        for (int i = 0; i < 12; i++)
        {
            PlayerPrefs.SetInt("decoBackG" + titleBackgGO[i], 0);
            titleBackgGO[i].SetActive(false);
        }

        PlayerPrefs.SetInt("decoBook", 0);
        PlayerPrefs.SetInt("decoBookmark", 0);

    }

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
		ip = 0;
		pk = "sing1";
		dn = 3;
		dk = "decoSign";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt ("decoSign", dn);
			changeSign ();
            itemBuyCK_sign[0].SetActive(true);

        } else {
			itemBuy.SetActive (true);
		}
    }

    public void item_Sign2()
    { //푸른
		ip = 1;
		pk = "sing2";
		dn = 6;
		dk = "decoSign";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt ("decoSign", dn);
			changeSign ();
            itemBuyCK_sign[1].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }

    public void item_Sign3()
    { //덤뷸
		ip = 2;
		pk = "sing3";
		dn = 9;
		dk = "decoSign";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt ("decoSign", dn);
			changeSign ();
            itemBuyCK_sign[2].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }

    public void item_Sign4()
    { //덩굴
		ip = 3;
		pk = "sing4";
		dn = 12;
		dk = "decoSign";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt ("decoSign", 12);
			changeSign ();
            itemBuyCK_sign[3].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
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
		ip = 4;
		pk = "BackG1";
		dn = -1;
		dk = "decoBackG" + titleBackgGO[0];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[0], 1);
			titleBackgGO[0].SetActive(true);
            itemBuyCK_titleBG[0].SetActive(true);

        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_BackG2()
    {
		ip = 5;
		pk = "BackG2";
		dn = -2;
		dk = "decoBackG" + titleBackgGO[1];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[1], 1);
			titleBackgGO[1].SetActive(true);
            itemBuyCK_titleBG[1].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_BackG3()
    {
		ip = 6;
		pk = "BackG3";
		dn = -3;
		dk = "decoBackG" + titleBackgGO[2];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[2], 1);
			titleBackgGO[2].SetActive(true);
            itemBuyCK_titleBG[2].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_BackG4()
    {
		ip = 7;
		pk = "BackG4";
		dn = -4;
		dk = "decoBackG" + titleBackgGO[3];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[3], 1);
			titleBackgGO[3].SetActive(true);
            itemBuyCK_titleBG[3].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }

    public void item_BackG5()
    {
		ip = 8;
		pk = "BackG5";
		dn = -5;
		dk = "decoBackG" + titleBackgGO[4];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[4], 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[5], 0);
			titleBackgGO[4].SetActive(true);
			titleBackgGO[5].SetActive(false);
            itemBuyCK_titleBG[4].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_BackG6()
    {
		ip = 9;
		pk = "BackG6";
		dn = -6;
		dk = "decoBackG" + titleBackgGO[5];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[4], 0);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[5], 1);
			titleBackgGO[4].SetActive(false);
			titleBackgGO[5].SetActive(true);
            itemBuyCK_titleBG[5].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }

    public void item_BackG7()
    {
		ip = 10;
		pk = "BackG7";
		dn = -7;
		dk = "decoBackG" + titleBackgGO[6];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[6], 1);
			titleBackgGO[6].SetActive(true);
            itemBuyCK_titleBG[6].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_BackG8()
    {
		ip = 11;
		pk = "BackG8";
		dn = -8;
		dk = "decoBackG" + titleBackgGO[7];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[7], 1);
			titleBackgGO[7].SetActive(true);
            itemBuyCK_titleBG[7].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_BackG9()
    {
		ip = 12;
		pk = "BackG9";
		dn = -9;
		dk = "decoBackG" + titleBackgGO[8];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[8], 1);
			titleBackgGO[8].SetActive(true);
            itemBuyCK_titleBG[8].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_BackG10()
    {
		ip = 13;
		pk = "BackG10";
		dn = -10;
		dk = "decoBackG" + titleBackgGO[9];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[9], 1);
			titleBackgGO[9].SetActive(true);
            itemBuyCK_titleBG[9].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }

    public void item_BackG11()
    {
		ip = 14;
		pk = "BackG11";
		dn = -11;
		dk = "decoBackG" + titleBackgGO[10];
		dk2 = "decoBackG" + titleBackgGO [11];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[10], 1);
			PlayerPrefs.SetInt("decoBackG" + titleBackgGO[11], 0);
			titleBackgGO[10].SetActive(true);
			titleBackgGO[11].SetActive(false);
            itemBuyCK_titleBG[10].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_BackG12()
    {
		ip = 15;
		pk = "BackG12";
		dn = -12;
		dk = "decoBackG" + titleBackgGO[10];
		dk2 = "decoBackG" + titleBackgGO [11];
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
				PlayerPrefs.SetInt("decoBackG" + titleBackgGO[10], 0);
				PlayerPrefs.SetInt("decoBackG" + titleBackgGO[11], 1);
				titleBackgGO[10].SetActive(false);
				titleBackgGO[11].SetActive(true);
            itemBuyCK_titleBG[11].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }

    //책꾸밈
    public void item_Book1()
    {
		ip = 16;
		pk = "Book1";
		dn = 1;
		dk = "decoBook";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt(dk, dn);
            itemBuyCK_book[0].SetActive(true);

        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_Book2()
    {
		ip = 17;
		pk = "Book2";
		dn = 2;
		dk = "decoBook";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt(dk, dn);
            itemBuyCK_book[1].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_Book3()
    {
		ip = 18;
		pk = "Book3";
		dn = 3;
		dk = "decoBook";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt(dk, dn);
            itemBuyCK_book[2].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_Book4()
    {
		ip = 19;
		pk = "Book4";
		dn = 4;
		dk = "decoBook";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt(dk, dn);
            itemBuyCK_book[3].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    //책갈피꾸밈
    public void item_Bookmark1()
    {
		ip = 20;
		pk = "Bookmark1";
		dn = 2;
		dk = "decoBookmark";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt(dk, dn);
            itemBuyCK_bookmark[0].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_Bookmark2()
    {
		ip = 21;
		pk = "Bookmark2";
		dn = 4;
		dk = "decoBookmark";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt(dk, dn);
            itemBuyCK_bookmark[1].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}

    }
    public void item_Bookmark3()
    {
		ip = 22;
		pk = "Bookmark3";
		dn = 6;
		dk = "decoBookmark";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt(dk, dn);
            itemBuyCK_bookmark[2].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }
    public void item_Bookmark4()
    {
		ip = 23;
		pk = "Bookmark4";
		dn = 8;
		dk = "decoBookmark";
		if (PlayerPrefs.GetInt (pk, 0) == 1) {
			PlayerPrefs.SetInt(dk, dn);
            itemBuyCK_bookmark[3].SetActive(true);
        } else {
			itemBuy.SetActive (true);
		}
    }

	public void itemBuyYes(){
		item_handler ();
	}

	public void item_handler(){
		int g = PlayerPrefs.GetInt(pk,0);
		int p = itemPrice_i [ip];
		string str = PlayerPrefs.GetString ("code", "");
		int coin = PlayerPrefs.GetInt(str,0);
		if (g == 1) {
			PlayerPrefs.SetInt(dk, dn);
		} else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt (pk, 1);
			if (dn == -12) {
				PlayerPrefs.SetInt (dk, 0);
				PlayerPrefs.SetInt (dk2, 1);
				titleBackgGO [10].SetActive (false);
				titleBackgGO [11].SetActive (true);
			} else if (dn == -11) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [10], 1);
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [11], 0);
				titleBackgGO [10].SetActive (true);
				titleBackgGO [11].SetActive (false);
			} else if (dn == -10) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [9], 1);
				titleBackgGO [9].SetActive (true);
			} else if (dn == -9) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [8], 1);
				titleBackgGO [8].SetActive (true);
			} else if (dn == -8) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [7], 1);
				titleBackgGO [7].SetActive (true);
			} else if (dn == -7) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [6], 1);
				titleBackgGO [6].SetActive (true);
			} else if (dn == -6) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [4], 0);
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [5], 1);
				titleBackgGO [4].SetActive (false);
				titleBackgGO [5].SetActive (true);
			} else if (dn == -5) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [4], 1);
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [5], 0);
				titleBackgGO [4].SetActive (true);
				titleBackgGO [5].SetActive (false);
			} else if (dn == -4) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [3], 1);
				titleBackgGO [3].SetActive (true);
			} else if (dn == -3) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [2], 1);
				titleBackgGO [2].SetActive (true);
			} else if (dn == -2) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [1], 1);
				titleBackgGO [1].SetActive (true);
			} else if (dn == -1) {
				PlayerPrefs.SetInt ("decoBackG" + titleBackgGO [0], 1);
				titleBackgGO [0].SetActive (true);
			} else {
				PlayerPrefs.SetInt(dk, dn);
				changeSign ();
			}
			PlayerPrefs.SetInt (str, coin);


		} else {
			StartCoroutine("cardNotReady");
		}
		PlayerPrefs.Save ();
		coin_txt.text = "" + coin;
		
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

	public void closeBuyDeco(){
		itemBuy.SetActive (false);
	}

}
