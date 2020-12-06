using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.velocity = new Vector2(-5, rigid2d.velocity.y);
        //rigid2d.AddForce(transform.right * -50);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if ("Player" == col.gameObject.tag)
        {
            Destroy(gameObject);
        }
        if ("kabe" == col.gameObject.tag)
        {
            Destroy(gameObject);
        }
    }
    }
