using System.Collections;   
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Vector2 enemyPosition;
    Vector2 enemylate;
   
    public float speed = -2f;

    public bool enemy;
    public bool right;
    public bool left;
    public bool up;
    public bool down;   

    // Start is called before the first frame update
    void Start()

    {
        rigid2d = GetComponent<Rigidbody2D>();
        right = false;
        left = true;
        up = true;
            
        
    }

    
    
    // Update is called once per frame
    void Update()
    {
       if(up)
        {
            rigid2d.velocity = new Vector2(speed, rigid2d.velocity.x);
        }
            
        

    }
   
    private void LateUpdate()
    {
        if (left && !right)
        {
            rigid2d.velocity = new Vector2(speed, rigid2d.velocity.y);
        }
        if (right && !left)
        {
            rigid2d.velocity = new Vector2(-speed, rigid2d.velocity.y);
        }

    }

    

    private void OnCollisionEnter2D(Collision2D col)
    {   
            
        
        if("Lkabe" == col.gameObject.tag)
        {
            left = false;
            right = true;
        }
        if("Rkabe" == col.gameObject.tag)
        {
            left = true;
            right = false;
        }



        
    }
}

    

