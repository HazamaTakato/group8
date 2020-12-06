using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float oldSecond;
    Text timeText;
    public static int minite;
    public static float second;

    // Start is called before the first frame update
    void Start()
    {
        oldSecond = 0;
        timeText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (second >= 60.0f)
        //{
        //    minite++;
        //    second = second - 60;
        //}
        if((int)second != (int)oldSecond)
        {
            timeText.text = ((int)second / 60).ToString("00") + ":" + ((int)second % 60).ToString("00");
        }
        oldSecond = second;

    }
    public static void SecondUpdate()
    {
        second += Time.deltaTime;
    }
}
