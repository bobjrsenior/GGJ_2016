﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    //Starts Game
    public void StartGame()
    {
        LevelCounter.levelCounter.resetLevel();
        SceneManager.LoadScene("Level_1");
    }

    //Loads Instructions
    public void Instructions()
    {
        SceneManager.LoadScene("Demo Inst");
    }

    //Goes back to Start
    public void ReturnStart()
    {
        SceneManager.LoadScene("Demo Start");
    }
}
