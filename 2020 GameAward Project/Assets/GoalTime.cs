using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTime : MonoBehaviour
{

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        //text.text = ("今回のタイム," + (Mathf.FloorToInt((int)RankingTime.second) / 60).ToString("00") + ":" + (Mathf.FloorToInt((int)RankingTime.second) % 60).ToString("00"));
        text.text = ("Result　" 
            + (((int)ClearTime.lapTimeSecond[0] + (int)ClearTime.lapTimeSecond[1] + (int)ClearTime.lapTimeSecond[2]) / 60).ToString("00")
            + ":" 
            + (((int)ClearTime.lapTimeSecond[0] + (int)ClearTime.lapTimeSecond[1] + (int)ClearTime.lapTimeSecond[2]) % 60).ToString("00"));
    }
}
