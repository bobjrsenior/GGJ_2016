using UnityEngine;
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

    private float maxJumpSpeed = 12.0f;

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
        }

        //Cap the maximum vertical velocity
        if(velocity.y > maxJumpSpeed)
        {
            velocity.y = maxJumpSpeed;
        }

        //Reset the object if below the map
        if (transform.position.y < -7)
        {
            die();
            return;
        }

        rigidbody.velocity = velocity;
        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
	}

    public void die()
    {
        transform.position = Vector2.zero;
        rigidbody.velocity = Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        canJump = true;
        if (collider.gameObject.CompareTag("Deadly"))
        {
            die();
        }
    }
}
