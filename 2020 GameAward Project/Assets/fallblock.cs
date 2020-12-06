using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallblock : MonoBehaviour
{
    public GameObject fallblockPrefab;
    float speed;
    private int count;
    GameObject fallblock1;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += 1;
        if (count % 60 == 0)
        {
            fallblock1 = Instantiate(fallblockPrefab) as GameObject;
            x = Random.Range(transform.position.x-transform.localScale.x, transform.position.x + transform.localScale.x);
            fallblock1.transform.position = new Vector2(x,transform.position.y);
            Destroy(fallblock1, 2.7f);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
    }
}
