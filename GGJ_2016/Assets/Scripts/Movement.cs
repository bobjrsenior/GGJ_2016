using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    /// <summary>
    /// How fast to move in Units/Second
    /// </summary>
    private float movementSpeed = 5.0f;

    /// <summary>
    /// How fast jumping moves you up in Units/Second
    /// </summary>
    public float jumpSpeed = 7.5f;

    /// <summary>
    /// The maximum possible vertical speed in Units/Second
    /// </summary>
    public float maxJumpSpeed = 8.0f;

    /// <summary>
    /// How much horizontal speed you lose in %/Second (1.00 = 100%/Second)
    /// </summary>
    private float speedLossPercent = 5.00f;

    /// <summary>
    /// Multiplies speed by a certain amount
    /// </summary>
    private float speedMultipier = 1.0f;

    /// <summary>
    /// How long until the speedMultiplier expires
    /// </summary>
    private float speedMultiplierTimer = 0.0f;

    /// <summary>
    /// How much of a boost you get from boost items
    /// </summary>
    public float boostAdder = 1.0f;

    /// <summary>
    /// How much boost time you get from a boost item
    /// </summary>
    public float boostTime = 1.0f;

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
        if(speedMultiplierTimer > 0)
        {
            speedMultiplierTimer -= Time.fixedDeltaTime;
            if(speedMultiplierTimer <= 0)
            {
                speedMultiplierTimer = 0;
                speedMultipier = 1.0f;
            }
        }


        //Grabbing velocity preserves velocity components not used
        Vector3 velocity = rigidbody.velocity;
        if (Input.GetButton("Horizontal"))
        {
            velocity.x = Input.GetAxis("Horizontal") * movementSpeed * speedMultipier;
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
        if(velocity.y > maxJumpSpeed * speedMultipier)
        {
            velocity.y = maxJumpSpeed * speedMultipier;
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
        Audio.audioPlayer.playLevelIncomplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (!collider.gameObject.CompareTag("NoJump"))
        {
            canJump = true;
            if (collider.gameObject.CompareTag("Deadly"))
            {
                die();
            }
            else if (collider.gameObject.CompareTag("Goal"))
            {
                Audio.audioPlayer.playLevelComplete();
                LevelCounter.levelCounter.incrementLevel();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (collider.gameObject.CompareTag("SpeedBoost"))
            {
                Audio.audioPlayer.playSpeedBoost();
                speedMultipier += boostAdder;
                speedMultiplierTimer += boostTime;
                Destroy(collider.gameObject);
            }
            else if (collider.gameObject.CompareTag("Trampoline"))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, -rigidbody.velocity.y);
            }
        }
    }
}
