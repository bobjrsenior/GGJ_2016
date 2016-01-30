﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    /// <summary>
    /// How fast to move in Units/Second
    /// </summary>
    private float movementSpeed = 5.0f;

    /// <summary>
    /// How fast jumping moves you up in Units/Second
    /// </summary>
    private float jumpSpeed = 7.5f;

    /// <summary>
    /// How much horizontal speed you lose in %/Second (1.00 = 100%/Second)
    /// </summary>
    private float speedLossPercent = 5.00f;

    /// <summary>
    /// Can the object jump?
    /// </summary>
    private bool canJump = true;

    /// <summary>
    /// New keyword to hide warning about hiding rigidbody keyword
    /// </summary>
    private new Rigidbody2D rigidbody;

    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


	// Update is called once per frame
	void FixedUpdate () {
        //Grabbing velocity preserves velocity components not used
        Vector3 velocity = rigidbody.velocity;
        if (Input.GetButton("Horizontal"))
        {
            velocity.x = Input.GetAxis("Horizontal") * movementSpeed;
        }
        else if(velocity.x != 0)
        {
            //Lose velocity at a rate of speedLossPercent of total velocity per second
            velocity.x -= velocity.x * speedLossPercent * Time.fixedDeltaTime;
            //Make sure to stop completely at some point
            if(Mathf.Abs(velocity.x) < 0.1f)
            {
                velocity.x = 0;
            }
        }
        
        if(canJump && Input.GetButton("Jump"))
        {
            velocity.y += jumpSpeed;
            canJump = false;
        }//Reset the object if below the map
        else if(transform.position.y < -7)
        {
            transform.position = Vector2.zero;
            velocity = Vector3.zero;
        }

        rigidbody.velocity = velocity;
        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        canJump = true;
    }
}
