using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyTransition;


public class ChangeScene : MonoBehaviour
{
    //TransitionManagerを取得する
    TransitionManager TransitionM;
    //Transitionの仕方を入れるところ
    public TransitionSettings transition;
    //sceneの名前
    private string sceneName;
    public string nextStage;
    void Start()
    {
        //ステージの名前を取得する
        sceneName = SceneManager.GetActiveScene().name;
        //TransitionManagerをTransitionM に格納する
        TransitionM = TransitionManager.Instance();
    }
    private void Update()
    {
        //タイトルとリザルト画面だけRキーでステージを切替
        if (sceneName == "Title" && Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            TransitionToScene(nextStage);
        }
        else if(sceneName == "GameClear" && Input.GetKeyDown(KeyCode.R))
        {
            TransitionToScene(nextStage);
        }

    }

   
    //ステージ遷移のメソッド
    public void TransitionToScene(string sceneName)
    {
        //Transition動画再生
        TransitionM.Transition(transition, 0.0f);
        //指定したsceneに遷移
        StartCoroutine(LoadSceneAfterDelay(sceneName, 0.8f));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        //少し待ってから画面遷移を行う
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}