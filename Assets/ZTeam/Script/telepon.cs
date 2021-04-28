using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telepon : MonoBehaviour
{
    GameObject Player;
    private string PlayerTag = "Player";
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == PlayerTag)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Vector3 pos = Player.transform.position;
                Player.transform.position = new Vector3(pos.x - 103f, pos.y, pos.z);
            }
        }
    }
}
