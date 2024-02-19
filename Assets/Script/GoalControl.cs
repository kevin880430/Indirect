using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalControl : MonoBehaviour
{
    private ChangeScene changeScene;
    public string nextStage;

    private void Start()
    {
        changeScene= GameObject.Find("SceneManager").GetComponent<ChangeScene>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("COM"))
        {
            Invoke("GameClear", 1.0f);
        }
    }

    public void GameClear()
    {
        PlayerPrefs.SetFloat("RemainingTime",Timer.currentTime);
        changeScene.TransitionToScene(nextStage);
    }
   
}
