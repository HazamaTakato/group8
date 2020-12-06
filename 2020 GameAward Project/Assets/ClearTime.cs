using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTime : MonoBehaviour
{
    public Text clearText;
    float clearSecond;
    int clearMinite;
    public static float[] lapTimeSecond = new float[3];
    //static int[] lapTimeMinite = new int[3];
    public static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        clearText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LapTime()
    {
        lapTimeSecond[count] = Timer.second;
        //lapTimeMinite[count] = Timer.minite;
        Timer.second = 0f;
        //Timer.minite = 0;
        if(count <= 2)
            count++;
    }
    public void Show()
    {
        for(int i = 0;i < lapTimeSecond.Length; i++)
        {
            //if (lapTimeSecond[i] >= 0 && lapTimeMinite[i] >= 0)
            //{
            //    lapTimeSecond[i] = 0;
            //    lapTimeMinite[i] = 0;
            //}
            //else
            //{
            //clearText.text += "ステージ" + (i + 1) + ", " + (Mathf.FloorToInt(lapTimeSecond[i]) / 60).ToString("00") + ":" + (Mathf.FloorToInt(lapTimeSecond[i]) % 60).ToString("00") + "\n\n" ;
            clearText.text += "ステージ" + (i + 1) + ", " + ((int)lapTimeSecond[i] / 60).ToString("00") + ":" + ((int)lapTimeSecond[i] % 60).ToString("00") + "\n\n";
            //}
        }
    }

}
