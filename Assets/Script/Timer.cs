using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //経過時間を表示する
    static public float currentTime;
    //経過時間のテキストを宣言
    public Text countdownText;
    void Start()
    {
        //プレイしてから経過時間を取得する
        currentTime = PlayerPrefs.GetFloat("RemainingTime");
    }

    // Update is called once per frame
    void Update()
    {
        //時間を足していく
        currentTime+= Time.deltaTime;
        //時間を整数の秒に変換する
        int seconds = Mathf.CeilToInt(currentTime);
        //表示するテキストを更新する
        countdownText.text = "Time: " + seconds.ToString() + "s";
    }
}
