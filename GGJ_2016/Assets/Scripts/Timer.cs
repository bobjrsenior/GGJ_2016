using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    /// <summary>
    /// A static reference to the current timer to track through iterations
    /// </summary>
    public static Timer timer = null;

    /// <summary>
    /// UI Text that will display the game time
    /// </summary>
    private Text text;

    /// <summary>
    /// Current game time
    /// </summary>
    public float time = 0.0f;

    /// <summary>
    /// Incrment time?
    /// </summary>
    private bool running = true;
	
    public void Awake()
    {
        if (timer != null)
        {
            Destroy(transform.parent.gameObject);
            return;
        }
        else {
            timer = this;
            DontDestroyOnLoad(transform.parent.gameObject);
            text = GetComponent<Text>();
        }
        
    }

	// Update is called once per frame
	void Update () {
        if (running)
        {
            time += Time.deltaTime;
            text.text = "" + (int)(time * 100) / 100.0f;
        }
	}

    /// <summary>
    /// Returns the current play time
    /// </summary>
    /// <returns></returns>
    public float getTime()
    {
        return time;
    }

    void OnLevelWasLoaded()
    {
        if (LevelCounter.levelCounter.level == 31)
        {
            running = false;
        }
    }
}
