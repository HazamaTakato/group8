using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingTime : MonoBehaviour
{
    static float[] seconds = new float[3];
    public float second;
    string nullScore = "-----------";
    public bool ranking;
    public Text textRanking;
    // Start is called before the first frame update
    void Start()
    {
        ranking = false;
        textRanking = GetComponentInChildren<Text>();
        ///seconds[0] = 60;
        //seconds[1] = 170;
        //seconds[2] = 260;
        //Show();
    }
    // Update is called once per frame
    void Update()
    {
        //second += Time.deltaTime;
    }
    public void RankingUpdate()
    {
        second = (int)ClearTime.lapTimeSecond[0] + (int)ClearTime.lapTimeSecond[1] + (int)ClearTime.lapTimeSecond[2];
        //if (!ranking && seconds[0] > second || seconds[0] == 0)
        //{
        //    seconds[2] = seconds[1];
        //    seconds[1] = seconds[0];
        //    seconds[0] = second;
        //    ranking = true;
        //}
        //else if (!ranking && seconds[1] > second || seconds[1] == 0)
        //{
        //    seconds[2] = seconds[1];
        //    seconds[1] = second;
        //    ranking = true;
        //}
        //else if (!ranking && seconds[2] > second || seconds[2] == 0)
        //{
        //    seconds[2] = second;
        //    ranking = true;
        //}
        //Show();
        if (!ranking && seconds[0] > second || seconds[0] == 0)
        {
            seconds[2] = seconds[1];
            seconds[1] = seconds[0];
            seconds[0] = second;
            ranking = true;
        }
        else if (!ranking && seconds[1] > second || seconds[1] == 0)
        {
            seconds[2] = seconds[1];
            seconds[1] = second;
            ranking = true;
        }
        else if (!ranking && seconds[2] > second || seconds[2] == 0)
        {
            seconds[2] = second;
            ranking = true;
        }
        Show();
    }
    void Show()
    {

        //textRanking.text = ("今回のタイム," + ((int)second / 60).ToString("00") + ":" + ((int)second % 60).ToString("00") + "\n\n");
        if (seconds[0] == 0)
        {
            textRanking.text += ("1位," + nullScore + "\n\n");
        }
        else
        {
            textRanking.text += ("1位," + ((int)seconds[0] / 60).ToString("00") + ":" + ((int)seconds[0] % 60).ToString("00") + "\n\n");
        }
        if (seconds[1] == 0)
        {
            textRanking.text += ("2位," + nullScore + "\n\n");
        }
        else
        {
            textRanking.text += ("2位," + ((int)seconds[1] / 60).ToString("00") + ":" + ((int)seconds[1] % 60).ToString("00") + "\n\n");
        }
        if (seconds[2] == 0)
        {
            textRanking.text += ("3位," + nullScore + "\n\n");
        }
        else
        {
            textRanking.text += ("3位," + ((int)seconds[2] / 60).ToString("00") + ":" + ((int)seconds[2] % 60).ToString("00") + "\n\n");
        }
    }

    public static void SecondUpdate()
    {
        //second += Time.deltaTime;
    }
    public void zero()
    {
        second = 0;
    }
}