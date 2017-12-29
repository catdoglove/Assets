using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragCard : MonoBehaviour {
	//눌리고 떼는 것을 감지하기 위해 IPointerDownHandler와 IPointerUpHandler 를 상속받는다.
	bool check;
	Vector2 pos;
	Vector2 wldObjectPos;
	public int cardOrder_num = 0;
	public Sprite[] cardWho_spr;
	public GameObject obj;

	int posX,posY;

	float cardSpeed=0.04f;

	//이미지페이드
	private Sprite TitleImg;
	Color color;
	bool bgck = true;





	// Use this for initialization
	void Start () {
		cardFadeOut ();//카드가 나타나게한다
		posX =(int)transform.position.x;
		posY = (int)transform.position.y;
		//각각 프리펩카드의 위치순서를 확인하고 오더넘버를 정해준다-4
		switch (posX) {
		case -6:
			switch (posY) { 
			case 3:
				cardOrder_num = 0;
				GetComponent<SpriteRenderer> ().sortingOrder = 1;
				break;
			case 1:
				cardOrder_num = 1;
				GetComponent<SpriteRenderer> ().sortingOrder = 2;
				break;
			case 0:
				cardOrder_num = 2;
				GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			case -1:
				cardOrder_num = 3;
				GetComponent<SpriteRenderer> ().sortingOrder = 4;
				break;
			}
			break;
		case 6:
			switch (posY) {
			case 3:
				cardOrder_num = 4;
				GetComponent<SpriteRenderer> ().sortingOrder = 1;
				break;
			case 1:
				cardOrder_num = 5;
				GetComponent<SpriteRenderer> ().sortingOrder = 2;
				break;
			case 0:
				cardOrder_num = 6;
				GetComponent<SpriteRenderer> ().sortingOrder = 3;
				break;
			case -1:
				cardOrder_num = 7;
				GetComponent<SpriteRenderer> ().sortingOrder = 4;
				break;
			}
			break;
		}
		//랜덤으로 셔플된 카드를 중복없이 각각카드에 출력-5
		GetComponent<SpriteRenderer>().sprite = cardWho_spr[PrefabsMake.index_H_list[cardOrder_num]];
	}
	
	// Update is called once per frame
	void Update () {
		if (check) {//카드를 드래그 하고있을때
			Vector2 mouseDragPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			wldObjectPos = Camera.main.ScreenToWorldPoint (mouseDragPos);
			transform.position = Vector2.MoveTowards(transform.position,wldObjectPos,0.9f);
			//if (Input.touchCount > 0) {
			//pos = Input.GetTouch (0).position;    // 터치한 위치
			//pos = Input.mousePosition; 
			//theTouch = new Vector2 (pos.x/100-5, pos.y/100-1, 0.0f);    
			//transform.position =theTouch;
		}else{//EndOfIf
			
			switch (cardOrder_num) { //각각 프리펩카드의 위치순서를 확인해서 돌아갈 자리를 찾아준다
			case 0:
				transform.position = Vector2.MoveTowards(transform.position,new Vector2 (-6f, 2.4f),cardSpeed);
				break;
			case 1 :
				transform.position = Vector2.MoveTowards(transform.position,new Vector2 (-6f, 1.2f),cardSpeed);
				break;
			case 2 :
				transform.position = Vector2.MoveTowards(transform.position,new Vector2 (-6f, -0.4f),cardSpeed);
				break;
			case 3 :
				transform.position = Vector2.MoveTowards(transform.position,new Vector2 (-6f, -2f),cardSpeed);
				break;
			case 4 :
				transform.position = Vector2.MoveTowards(transform.position,new Vector2 (6f, 2.4f),cardSpeed);
				break;
			case 5 :
				transform.position = Vector2.MoveTowards(transform.position,new Vector2 (6f, 1.2f),cardSpeed);
				break;
			case 6 :
				transform.position = Vector2.MoveTowards(transform.position,new Vector2 (6f, -0.4f),cardSpeed);
				break;
			case 7 :
				transform.position = Vector2.MoveTowards(transform.position,new Vector2 (6f, -2f),cardSpeed);
				break;
			}//EndOfSwitch
		}
	}//EndOfUpdate
	void OnMouseDown()
	{
		check = true;
		cardSpeed = 0.8f;
	}//EndOfOnMouseDown

	public void OnMouseUp()
	{
		//카드를 놓았을때 제자리로 돌아갈 것인지 카드를 낸 것인지 확인한다
		check = false;
		if (wldObjectPos.x > -4 && wldObjectPos.x < 4.5) {
			if (wldObjectPos.y < 3.33 && wldObjectPos.y > -2.57) {
				//obj.GetComponent<DataHandler>().LoadData ();//★★★★★★★★★★★★★★★★★★★★
				//여기에 일러스트 띠우고 카드로 새로 뽑는것을 코딩 일러스셋엑티브 후 페이드인
				PrefabsMake.type_num++;
				PrefabsMake.index_H_list.Clear();
				Debug.Log (PrefabsMake.index_H_list.Count);
				PrefabsMake.index_H_list=obj.GetComponent<DataHandler>().LoadData (PrefabsMake.chapter_num,PrefabsMake.type_num);
				Destroy(this.gameObject);

			}//EndOfIf
		}//EndOfIf
	}//EndOfOnMouseUp



	public void cardFadeOut(){
		switch (bgck) {
		case true:
			StartCoroutine ("imgFadeOut");
			bgck = false;
			break;
		}	
	}

	IEnumerator imgFadeOut(){

		color = GetComponent<SpriteRenderer>().color;		
		for (float i = 0f; i < 255f; i += 0.05f) {				
			color.a = Mathf.Lerp (0f, 1f, i);
			this.GetComponent<SpriteRenderer>().color = color;
			yield return null;
		}

	}

}
