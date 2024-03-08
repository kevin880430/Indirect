using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpentTime : MonoBehaviour
{
    //クリア時間のテキストを宣言
    public Text TimeSpent;
    //時間
    float time;
    void Start()
    {
        //プレイしてから経過時間を取得する
        time= PlayerPrefs.GetFloat("RemainingTime");
        //時間を整数の秒に変換する
        int seconds = Mathf.CeilToInt(time);
        //表示するテキストを更新する
        TimeSpent.text= "You Spent: " + seconds.ToString() + "s "+"to Clear";
    }
}
