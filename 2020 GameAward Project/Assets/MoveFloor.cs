using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    //変数定義
    Rigidbody2D rb;
    private Vector2 defaltpass;
    SurfaceEffector2D surface;
    Vector2 PrevPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaltpass = transform.position;
        surface = GetComponent<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PrevPos = rb.position;

        //x座標のみ横移動
        Vector2 pos = new Vector2(defaltpass.x + Mathf.PingPong(Time.time, 3),
            defaltpass.y);
        rb.MovePosition(pos);

        //速度を逆算する
        Vector2 velocity = (pos - PrevPos) /
            Time.deltaTime * 50;

        surface.speed = velocity.x;
    }
}
