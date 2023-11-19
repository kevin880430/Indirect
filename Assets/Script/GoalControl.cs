using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("COM"))
        {
            Invoke("GameClear", 1.0f);
        }
    }

    public void GameClear()
    {
        SceneManager.LoadScene("GameClear");
    }
   
}
