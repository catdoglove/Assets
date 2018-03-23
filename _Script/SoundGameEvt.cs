using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGameEvt : MonoBehaviour
{
    public AudioSource gameBG;

    // Use this for initialization
    void Start ()
    {
        gameBG = this.gameObject.GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("soundBGmute", 0) == 1)
        {
            gameBG.mute = true;
        }
        else
        {
            gameBG.mute = false;
        }

    }
	
}
