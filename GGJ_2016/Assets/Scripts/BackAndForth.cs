using UnityEngine;
using System.Collections;

public class BackAndForth : MonoBehaviour {

    /// <summary>
    /// Which way the platform will move
    /// </summary>
    public Vector2 direction = Vector2.zero;

    /// <summary>
    /// The speed at which the platform will move
    /// </summary>
    public float frequency = 5.0f;

    /// <summary>
    /// The distance the platform will travel in either direction
    /// </summary>
    public float amplitude = 2.0f;

    /// <summary>
    /// Using the RigidBody for movement plays nice with Unity's Physics
    /// </summary>
    private new Rigidbody2D rigidbody;

    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void FixedUpdate () {
        rigidbody.velocity = direction * amplitude * Mathf.Cos(frequency * (Time.time));
	}
}
