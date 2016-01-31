using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelUI : MonoBehaviour {

    private Text text;

    public void Awake()
    {
        text = GetComponent<Text>();
        text.text = "Iteration: " + LevelCounter.levelCounter.level;
    }

    void OnLevelWasLoaded()
    {
        if (LevelCounter.levelCounter.level != 31)
        {
            text.text = "Iteration: " + LevelCounter.levelCounter.level;
        }
        else
        {
            text.text = "Iteration: OK";
        }
    }

}
