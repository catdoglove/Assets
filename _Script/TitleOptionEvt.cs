﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleOptionEvt : MonoBehaviour {

	public Sprite [] onoffImgSpr,korengImgSpr, helpImgSpr, helpGameImgSpr;
	public GameObject bgmBtn, seBtn, laugBtn, laugNotReady, helpWnd, helpImgGO;
	public Button onoffBtn,onoffBtn2,onoffBtn3;
	public SpriteState sprste = new SpriteState();
	int ck,ck2,ck3, pageNum=0, ckTG;


	public static AudioSource bgm_title;
	public GameObject muteImg,muteBGImg;
	public Sprite [] spr_mute;


	void Start () {

		//배경과 효과음 이미지변경
		bgm_title = this.gameObject.GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("soundmute", 0)==1) {
			muteImg.GetComponent<Image>().sprite=spr_mute[1];
		}
		if (PlayerPrefs.GetInt ("soundBGmute", 0)==1) {	
			muteBGImg.GetComponent<Image>().sprite=spr_mute[1];			
			bgm_title.mute = true;
		}
	}



	public void btnImgOnOff(){
		switch (ck) {
		case 0: //off
			bgmBtn.GetComponent<Image> ().sprite = onoffImgSpr [2];
			sprste = onoffBtn.spriteState;
			sprste.pressedSprite = onoffImgSpr [3];
			onoffBtn.spriteState = sprste;
			ck = 1;
			break;
		case 1: //on
			bgmBtn.GetComponent<Image> ().sprite = onoffImgSpr [0];
			sprste = onoffBtn.spriteState;
			sprste.pressedSprite = onoffImgSpr [1];
			onoffBtn.spriteState = sprste;
			ck = 0;
			break;
		}
	}

	public void seOnOff(){
		switch (ck2) {
		case 0: //off
			seBtn.GetComponent<Image> ().sprite = onoffImgSpr [2];
			sprste = onoffBtn2.spriteState;
			sprste.pressedSprite = onoffImgSpr [3];
			onoffBtn2.spriteState = sprste;
			ck2 = 1;
			break;
		case 1: //on
			seBtn.GetComponent<Image> ().sprite = onoffImgSpr [0];
			sprste = onoffBtn2.spriteState;
			sprste.pressedSprite = onoffImgSpr [1];
			onoffBtn2.spriteState = sprste;
			ck2 = 0;
			break;
		}
	}

    public void showHelpWnd()
    {
        helpWnd.SetActive(true);
    }

    public void closeHelpWnd()
    {
        helpWnd.SetActive(false);
    }

    public void showTitleHelpWnd()
    {
        ckTG = 1;
        helpWnd.SetActive(false);
        pageNum = 0;
        helpImgGO.GetComponent<Image>().sprite = helpImgSpr[pageNum];
        helpImgGO.SetActive(true);
    }

    public void showGameHelpWnd()
    {
        ckTG = 2;
        helpWnd.SetActive(false);
        pageNum = 0;
        helpImgGO.GetComponent<Image>().sprite = helpGameImgSpr[pageNum];
        helpImgGO.SetActive(true);

    }

    public void pageHelp()
    {
        switch (ckTG)
        {
            case 1://타이틀도움말

                if (pageNum < 7)
                {
                    pageNum++;
                    helpImgGO.GetComponent<Image>().sprite = helpImgSpr[pageNum];
                }
                else { helpImgGO.SetActive(false); }

                break;

            case 2: //게임도움말
                
                if (pageNum < 6)
                {
                    pageNum++;
                    helpImgGO.GetComponent<Image>().sprite = helpGameImgSpr[pageNum];
                }
                else { helpImgGO.SetActive(false); }

                break;
        }
    }
        
    public void laugOnOff(){
		StartCoroutine ("imsi_LaugNotReady");
		/* 준비중
		switch (ck3) {
		case 0: //off
			laugBtn.GetComponent<Image> ().sprite = korengImgSpr [2];
			sprste = onoffBtn3.spriteState;
			sprste.pressedSprite = korengImgSpr [3];
			onoffBtn3.spriteState = sprste;
			ck3 = 1;
			break;
		case 1: //on
			laugBtn.GetComponent<Image> ().sprite = korengImgSpr [0];
			sprste = onoffBtn3.spriteState;
			sprste.pressedSprite = korengImgSpr [1];
			onoffBtn3.spriteState = sprste;
			ck3 = 0;
			break;
		}
		*/

	}

	//준비중
	IEnumerator imsi_LaugNotReady(){
		laugNotReady.SetActive (true);
		yield return new WaitForSeconds (2f);
		laugNotReady.SetActive (false);
	}
}
