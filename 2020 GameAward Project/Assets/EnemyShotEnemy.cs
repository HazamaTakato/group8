using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    float speed;
    private int count=0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //speed = 250f;
        count += 1;
        if (count % 180 == 0)
        {
            GameObject bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity)as GameObject;
            //Rigidbody2D rigid2d = bullet.GetComponent<Rigidbody2D>();
            //rigid2d.AddForce(transform.right * -speed);
            Destroy(bullet, 3f);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
    }
}
