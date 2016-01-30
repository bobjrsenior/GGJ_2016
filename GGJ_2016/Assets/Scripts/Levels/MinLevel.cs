﻿using UnityEngine;
using System.Collections;

public class MinLevel : MonoBehaviour {

    /// <summary>
    /// The minimum level required for this object to spawn
    /// </summary>
    public int minLevel = -1;

    public void Awake()
    {
        //If the current level is too low, destroy this object
        if(minLevel > LevelCounter.levelCounter.level)
        {
            Destroy(this.gameObject);
        }//If minLevel hasn't been set, add a debug message
        else if(minLevel == -1)
        {
            print("Object minLevel not set: " + gameObject.name);
        }
    }
}
