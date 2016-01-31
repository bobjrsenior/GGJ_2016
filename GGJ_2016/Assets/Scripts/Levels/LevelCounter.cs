using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelCounter : MonoBehaviour {

    /// <summary>
    /// Keep a reference to this class for easy access
    /// </summary>
    public static LevelCounter levelCounter = null;

    /// <summary>
    /// Current level
    /// </summary>
    public int level = 1;

    public void Awake()
    {
        if(SceneManager.GetActiveScene().name.Equals("Demo Start"))
        {
            Destroy(Timer.timer.transform.parent.gameObject);
            Timer.timer = null;
        }
        //Make sure there is only 1 levelCounter object in any given scene
        if (levelCounter != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            levelCounter = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /// <summary>
    /// Increment the level by 1
    /// </summary>
    public void incrementLevel()
    {
        ++level;
    }

    /// <summary>
    /// Reset to te first level (1)
    /// </summary>
    public void resetLevel()
    {
        level = 1;
    }
}
