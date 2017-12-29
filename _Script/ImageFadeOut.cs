using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ImageFadeOut : MonoBehaviour {

	private Image TitleImg;
	Color color;
	bool bgck = true;

	// Use this for initialization
	void Start () {
		TitleImg = GetComponent<Image>();
		//StartCoroutine ("imgFadeOut");
	}

	public void titleFadeOut(){
		switch (bgck) {
		case true:
			StartCoroutine ("imgFadeOut");
			bgck = false;
			break;
		}	
	}

	IEnumerator imgFadeOut(){

		color = TitleImg.color;		
		for (float i = 1.5f; i >= 0; i -= 0.05f) {				
			color.a = Mathf.Lerp (0f, 1f, i);
			TitleImg.color = color;
			yield return null;
		}

	}
}
