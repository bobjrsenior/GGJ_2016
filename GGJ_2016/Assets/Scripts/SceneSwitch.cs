using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Starts Game
    public void StartGame()
    {
        Application.LoadLevel("demo");
    }

    //Loads Instructions
    public void Instructions()
    {
        Application.LoadLevel("Demo Inst");
    }

    //Goes back to Start
    public void ReturnStart()
    {
        Application.LoadLevel("Demo Start");
    }
}
