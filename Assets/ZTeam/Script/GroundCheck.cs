using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //接地判定を返すメソッド
    // Start is called before the first frame update
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag == groundTag)
        {
            Debug.Log("地面が判定に入りました");
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.tag == groundTag)
        {
            Debug.Log("地面が判定に入り続けています");
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      
        if (collision.tag == groundTag)
        {
            Debug.Log("地面が判定をでました");
            isGroundExit = true;
        }
    }
}
