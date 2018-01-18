using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBtnEvt : MonoBehaviour {

	public static int ref_check = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void cardRefresh(){
		if (PrefabsMake.index_H_list.Count > 8) {
			//ref_check = 1;
			PrefabsMake.call_card = 1;
			GameObject[] gameObj = GameObject.FindGameObjectsWithTag ("Card");
			//cardFadeOut ();
			for (int i = 0; i < gameObj.Length; i++) {

				Destroy (gameObj [i], 0.2f);
			}
		}
	}
	public void loadTitleScene(){
		SceneManager.LoadScene ("title");
	}
}
