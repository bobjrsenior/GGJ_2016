using UnityEngine;
using System.Collections;

public class ContinuousJump : MonoBehaviour {

    /// <summary>
    /// How fast jumping moves you up in Units/Second
    /// </summary>
    private float jumpSpeed = 7.5f;


    /// <summary>
    /// New keyword to hide warning about hiding rigidbody keyword
    /// </summary>
    private Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);

    }
}
