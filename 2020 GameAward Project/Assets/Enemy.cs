using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigid2d;
    public float speed = -5f;
    public bool right;
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        right = false;
        left = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (left && !right)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            rigid2d.velocity = new Vector2(speed, rigid2d.velocity.y);
        }
        if (right && !left)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rigid2d.velocity = new Vector2(-speed, rigid2d.velocity.y);
        }
    }
   void OnCollisionEnter2D(Collision2D col)
   {
        if ("Lkabe" == col.gameObject.tag)
        {
            left = false;
            right = true;
        }
        if ("Rkabe" == col.gameObject.tag)
        {
            left = true;
            right = false;
        }
        
   }
}
