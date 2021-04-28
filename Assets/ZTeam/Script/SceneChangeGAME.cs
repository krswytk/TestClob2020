using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeGAME : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Stage_Select");
    }
}
