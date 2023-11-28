using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalControl : MonoBehaviour
{
    public string nextStage;
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
        SceneManager.LoadScene(nextStage);
    }
   
}
