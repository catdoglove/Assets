using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleOptionEvt : MonoBehaviour {

	public Sprite [] onoffImgSpr,korengImgSpr;
	public GameObject bgmBtn, seBtn, laugBtn;
	public Button onoffBtn,onoffBtn2,onoffBtn3;
	public SpriteState sprste = new SpriteState();
	int ck,ck2,ck3;

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

	public void laugOnOff(){
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
	}
}
