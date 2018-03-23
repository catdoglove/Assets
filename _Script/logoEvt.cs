using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logoEvt : MonoBehaviour {
    AsyncOperation async;
    int skip = 0;


    // Use this for initialization
    void Start () {
        StartCoroutine(LoadCount());
    }

    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync("Main");
        while (!async.isDone)
        {
            yield return true;
        }

    }
    IEnumerator LoadCount()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Load());
    }

}
