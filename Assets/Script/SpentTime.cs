using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpentTime : MonoBehaviour
{
    //�N���A���Ԃ̃e�L�X�g��錾
    public Text TimeSpent;
    //����
    float time;
    void Start()
    {
        //�v���C���Ă���o�ߎ��Ԃ��擾����
        time= PlayerPrefs.GetFloat("RemainingTime");
        //���Ԃ𐮐��̕b�ɕϊ�����
        int seconds = Mathf.CeilToInt(time);
        //�\������e�L�X�g���X�V����
        TimeSpent.text= "You Spent: " + seconds.ToString() + "s "+"to Clear";
    }
}
