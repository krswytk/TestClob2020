using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public int statusG;
    public int statusHP;
    public Text Gold;
    public Text Hitpoint;
    public GameObject GameOverText;
    
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Gold.text = "  G : " + statusG;
        Hitpoint.text = "HP : " + statusHP;
        if (statusHP <= 0)
        {
            statusHP = 0;
            GameOverText.SetActive(true);
        }

    }

    public void HP(int damage)
    {
        if (statusHP != 0)
        {
            statusHP += damage;
        }
    }

    public void GOLD(int GetGold)
    {
        if (statusG != 0)
        {
            statusG += GetGold;
        }
    }
}