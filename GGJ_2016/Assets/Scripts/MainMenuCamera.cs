using UnityEngine;
using System.Collections;

public class MainMenuCamera : MonoBehaviour {

	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(0, 0, -10);
	}
}
