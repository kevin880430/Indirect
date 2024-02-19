using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyTransition;


public class ChangeScene : MonoBehaviour
{
    //TransitionManager‚ğæ“¾‚·‚é
    TransitionManager TransitionM;
    //Transition‚Ìd•û‚ğ“ü‚ê‚é‚Æ‚±‚ë
    public TransitionSettings transition;
    //scene‚Ì–¼‘O
    private string sceneName;
    public string nextStage;
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        //TransitionManager‚ğTransitionM ‚ÉŠi”[‚·‚é
        TransitionM = TransitionManager.Instance();
    }
    private void Update()
    {
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

    //ONClicK‚É‘Î‰‚·‚éScene‚ÌØ‘Ö•û
    public void TransitionToScene(string sceneName)
    {
        //Transition“®‰æÄ¶
        TransitionM.Transition(transition, 0.0f);
        //w’è‚µ‚½scene‚É‘JˆÚ
        StartCoroutine(LoadSceneAfterDelay(sceneName, 0.8f));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        //­‚µ‘Ò‚Á‚Ä‚©‚ç‰æ–Ê‘JˆÚ‚ğs‚¤
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}