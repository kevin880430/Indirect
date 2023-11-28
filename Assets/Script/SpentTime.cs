using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpentTime : MonoBehaviour
{
    public Text TimeSpent;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time= PlayerPrefs.GetFloat("RemainingTime");
        int seconds = Mathf.CeilToInt(time);
        TimeSpent.text= "You Spent: " + seconds.ToString() + "s "+"to Clear";
    }

    // Update is called once per frame
}
