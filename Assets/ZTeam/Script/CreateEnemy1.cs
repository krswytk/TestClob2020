using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy1 : MonoBehaviour
{
    //　出現させる敵を入れておく
    public GameObject[] enemys;
    //　次に敵が出現するまでの時間

    public float appearNextTime;
    //　この場所から出現する敵の数

    public int maxNumOfEnemys;
    //　今何人の敵を出現させたか（総数）
    private int numberOfEnemys;
    //　待ち時間計測フィールド
    private float elapsedTime;
   
    
    // Use this for initialization
    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }

// Update is called once per frame
void Update()
    {
       
        var gameObject = GameObject.Find("enemy2(Clone)");
     
         

            //　この場所から出現する最大数を超えているかつ敵が倒されていなかったら
            if (numberOfEnemys >= maxNumOfEnemys)
            {
              
            if (gameObject == null)
            {
               
                numberOfEnemys = 0;
            }
            else
            {
              
                return;
            }
           
            
            }
            //　経過時間を足す
            elapsedTime += Time.deltaTime;

            //　経過時間が経ったら
            if (elapsedTime > appearNextTime)
            {
                elapsedTime = 0f;
                AppearEnemy();
            }
       

}

    void AppearEnemy()
    {
             
        GameObject.Instantiate(enemys[0], transform.position, Quaternion.Euler(0f, 0f, 0f));

        numberOfEnemys++;
        elapsedTime = 0f;


    }
}
