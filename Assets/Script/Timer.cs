using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    static public float currentTime;
    public Text countdownText;
    void Start()
    {
       
        currentTime = PlayerPrefs.GetFloat("RemainingTime");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime+= Time.deltaTime;
        int seconds = Mathf.CeilToInt(currentTime);
        countdownText.text = "Time: " + seconds.ToString() + "s";
    }
}
