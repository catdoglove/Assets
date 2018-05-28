using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRecipeMove : MonoBehaviour {

    public GameObject recipeImg,markImg;
    private Vector3 backImgPos;
    int i = 0;
    bool bgck = true;
    float imgSpeed = 11f;
    private Vector2 backImgPos2;
    public Sprite [] leftrightMark;


    public void reciptOpen()
    {
        if (bgck)
        {
            //transform.position = new Vector3(3, 0, 0);
            markImg.GetComponent<Image>().sprite = leftrightMark[1];
            StartCoroutine("moveImg");
            bgck = false;
        }
        else
        {
           // transform.position = new Vector3(1, 0, 0);
            markImg.GetComponent<Image>().sprite = leftrightMark[0];
            StartCoroutine("moveImg2");
            bgck = true;
        }
    }


    IEnumerator moveImg()
    {
       // backImgPos = recipeImg.transform.position;
        backImgPos2.x = 3f;

        while (recipeImg.transform.position.x <= 2.9f)
        {
            yield return new WaitForSeconds(0.03f);
            float imgSpeed = 20f;
            transform.position = Vector3.Lerp(backImgPos2, transform.position, imgSpeed * Time.deltaTime);
        }
    }

    IEnumerator moveImg2()
    {
        // backImgPos = recipeImg.transform.position;
        backImgPos2.x =1f;

        while (recipeImg.transform.position.x > 1f)
        {
            yield return new WaitForSeconds(0.03f);
            float imgSpeed = 20f;
            transform.position = Vector3.Lerp(backImgPos2, transform.position, imgSpeed * Time.deltaTime);
            //Debug.Log(recipeImg.transform.position.x);
        }
    }

}
