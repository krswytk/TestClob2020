using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanPlayer : MonoBehaviour
{
    private string PlayerTag = "Player";
    private bool isPlayerInS = false;
    private bool isPlayerEnter, isPlayerStay, isPlayerExit;

    public bool IsPlayerInS()
    {
        if (isPlayerEnter || isPlayerStay)
        {
            isPlayerInS = true;
        }
        else if (isPlayerExit)
        {
            isPlayerInS = false;
        }

        isPlayerEnter = false;
        isPlayerStay = false;
        isPlayerExit = false;
        return isPlayerInS;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == PlayerTag)
        {
           // Debug.Log("Playerが判定に入りました");
            isPlayerEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == PlayerTag)
        {
            //Debug.Log("Playerが判定に入り続けています");
            isPlayerStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == PlayerTag)
        {
            //Debug.Log(" Playerが判定をでました");
            isPlayerExit = true;
        }
    }
}
