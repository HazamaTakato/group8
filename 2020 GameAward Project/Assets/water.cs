using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    Collider2D coll;
    bool boom;
    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponent<Collider2D>();
        this.coll.isTrigger = false;
        boom = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (11 == col.gameObject.layer)
        {
            Debug.Log("zero");
            coll.isTrigger = true;
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (11 == col.gameObject.layer)
        {
            Debug.Log("zero");
            coll.isTrigger = true;
            Destroy(gameObject);
        }
    }
}
