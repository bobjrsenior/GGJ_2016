using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    /// <summary>
    /// The rate at which this object rotates in degrees/Second
    /// </summary>
    public float rotationSpeed = 20.0f;


	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
	}
}
