using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMixMove : MonoBehaviour {

    public GameObject mixImg;
    private Vector3 backImgPos;
    float imgSpeed = 20f;
    bool bgck = true;
    public GameObject GM;

    public void mixOpen()
    {
        if (bgck)
        {
            StartCoroutine("moveImg2");
            bgck = false;
        }
        else
        {
            StartCoroutine("moveImg");
            bgck = true;
        }
    }




    IEnumerator moveImg()
    {
        // backImgPos = mixImg.transform.position;
        backImgPos.x = 10f;

        while (mixImg.transform.position.x <= 9.9f)
        {
            yield return new WaitForSeconds(0.03f);
            transform.position = Vector3.Lerp(backImgPos, transform.position, imgSpeed * Time.deltaTime);
        }
        GM.GetComponent<TitleCardEvt>().mixCardClose();
    }

    IEnumerator moveImg2()
    {
        // backImgPos = mixImg.transform.position;
        backImgPos.x = 7.3f;

        while (mixImg.transform.position.x > 7.3f)
        {
            yield return new WaitForSeconds(0.03f);
            transform.position = Vector3.Lerp(backImgPos, transform.position, imgSpeed * Time.deltaTime);
            //Debug.Log(mixImg.transform.position.x);
        }

    }







}
