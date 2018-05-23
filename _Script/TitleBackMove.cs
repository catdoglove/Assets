using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBackMove : MonoBehaviour {

	public GameObject backImg;
	private Vector3 backImgPos;
	int i=0 ;
	bool bgck = true;
	float imgSpeed = 11f;
	private Vector2 backImgPos2;

	void OnMouseDown(){
		switch (bgck) {
		case true:
			StartCoroutine ("moveImg");
			bgck = false;
			break;
		}	
	}

	IEnumerator moveImg(){
		backImgPos = backImg.transform.position;	
		backImgPos2.y = 5.3f;
		
		while (backImg.transform.position.y < 5.2f) {
			yield return new WaitForSeconds (0.03f);
			imgSpeed = imgSpeed - 0.08f;
			if (imgSpeed < 0) {	break; }
			transform.position = Vector2.MoveTowards (transform.position, backImgPos2, imgSpeed*Time.deltaTime);
		}
		SceneManager.LoadScene ("title"); //씬전환
	}



}
