using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleDecoEvt : MonoBehaviour {

    //titleSignSpr : 15, titleBackgSpr: 12
    public Sprite[] markImgSpr, titleSignSpr;
    public GameObject markTitle, markGame, titleView, gameView;
    public GameObject[] titleSignGO, titleBackgGO, titleItemSpr, gameItemSpr;
    int MarkNum = 0;
    int signNum = 0;
	public int[] itemPrice_i;


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
		}else if (coin >= p) {
			coin = coin - p;
			PlayerPrefs.SetInt ("sing0", 1);
			PlayerPrefs.SetInt ("decoSign", 0);
			changeSign ();
		}
       
    }

    public void item_Sign1()
    { //붉은
        PlayerPrefs.SetInt("decoSign", 3);
        changeSign();
    }

    public void item_Sign2()
    { //푸른
        PlayerPrefs.SetInt("decoSign", 6);
        changeSign();
    }

    public void item_Sign3()
    { //덤뷸
        PlayerPrefs.SetInt("decoSign", 9);
        changeSign();
    }

    public void item_Sign4()
    { //덩굴
        PlayerPrefs.SetInt("decoSign", 12);
        changeSign();
    }

    public void changeSign()
    {
        signNum = PlayerPrefs.GetInt("decoSign", 0);
        titleSignGO[0].GetComponent<Image>().sprite = titleSignSpr[signNum];
        titleSignGO[1].GetComponent<Image>().sprite = titleSignSpr[signNum + 1];
        titleSignGO[2].GetComponent<Image>().sprite = titleSignSpr[signNum + 2];
        //Debug.Log(i);
    }

    //배경꾸밈
    public void item_BackG1()
    {
        PlayerPrefs.SetInt("decoBackG"+ titleBackgGO[0], 1);
        titleBackgGO[0].SetActive(true);
    }
    public void item_BackG2()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[1], 1);
        titleBackgGO[1].SetActive(true);
    }
    public void item_BackG3()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[2], 1);
        titleBackgGO[2].SetActive(true);
    }
    public void item_BackG4()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[3], 1);
        titleBackgGO[3].SetActive(true);
    }

    public void item_BackG5()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[4], 1);
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[5], 0);
        titleBackgGO[4].SetActive(true);
        titleBackgGO[5].SetActive(false);
    }
    public void item_BackG6()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[4], 0);
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[5], 1);
        titleBackgGO[4].SetActive(false);
        titleBackgGO[5].SetActive(true);
    }

    public void item_BackG7()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[6], 1);
        titleBackgGO[6].SetActive(true);
    }
    public void item_BackG8()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[7], 1);
        titleBackgGO[7].SetActive(true);
    }
    public void item_BackG9()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[8], 1);
        titleBackgGO[8].SetActive(true);
    }
    public void item_BackG10()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[9], 1);
        titleBackgGO[9].SetActive(true);
    }

    public void item_BackG11()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[10], 1);
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[11], 0);
        titleBackgGO[10].SetActive(true);
        titleBackgGO[11].SetActive(false);
    }
    public void item_BackG12()
    {
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[10], 0);
        PlayerPrefs.SetInt("decoBackG" + titleBackgGO[11], 1);
        titleBackgGO[10].SetActive(false);
        titleBackgGO[11].SetActive(true);
    }

    //책꾸밈
    public void item_Book1()
    {
        PlayerPrefs.SetInt("decoBook", 1);
    }
    public void item_Book2()
    {
        PlayerPrefs.SetInt("decoBook", 2);
    }
    public void item_Book3()
    {
        PlayerPrefs.SetInt("decoBook", 3);
    }
    public void item_Book4()
    {
        PlayerPrefs.SetInt("decoBook", 4);
    }

    //책갈피꾸밈
    public void item_Bookmark1()
    {
        PlayerPrefs.SetInt("decoBookmark", 2);
    }
    public void item_Bookmark2()
    {
        PlayerPrefs.SetInt("decoBookmark", 4);
    }
    public void item_Bookmark3()
    {
        PlayerPrefs.SetInt("decoBookmark", 6);
    }
    public void item_Bookmark4()
    {
        PlayerPrefs.SetInt("decoBookmark", 8);
    }

    //임시초기화
    public void item_BookReload()
    {
        PlayerPrefs.SetInt("decoBook", 0);
        PlayerPrefs.SetInt("decoBookmark", 0);
    }



}
