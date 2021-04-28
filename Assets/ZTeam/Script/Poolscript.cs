using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolscript : MonoBehaviour
{
    Transform pool; //オブジェクトを保存する空オブジェクトのtransform
    // Start is called before the first frame update
    void Start()
    {
        pool = new GameObject("enemybullet").transform;
    }

    void GetObject(GameObject enemybullet, Vector3 pos, Quaternion qua)
    {
        foreach (Transform t in pool)
        {
            //オブジェが非アクティブなら使い回し
            if (!t.gameObject.activeSelf)
            {
                t.SetPositionAndRotation(pos, qua);
                t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
            }
        }

        //非アクティブなオブジェクトがないなら生成
        Instantiate(enemybullet, pos, qua, pool);//生成と同時にpoolを親に設定
    }
}
