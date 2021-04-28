using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraZteam : MonoBehaviour
{
    // 変数の定義
    private Transform target;

    // シーン開始時に一度だけ呼ばれる関数
    void Start()
    {
        // 変数にPlayerオブジェクトのtransformコンポーネントを代入
        target = GameObject.Find("player").transform;
    }

    // シーン中にフレーム毎に呼ばれる関数
    void Update()
    {
        // カメラのx座標をPlayerオブジェクトのx座標から取得y座標とz座標は現在の状態を維持
        if (-4<target.position.y&& target.position.y<3)
        {
            
            transform.position = new Vector3(target.position.x, 0, transform.position.z);
        }

        else if(target.position.y <= -4){
            transform.position = new Vector3(target.position.x, target.position.y+4, transform.position.z);
        }
        else if (3<=target.position.y)
        {
            transform.position = new Vector3(target.position.x, target.position.y-3 , transform.position.z);
        }

    }
}
