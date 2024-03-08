using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalControl : MonoBehaviour
{
    //ChangeSceneを格納するための変数
    private ChangeScene changeScene;
    public string nextStage;

    private void Start()
    {
        //ChangeSceneコンポーネントを取得する
        changeScene= GameObject.Find("SceneManager").GetComponent<ChangeScene>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //COMキャラと接触したら
        if (col.gameObject.CompareTag("COM"))
        {
            //一秒を待ってからステージ遷移
            Invoke("GameClear", 1.0f);
        }
    }

    public void GameClear()
    {
        //経過時間を記録する
        PlayerPrefs.SetFloat("RemainingTime",Timer.currentTime);
        changeScene.TransitionToScene(nextStage);
    }
   
}
