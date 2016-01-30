﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {

    private Text text;

    public void Awake()
    {
        text = GetComponent<Text>();
        text.text = "Level: " + LevelCounter.levelCounter.level;
    }

    void OnLevelWasLoaded()
    {
        text.text = "Level: " + LevelCounter.levelCounter.level;
    }

}