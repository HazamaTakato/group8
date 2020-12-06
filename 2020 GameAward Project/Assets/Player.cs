using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    Rigidbody2D rigid2d;
    BoxCollider2D boxcol;
    CircleCollider2D circol;
    public bool ground;//地面
    public bool GravZeroMode;
    public bool NormalGravMode;
    //public float speed;// 追加
    //public float dashspeed;
    public GameObject item;
    public bool haveItem;
    public Camera camera;

    public bool Hanten;
    public int ItemCount;
    public float changeCurrent;

    public Slider slider;

    public GameObject fallblock;
    SpriteRenderer spre;

    AudioSource audioSource;
    public AudioClip s1;
    public AudioClip s2;
    public AudioClip s3;
    public AudioClip s4;
    public AudioClip s5;
    public AudioClip s6;
    public AudioClip s7;

    int count;

    public float[] Speed = new float[6];
    public float kasoku = 0f;
    public int normal = 0;
    public int dash = 3;

    public Sprite Normal;
    public Sprite huttou;
    public Sprite jouhatu;

    public static int life;

    bool invisible;
    float invisibleTime;
    public RankingTime ranking;
    public ClearTime clearTime;
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        boxcol = GetComponent<BoxCollider2D>();
        circol = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        ground = true;
        GravZeroMode = false;//false 人間 true 上に移動
        NormalGravMode = true;//false 人間 true 下に移動
        haveItem = false;
        Hanten = false;
        ItemCount = 0;
        changeCurrent = 0f;
        spre = GetComponent<SpriteRenderer>();
        life = 3;

        invisible = false;
    }
    void FixedUpdate()
    {
        Vector3 cameraPosition = camera.transform.position;
        if (Hanten)
        {
            ground = false;
            rigid2d.AddForce(Vector2.down * 1.7f);
            //transform.position = new Vector3(cameraPosition.x, transform.position.y, transform.position.z);
        }
        else if (!Hanten)
        {
            rigid2d.AddForce(Vector2.down * 6f);
        }

        if (!Hanten)
        {
            //Physics2D.gravity = new Vector2(0, -9.81f);
            rigid2d.mass = 1f;
            rigid2d.gravityScale = 1;
            //if (Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.Joystick1Button0))
            //{
            transform.Translate(Input.GetAxisRaw
               ("Horizontal") */*＊＊＊変更＊＊＊*/ Speed[dash] * Time.deltaTime, 0, 0);
            //}
            //else
            //{
            //    transform.Translate(Input.GetAxisRaw
            //        ("Horizontal") */*＊＊＊変更＊＊＊*/ Speed[dash] * Time.deltaTime, 0, 0);
            //}
        }
        if (Hanten)
        {
            //camera.transform.Rotate(new Vector3(0, 0, -180));
            //Physics2D.gravity = new Vector2(0, -20);
            rigid2d.mass = 0.7f;
            rigid2d.gravityScale = -1;
            //if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick1Button0))
            //{
            //    transform.Translate(Input.GetAxisRaw
            //       ("Horizontal") */*＊＊＊変更＊＊＊*/ 
            //       3.5f * Time.deltaTime, 0, 0);
            //}
            //else
            //{
            transform.Translate(Input.GetAxisRaw
                ("Horizontal") */*＊＊＊変更＊＊＊*/ 4.5f * Time.deltaTime, 0, 0);

            //}
        }
    }
    void Update()
    {
        RankingTime.SecondUpdate();
        Timer.SecondUpdate();

        Vector3 scale = transform.localScale;

        if (!ground && !Hanten && NormalGravMode)
        {
            rigid2d.velocity = new Vector2(rigid2d.velocity.x, -6f);
        }
        if (changeCurrent >= 20)
        {
            changeCurrent = 20;
        }
        if (changeCurrent <= 0)
        {
            changeCurrent = 0;
        }
        if (NormalGravMode&&!Hanten&&ground)
        {
            changeCurrent += 0.5f;
        }
        if (Hanten||GravZeroMode)
        {
            changeCurrent -= 0.025f;
            if (Hanten && changeCurrent <= 0)
            {
                Hanten = false;
            }
            else if (GravZeroMode && changeCurrent <= 0)
            {
                GravZeroMode = false;
                NormalGravMode = true;
            }
        }


        slider.value = changeCurrent;

        //if (!Hanten)
        //{
        //    transform.Translate(Input.GetAxisRaw
        //        ("Horizontal") * speed * Time.deltaTime, 0, 0);
        //    //Physics2D.gravity = new Vector2(0, -9.81f);
        //    rigid2d.mass = 1f;
        //    rigid2d.gravityScale = 1;
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        transform.Translate(Input.GetAxisRaw
        //           ("Horizontal") * dashspeed * Time.deltaTime, 0, 0);
        //    }
        //}
        //if (Hanten)
        //{
        //    //camera.transform.Rotate(new Vector3(0, 0, -180));
        //    transform.Translate(Input.GetAxisRaw
        //        ("Horizontal") * 2 * Time.deltaTime, 0, 0);
        //    //Physics2D.gravity = new Vector2(0, -20);
        //    rigid2d.mass = 0.7f;
        //    rigid2d.gravityScale = -1;
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        transform.Translate(Input.GetAxisRaw
        //           ("Horizontal") * 3 * Time.deltaTime, 0, 0);
        //    }
        //}

        //if (jump && Input.GetKeyDown(KeyCode.Space)&&!GravZeroMode&&NormalGravMode&&!Hanten)
        //{
        //    rigid2d.AddForce(transform.up * 430);
        //    jump = false;
        //}
        //else if (jump && Input.GetKeyDown(KeyCode.Space) && !GravZeroMode && NormalGravMode && Hanten)
        //{
        //    rigid2d.AddForce(transform.up * -155);
        //    jump = false;
        //}

        if (Input.GetKeyDown(KeyCode.W) && !Hanten || Input.GetKeyDown(KeyCode.Joystick1Button1) && !Hanten)//&&NormalGravMode)
        {
            //scale.y = -1;
            audioSource.PlayOneShot(s2);
            Hanten = true;
            GravZeroMode = false;
            NormalGravMode = true;
        }
        //＊＊＊

        else if (Input.GetKeyDown(KeyCode.W) && Hanten || Input.GetKeyDown(KeyCode.Joystick1Button1) && Hanten)
        {
            //scale.y = 1;
            audioSource.PlayOneShot(s4);
            Hanten = false;
        }

        if (Input.GetKeyDown(KeyCode.S) && NormalGravMode && !GravZeroMode|| Input.GetKeyDown(KeyCode.Joystick1Button2) && NormalGravMode && !GravZeroMode)//&&!Hanten)
        {
            NormalGravMode = false;
            GravZeroMode = true;
            Hanten = false;
            audioSource.PlayOneShot(s3);
            //scale.y = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !NormalGravMode && GravZeroMode|| Input.GetKeyDown(KeyCode.Joystick1Button2) && !NormalGravMode && GravZeroMode)//&&!Hanten)
        {
            NormalGravMode = true;
            audioSource.PlayOneShot(s4);
            GravZeroMode = false;
        }

        ////if (Input.GetKeyDown(KeyCode.S) && NormalGravMode)
        ////{
        ////    audioSource.PlayOneShot(s3);
        ////    NormalGravMode = false;
        ////    GravZeroMode = true;
        ////}
        ////if (Input.GetKeyDown(KeyCode.S) && GravZeroMode)
        ////{
        ////    audioSource.PlayOneShot(s4);
        ////    NormalGravMode = true;
        ////    GravZeroMode = false;
        ////}

        if (haveItem)
        {
            Destroy(item);
            ItemCount = ItemCount + 1;
            haveItem = false;
        }
        if (Input.GetKeyDown(KeyCode.R)||Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (GravZeroMode)
        {
            //spre.color = new Color(0, 255, 255);
            spre.sprite = huttou;
            gameObject.layer = 11;
            //circol.enabled = false;
            //boxcol.enabled = false;
        }
        if (NormalGravMode)
        {
            //spre.color = new Color(255, 255, 255);
            spre.sprite = Normal;
            gameObject.layer = 10;
            //circol.enabled = true;
            //boxcol.enabled = true;
        }
        if(NormalGravMode&&!Hanten)
        {
            spre.sprite = Normal;
            //spre.color = new Color(255, 255, 255);
        }
        if (NormalGravMode && Hanten)
        {
            spre.sprite = jouhatu;
            //spre.color = new Color(0, 255, 0);
        }
        if (Input.GetAxisRaw("Horizontal")==1 && !Hanten||Input.GetAxisRaw("Horizontal")==-1&&!Hanten)
        {
            if (NormalGravMode)
            {
                count += 1;
                if (count % 180 == 0)
                {
                    audioSource.PlayOneShot(s5);
                }
            }
            else if (GravZeroMode)
            {
                count += 1;
                if (count % 180 == 0)
                {
                    audioSource.PlayOneShot(s3);
                }
            }
        }
        if (Input.GetAxisRaw("Horizontal")==1 && Hanten || Input.GetAxisRaw("Horizontal")==-1 && Hanten)
        {
                count += 1;
                if (count % 180 == 0)
                {
                    audioSource.PlayOneShot(s2);
                }
        }

        if (kasoku >= 0)
        {
            kasoku -= 1 / 60.0f;
            //Debug.Log(kasoku);
        }
        else
        {
            dash = 3;
            normal = 0;
        }
        Dead();
        //＊＊＊＊＊＊追加＊＊＊＊＊＊＊＊＊＊＊＊＊
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            scale.x = 1;
        }
        else if(Input.GetAxisRaw("Horizontal") == -1)
        {
            scale.x = -1;
        }

        transform.localScale = scale;
        //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊

        //＊＊＊追加＊＊＊＊＊＊＊
        InvisibleTime();
        //＊＊＊＊＊＊＊＊＊＊
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if ("trap" == col.gameObject.tag)
        {
            //audioSource.PlayOneShot(s6);
            //SceneManager.LoadScene(1);
            Damage();
        }
        if ("enemy" == col.gameObject.tag && NormalGravMode && ground)
        {
            //audioSource.PlayOneShot(s6);
            //SceneManager.LoadScene(1);
            Damage();
            Debug.Log("e");
        }
        if ("enemy" == col.gameObject.tag && Hanten&&NormalGravMode)
        {
            Damage();
            Debug.Log("e");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if ("Dead" == col.gameObject.tag)
        {
            life = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        ground = true;
        //if ("enemy" == col.gameObject.tag && NormalGravMode && ground)
       // {
            //audioSource.PlayOneShot(s6);
            //SceneManager.LoadScene(1);
           // Damage();
           // Debug.Log("e");
        //}
        if ("fallblock" == col.gameObject.tag & NormalGravMode)
        {
            audioSource.PlayOneShot(s6);
            //SceneManager.LoadScene(1);
            Damage();
            Debug.Log("f");
        }
        if ("enemy" == col.gameObject.tag && GravZeroMode)
        {
            Kasoku();
            Destroy(col.gameObject);
            audioSource.PlayOneShot(s1);
        }
        //if ("yuka" == col.gameObject.tag && GravZeroMode && jump)
        //{
        //    circol.enabled = false;
        //}
        if ("goal" == col.gameObject.tag)
        {
            //ranking.RankingUpdate();
            SceneManager.LoadScene(3);
            clearTime.LapTime();
            Debug.Log("g");
        }
        if ("trap" == col.gameObject.tag)
        {
            //audioSource.PlayOneShot(s6);
            //SceneManager.LoadScene(1);
            Damage();
        }   
        if ("Item" == col.gameObject.tag)
        {
            Destroy(item);
            haveItem = true;
        }
        if ("yuka" == col.gameObject.tag&&GravZeroMode)
        {
            audioSource.PlayOneShot(s7);
        }
    }
    void Kasoku()
    {
        if (normal < 2)
            normal++;
        if (dash < 5)
            dash++;
        kasoku = 5f;
    }
    void Dead()
    {
        if (life == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    void Damage()
    {
        if (invisible)
            return;
        invisible = true;
        invisibleTime = 3.5f;
        life -= 1;
        audioSource.PlayOneShot(s6);
    }
    void InvisibleTime()
    {
        float tenmetu;
        if (invisibleTime <= 0)
        {
            invisible = false;
            tenmetu = 1f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, tenmetu);
            return;
        }
        invisibleTime -= 1 / 60.0f;
        tenmetu = Mathf.Abs(Mathf.Sin(Time.deltaTime * 20));
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, tenmetu);
    }
}
