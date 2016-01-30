using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private Text text;

    private float time = 0.0f;
	
    public void Awake()
    {
        text = GetComponent<Text>();
    }

	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        text.text = "" + (int)(time * 100) / 100.0f;
	}
}
