using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupZoom : MonoBehaviour
{
    public GameObject popupWindow;
    public GameObject GM;
    Vector3 scalee;
    private Exception e;

    // Use this for initialization
    void Start () {
		
	}

    public void ZoomIn()
    {
        scalee = transform.localScale;
        StartCoroutine("popupZoomIn");

    }

    public void ZoomOut()
    {
        StartCoroutine("popupZoomOut");
    }
    

    IEnumerator popupZoomIn()
    {
        
        scalee = transform.localScale;
        scalee.x = 0.8f;
        scalee.y = 0.8f;
        transform.localScale = scalee;
        while (scalee.x < 1f)
        {
            yield return new WaitForSeconds(0.01f);
            scalee.x = scalee.x + 0.05f;
            scalee.y = scalee.y + 0.05f;
            transform.localScale = scalee;
        }
    }

    IEnumerator popupZoomOut()
    {
        scalee = transform.localScale;
        while (scalee.x >= 0.5f)
        {
            yield return new WaitForSeconds(0.0001f);
            scalee.x = scalee.x - 0.08f;
            scalee.y = scalee.y - 0.08f;
            transform.localScale = scalee;
        }
        
        GM.GetComponent<TitleBtnEvt>().closeWindow();
    }

    
    public void ZoomIn2()
    {
        StartCoroutine("popupZoomInSpecial");
    }


    public void ZoomInSpecial()
    {                
        //합성창
        if (GM.GetComponent<TitleCardEvt>().setCardMix_i == 0)
        {
            if (GM.GetComponent<TitleCardEvt>().popInt == 1)
            {
                StartCoroutine("popupZoomInSpecial");
                //GM.GetComponent<TitleCardEvt>().popInt = 0;
<<<<<<< HEAD
                //Debug.Log("is it work?");
=======
>>>>>>> 440f254fd5934f91f930f3471516a1b1aec546bd
            }
        }
        else // 상점창
        {
            if (GM.GetComponent<TitleDecoEvt>().itemBuy.activeSelf == false)
            {
                //자체제작 트라이캐치
            }
            else
            {
                StartCoroutine("popupZoomInSpecial");
            }
        }      
    }

    IEnumerator popupZoomInSpecial()
    {
        scalee.x = 0.9f;
        scalee.y = 0.9f;
        transform.localScale = scalee;
        scalee = transform.localScale;
        while (scalee.x < 1.1f)
        {
            yield return new WaitForSeconds(0.01f);
            scalee.x = scalee.x + 0.03f;
            scalee.y = scalee.y + 0.03f;
            transform.localScale = scalee;
        }

        while (scalee.x >= 1.05f)
        {
            yield return new WaitForSeconds(0.01f);
            scalee.x = scalee.x - 0.03f;
            scalee.y = scalee.y - 0.03f;
            transform.localScale = scalee;
        }
    }


}
