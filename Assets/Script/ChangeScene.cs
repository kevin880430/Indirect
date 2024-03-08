using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyTransition;


public class ChangeScene : MonoBehaviour
{
    //TransitionManager���擾����
    TransitionManager TransitionM;
    //Transition�̎d��������Ƃ���
    public TransitionSettings transition;
    //scene�̖��O
    private string sceneName;
    public string nextStage;
    void Start()
    {
        //�X�e�[�W�̖��O���擾����
        sceneName = SceneManager.GetActiveScene().name;
        //TransitionManager��TransitionM �Ɋi�[����
        TransitionM = TransitionManager.Instance();
    }
    private void Update()
    {
        //�^�C�g���ƃ��U���g��ʂ���R�L�[�ŃX�e�[�W��ؑ�
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

   
    //�X�e�[�W�J�ڂ̃��\�b�h
    public void TransitionToScene(string sceneName)
    {
        //Transition����Đ�
        TransitionM.Transition(transition, 0.0f);
        //�w�肵��scene�ɑJ��
        StartCoroutine(LoadSceneAfterDelay(sceneName, 0.8f));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        //�����҂��Ă����ʑJ�ڂ��s��
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}