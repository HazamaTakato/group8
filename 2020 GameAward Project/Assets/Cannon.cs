using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float count;
    public float waitTime;
    public float x;
    public float y;
    public float rotate;
    float addRotate = 5;
    float rad;
    float addForceX, addForceY;
    public bool stay;

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.CompareTag("Player"))
            return;
        stay = true;
            col.attachedRigidbody.sleepMode = RigidbodySleepMode2D.NeverSleep;

        if (!Input.anyKey)
        {
            col.transform.position = gameObject.transform.position;
            col.attachedRigidbody.velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rad = rotate * Mathf.PI / 180.0f;
            addForceX = Mathf.Sin(rad) * x;
            addForceY = Mathf.Cos(rad) * y;
            //count++;
            //if(count/60.0f >= waitTime)
            //{
            col.attachedRigidbody.velocity = new Vector2(addForceX,addForceY);
            //}
        }
        
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        stay = false;
        count = 0;
        col.attachedRigidbody.sleepMode = RigidbodySleepMode2D.StartAwake;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stay)
            return;

        if (Input.GetKeyDown(KeyCode.RightArrow)&&rotate <=45)
        {
            transform.Rotate(0, 0, -addRotate);
            rotate += addRotate;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)&& rotate >= 45)
        {
            transform.Rotate(0, 0, addRotate);
            rotate -= addRotate;
        }     
    }
}
