using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShuffler : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//카드 순서를 랜덤으로 섞어준다-2
	public List<int> ShuffleHandler(List<int> cardI){
		for (int i = 0; i < cardI.Count; i++) {
			int tempSave = cardI [i];
			int randomIndex = Random.Range (0,7);
			cardI [i] = cardI [randomIndex];
			cardI [randomIndex] = tempSave;
		}	
		for (int i = 0; i < cardI.Count; i++) {
			Debug.Log (cardI [i]);
		}

		return cardI;
	}



}
