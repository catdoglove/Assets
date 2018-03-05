using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBGEvt : MonoBehaviour {
	
	public AudioSource loadingBG;
	public int aaa = 10;
	int ckBG = 0;

	// Use this for initialization
	void Start () {
		loadingBG = this.gameObject.GetComponent<AudioSource> ();		
	}

	void FixedUpdate(){
		if (ckBG == 99) {
			if (loadingBG.volume >= 0) {
				loadingBG.volume = loadingBG.volume - (Time.deltaTime / (aaa - 7));
			} else {
				Destroy (this);
				ckBG = 0;
			}
		}
	}


	public void soundFadeOut(){
		ckBG = 99;
	}
}
