using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play2d : MonoBehaviour
{
   
    public GameObject bullet;

    GameObject Canvas;
    Status Status;

    [Header("移動速度")] public float speed;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("重力")] public float gravity;
    [Header("接地判定")] public GroundCheck ground;
    [Header("ジャンプする高さの制限")] public float jumpHeight;
    [Header("ジャンプ制限時間")] public float jumpLimitTime;
    [Header("頭をぶつけた判定")] public GroundCheck head;

    private Rigidbody2D rb = null;

    private bool isGround = false;//地面についているかどうか
    private bool isJump = false;//ジャンプしているかどうか
    
    //消しても良い
    private bool isHead = false; //頭が天井にぶつかっているかどうか
    private float jumpPos = 0.0f;//ジャンプした時の位置
    private float jumpTime = 0.0f;//ジャンプの時間制限
    //ここまで
   
   public int HP;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//2dリジットボディを取得
        Canvas = GameObject.Find("Canvas");
        Status = Canvas.GetComponent<Status>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HP = Status.statusHP;
        if (HP > 0)
        {
            move();
            ShotAction();

        }else
        {
            Destroy(this.rb);
        }
    }
    /// <summary> 
    /// プレイヤーの動き
    /// </summary> 
    void move()
    {
        
        isGround = ground.IsGround();
        isHead = head.IsGround();

        float horizontalKey = Input.GetAxisRaw("Horizontal");//水平キーの判定
        float verticalKey = Input.GetAxisRaw("Vertical");//↑キーの判定
        float xSpeed = 0.0f;
        float ySpeed = -gravity; //重力で落ち続ける

        if (isGround)
        {
            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;//unity側で設定した値を代入
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f; 
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;
          
           
            //上ボタンを押されている。かつ、現在の高さがジャンプした位置から自分の決めた位置より下ならジャンプを継続する
            
            if(pushUpKey && canHeight && canTime && !isHead) {

                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }

            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

            xSpeed = -speed;
        }
        else
        {

            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed); //移動の力加え
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "enemy")
        {
            Debug.Log("敵と接触した！");
          
            Status.HP(-5);

        }
        if (collision.collider.tag == "enemybullet")
        {
          
            Status.HP(-2);
        }

    }
    void ShotAction()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}