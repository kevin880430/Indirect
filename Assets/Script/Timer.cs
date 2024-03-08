using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //�o�ߎ��Ԃ�\������
    static public float currentTime;
    //�o�ߎ��Ԃ̃e�L�X�g��錾
    public Text countdownText;
    void Start()
    {
        //�v���C���Ă���o�ߎ��Ԃ��擾����
        currentTime = PlayerPrefs.GetFloat("RemainingTime");
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ𑫂��Ă���
        currentTime+= Time.deltaTime;
        //���Ԃ𐮐��̕b�ɕϊ�����
        int seconds = Mathf.CeilToInt(currentTime);
        //�\������e�L�X�g���X�V����
        countdownText.text = "Time: " + seconds.ToString() + "s";
    }
}
