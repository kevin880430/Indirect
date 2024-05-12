using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement: MonoBehaviour
{

    void Update()
    {
        //Rを押したらメイン画面に戻る
        if (Input.anyKeyDown)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("SelectMenuM");
        }
    }
}