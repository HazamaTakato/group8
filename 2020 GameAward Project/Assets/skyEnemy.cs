using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyEnemy : MonoBehaviour
{
    Rigidbody2D rigid2d;
    public float speed = -5f;
    public bool up;
    public bool down;
    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        up = false;
        down = true;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(pos.x,pos.y + Mathf.PingPong(Time.time, 4));


        //if (up && !down)
        //{
        //    rigid2d.velocity = new Vector2(speed, rigid2d.velocity.x);
        //}
        //if (up && !down)
        //{
        //    rigid2d.velocity = new Vector2(-speed, rigid2d.velocity.x);
        //}
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if ("yuka" == col.gameObject.tag)
        //{
        //    up = false;
        //    down = true;
        //}
        //if ("yuka" == col.gameObject.tag)
        //{
        //    up = true;
        //    down = false;
        //}
        
    }
}