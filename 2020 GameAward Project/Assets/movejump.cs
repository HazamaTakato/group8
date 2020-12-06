using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movejump : MonoBehaviour
{
    Rigidbody2D rigid2d;
    public float speed = -5f;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(pos.x + Mathf.PingPong(Time.time, 4), pos.y + Mathf.PingPong(Time.time, 2));
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if ("Player" == col.gameObject.tag)
        {
            Destroy(gameObject);
        }
    }
}
