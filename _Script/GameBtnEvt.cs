using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBtnEvt : MonoBehaviour {

	public static int ref_check = 0;
	public GameObject returnTitSpr, gameBookGO, gameBookmarkGO1, gameBookmarkGO2;
    public Sprite[] gameBookSpr,gameBookmarkSpr;

    public int ads;


    // Use this for initialization
    void Start () {

        if(PlayerPrefs.GetInt("reloadCard", 0) > 14)
        {
            PlayerPrefs.SetInt("reloadCard", 14);
        }

        gameBookGO.GetComponent<Image>().sprite = gameBookSpr[PlayerPrefs.GetInt("decoBook", 0)];
        gameBookmarkGO1.GetComponent<Image>().sprite = gameBookmarkSpr[PlayerPrefs.GetInt("decoBookmark", 0)];
        gameBookmarkGO2.GetComponent<Image>().sprite = gameBookmarkSpr[PlayerPrefs.GetInt("decoBookmark", 0)+1];
        
    }
	

	public void cardRefresh(){


        ads = PlayerPrefs.GetInt("reloadCard", 0);
        ads++;
        PlayerPrefs.SetInt("reloadCard", ads);
        PlayerPrefs.Save();

        if (ads == 16)
        {
            // 전면 광고 출력
            ads = PlayerPrefs.GetInt("reloadCard", 0);
        }
        else
        {
            if (PrefabsMake.index_H_list.Count > 8)
            {
                //ref_check = 1;
                PrefabsMake.call_card = 1;
                GameObject[] gameObj = GameObject.FindGameObjectsWithTag("Card");
                //cardFadeOut ();
                for (int i = 0; i < gameObj.Length; i++)
                {

                    Destroy(gameObj[i], 0.2f);
                }
            }

        }





    }
	public void loadTitleScene(){
		SceneManager.LoadScene ("title");

		//초기화
		PrefabsMake.card_index= new int[6] {0,0,0,0,0,0}; 
		PrefabsMake.end_mach=0;
		PrefabsMake.index_H_list.Clear();
		PrefabsMake.chapter_num=1;
		PrefabsMake.type_num=0;
		PrefabsMake.call_card = 0;

	}


	//나가기팝업
	public void openBackWnd(){
		returnTitSpr.SetActive (true);
	}
	public void closeBackWnd(){
		returnTitSpr.SetActive (false);
	}
}
