using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEvt : MonoBehaviour {

	public static AudioSource se_touch;
	public static AudioClip sp_touch;
	public AudioSource se_touch1,se_book;
	public AudioClip sp_touch1,sp_book;
	public GameObject muteImg,muteBGImg;
	public Sprite [] spr_mute;


	// Use this for initialization
	void Start () {
		
		se_touch = gameObject.GetComponent<AudioSource> ();
		se_touch.clip=sp_touch1;

		se_touch1 = gameObject.GetComponent<AudioSource> ();
		se_touch1.clip=sp_touch1;

		se_book = gameObject.GetComponent<AudioSource> ();
		se_book.clip=sp_book;

		if (PlayerPrefs.GetInt ("soundmute", 0)==1) {
			se_touch.mute = true;
			se_book.mute = true;
			se_touch1.mute = true;
			if (PlayerPrefs.GetInt ("scene", 0) == 1) {		
				muteImg.GetComponent<Image>().sprite=spr_mute[1];
			}
			PlayerPrefs.SetInt("soundmute",1);
		}

		if (PlayerPrefs.GetInt ("soundBGmute", 0)==1) {		
			muteBGImg.GetComponent<Image>().sprite=spr_mute[1];
		}

		
	}

	void Update(){
		if (DragCard.soundck == 99) {
			touchSound ();
			DragCard.soundck = 0;
		} else if (DragCard.soundck == 88) {
			bookSound ();
			DragCard.soundck = 0;			
		}
	}

	public void touchSound(){
		se_touch1 = gameObject.GetComponent<AudioSource> ();
		se_touch1.clip=sp_touch1;
		se_touch1.loop = false;
		se_touch1.Play ();
	}

	public void bookSound(){
		se_book = gameObject.GetComponent<AudioSource> ();
		se_book.clip=sp_book;
		se_book.loop = false;
		se_book.Play ();
	}


	public void soundMute(){
		if (se_touch.mute == false) {
			se_touch.mute = true;
			se_book.mute = true;
			se_touch1.mute = true;
			muteImg.GetComponent<Image>().sprite=spr_mute[1];
			PlayerPrefs.SetInt("soundmute",1);
		} else {
			se_touch.mute = false;
			se_book.mute = false;
			se_touch1.mute = false;
			muteImg.GetComponent<Image>().sprite=spr_mute[0];
			PlayerPrefs.SetInt("soundmute",0);
		}
	}

	public void soundBGMute(){
		
		if (TitleBtnEvt.bgm_title.mute == false) {				
			TitleBtnEvt.bgm_title.mute = true;
			muteBGImg.GetComponent<Image>().sprite=spr_mute[1];
			PlayerPrefs.SetInt("soundBGmute",1);
		} else {
			TitleBtnEvt.bgm_title.mute = false;		
			muteBGImg.GetComponent<Image>().sprite=spr_mute[0];
			PlayerPrefs.SetInt("soundBGmute",0);
		}

	}


}
