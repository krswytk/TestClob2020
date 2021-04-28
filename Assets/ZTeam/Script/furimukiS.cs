using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class furimukiS : MonoBehaviour
{
    EnemyC1 EnemyC1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Playerが判定に入りました");
        if (collision.tag == "player")
        {
            EnemyC1.furimuki();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

       
    }
}
