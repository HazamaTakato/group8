using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    AudioSource aus;
    public AudioClip s1;
    public RankingTime ranking;
    public ClearTime clearTime;
    public GoalTime goalTime;
    // Start is called before the first frame update
    void Start()
    {
        aus = GetComponent<AudioSource>();
        ranking.RankingUpdate();
        goalTime.Show();
        clearTime.Show();
        ranking.zero();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            aus.PlayOneShot(s1);
            SceneManager.LoadScene(0);
        }
    }
}
