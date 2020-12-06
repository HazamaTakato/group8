using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float wind;
    public Vector2 velocity;
    public Player player;

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.attachedRigidbody == null)
        {
            return;
        }
        if (col.CompareTag("Player")&&player.Hanten)
        {
            Debug.Log("hit");
            var vel = velocity - col.attachedRigidbody.velocity;

            col.attachedRigidbody.AddForce(wind * vel);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(player.Hanten)
        col.attachedRigidbody.velocity = new Vector2(2, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
