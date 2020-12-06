using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    GameObject[] life = new GameObject[3];
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 1;
        for(int i = 0;i < life.Length; i++)
        {
            life[i] = transform.Find("Life" + count).gameObject;
            life[i].SetActive(true);
            count++;
            Debug.Log(life[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.life == 3)
            return;
        if(Player.life < 3)
        {
            life[Player.life].SetActive(false);
        }
    }
}
