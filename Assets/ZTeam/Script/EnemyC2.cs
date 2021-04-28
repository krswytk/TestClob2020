using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyC2 : MonoBehaviour
{
    [SerializeField]
    Transform target=null; //追いかける対象
    NavMeshAgent agent=null;//ナビメッシュエージェント

    GameObject Canvas;
    Status Status;
    GameObject pl;//宣言が合っていないと思う

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");//ここでプレイヤーを取得したい
        agent = GetComponent<NavMeshAgent>();

        Canvas = GameObject.Find("Canvas");//ステータスの入ったオブジェクトの取得
        Status = Canvas.GetComponent<Status>();//ステータスの取得

        if (target != null)
        {
            agent.destination = pl.transform.position;//ここにプレイヤーのポジションを入れたい
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(pl.transform.position);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "mybullet" || collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }


}
