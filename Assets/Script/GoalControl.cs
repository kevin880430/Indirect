using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalControl : MonoBehaviour
{
    //ChangeScene���i�[���邽�߂̕ϐ�
    private ChangeScene changeScene;
    public string nextStage;

    private void Start()
    {
        //ChangeScene�R���|�[�l���g���擾����
        changeScene= GameObject.Find("SceneManager").GetComponent<ChangeScene>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //COM�L�����ƐڐG������
        if (col.gameObject.CompareTag("COM"))
        {
            //��b��҂��Ă���X�e�[�W�J��
            Invoke("GameClear", 1.0f);
        }
    }

    public void GameClear()
    {
        //�o�ߎ��Ԃ��L�^����
        PlayerPrefs.SetFloat("RemainingTime",Timer.currentTime);
        changeScene.TransitionToScene(nextStage);
    }
   
}
