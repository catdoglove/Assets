using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEvt : MonoBehaviour {

	public static AudioSource se_touch;
	public static AudioClip sp_touch;
	public AudioSource se_touch1,se_book,se_game_success,se_game_fail,se_cardup,se_carddown,se_tutorial,se_del;
	public AudioClip sp_touch1,sp_book,sp_game_success,sp_game_fail,sp_cardup,sp_carddown,sp_tutorial,sp_del;
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

		se_game_success = gameObject.GetComponent<AudioSource> ();
		se_game_success.clip=sp_game_success;

		se_game_fail = gameObject.GetComponent<AudioSource> ();
		se_game_fail.clip=sp_game_fail;

		se_cardup = gameObject.GetComponent<AudioSource> ();
		se_cardup.clip=sp_cardup;

		se_carddown = gameObject.GetComponent<AudioSource> ();
		se_carddown.clip=sp_carddown;

		se_del = gameObject.GetComponent<AudioSource> ();
		se_del.clip=sp_del;


		if (PlayerPrefs.GetInt ("soundmute", 0)==1) {
			se_touch.mute = true;
			se_book.mute = true;
			se_touch1.mute = true;
			se_game_success.mute = true;
			se_game_fail.mute = true;
			se_cardup.mute = true;
			se_carddown.mute = true;
			se_del.mute = true;
			PlayerPrefs.SetInt("soundmute",1);
		}
		
	}

	void Update(){

		//카드
		if (DragCard.soundck == 99) {
			cardUPSound ();
			DragCard.soundck = 0;
		} else if (DragCard.soundck == 88) {
			cardDownSound ();
			DragCard.soundck = 0;			
		}

		//게임
		if (PrefabsMake.soundck == 11) { //성공
			gameSuccessSound ();
			PrefabsMake.soundck = 0;
		} else if (PrefabsMake.soundck == 22) { //실패
			gameFailSound ();
			PrefabsMake.soundck = 0;			
		}

	}

	public void cardUPSound(){
		se_cardup = gameObject.GetComponent<AudioSource> ();
		se_cardup.clip=sp_cardup;
		se_cardup.loop = false;
		se_cardup.Play ();
	}

	public void cardDownSound(){
		se_carddown = gameObject.GetComponent<AudioSource> ();
		se_carddown.clip=sp_carddown;
		se_carddown.loop = false;
		se_carddown.Play ();
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

	public void gameSuccessSound(){
		se_game_success = gameObject.GetComponent<AudioSource> ();
		se_game_success.clip=sp_game_success;
		se_game_success.loop = false;
		se_game_success.Play ();
	}

	public void gameFailSound(){
		se_game_fail = gameObject.GetComponent<AudioSource> ();
		se_game_fail.clip=sp_game_fail;
		se_game_fail.loop = false;
		se_game_fail.Play ();
	}

	public void tutorialSound(){
		se_tutorial = gameObject.GetComponent<AudioSource> ();
		se_tutorial.clip=sp_tutorial;
		se_tutorial.loop = false;
		se_tutorial.Play ();
	}


	public void delCardSound(){
		se_del = gameObject.GetComponent<AudioSource> ();
		se_del.clip=sp_del;
		se_del.loop = false;
		se_del.Play ();
	}






	public void soundMute(){
		if (se_touch.mute == false) {
			se_touch.mute = true;
			se_book.mute = true;
			se_touch1.mute = true;
			se_game_success.mute = true;
			se_game_fail.mute = true;
			se_cardup.mute = true;
			se_carddown.mute = true;
			se_del.mute = true;
			muteImg.GetComponent<Image>().sprite=spr_mute[1];
			PlayerPrefs.SetInt("soundmute",1);
		} else {
			se_touch.mute = false;
			se_book.mute = false;
			se_touch1.mute = false;
			se_cardup.mute = false;
			se_carddown.mute = false;
			se_game_success.mute = false;
			se_game_fail.mute = false;
			se_del.mute = false;
			muteImg.GetComponent<Image>().sprite=spr_mute[0];
			PlayerPrefs.SetInt("soundmute",0);
		}
	}

	public void soundBGMute(){
		
		if (TitleOptionEvt.bgm_title.mute == false) {				
			TitleOptionEvt.bgm_title.mute = true;
			muteBGImg.GetComponent<Image>().sprite=spr_mute[1];
			PlayerPrefs.SetInt("soundBGmute",1);
		} else {
			TitleOptionEvt.bgm_title.mute = false;		
			muteBGImg.GetComponent<Image>().sprite=spr_mute[0];
			PlayerPrefs.SetInt("soundBGmute",0);
		}

	}


}
