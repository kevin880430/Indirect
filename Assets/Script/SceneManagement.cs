using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement: MonoBehaviour
{

    void Update()
    {
        //R���������烁�C����ʂɖ߂�
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Stage1");
        }
    }
}