using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Audio : MonoBehaviour {

    public AudioSource[] audioClips;

    public static Audio audioPlayer = null;

    public void Awake()
    {
        if(audioPlayer != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            audioPlayer = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void OnLevelWasLoaded()
    {
        if(SceneManager.GetActiveScene().name.Equals("Demo Start"))
        {
            audioPlayer = null;
            Destroy(this.gameObject);
        }
    }

    public void playLevelComplete()
    {
        audioClips[0].Play();
    }

    public void playLevelIncomplete()
    {
        audioClips[1].Play();
    }

    public void playSpeedBoost()
    {
        audioClips[2].Play();
    }

}
