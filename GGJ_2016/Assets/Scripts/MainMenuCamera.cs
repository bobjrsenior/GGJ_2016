using UnityEngine;
using System.Collections;

public class MainMenuCamera : MonoBehaviour {

	void LateUpdate () {
        //Keep the camera in place on the main menu
        transform.position = new Vector3(0, 0, -10);
	}
}
