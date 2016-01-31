using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndTime : MonoBehaviour {

    private Text text;

    public void Awake()
    {
        text = GetComponent<Text>();
    }

    public void Start()
    {
        text.text = "Time Taken: " + (int)(Timer.timer.getTime() * 100) / 100.0f + "s";

    }
}
