using UnityEngine;
using System.Collections;

public class Hamster : MonoBehaviour {

    /// <summary>
    /// Gets the objects animator in order to change parameters
    /// </summary>
    private Animator animator;

    /// <summary>
    /// The players rigidbody in order to see how fast/what direction it is going
    /// </summary>
    private Rigidbody2D player;

    /// <summary>
    /// Timer for the slight minimum delay before going from active to inactive
    /// </summary>
    private float timer = 0.0f;

	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //If moving or holding left/right
	    if(Mathf.Abs(player.velocity.x) > 0.05f || Input.GetButton("Horizontal"))
        {
            //Reset timer and set animator parameters
            timer = 0;
            animator.SetBool("Running", true);
            animator.SetFloat("Velocity", player.velocity.x);
            transform.localScale = new Vector3(-Mathf.Sign(player.velocity.x), 1.0f, 1.0f);
        }//If not moving
        else
        {
            //Add a slight delay to avoid inactive on turns, then set inactive parameters
            timer += Time.fixedDeltaTime;
            if (timer > 0.05f)
            {
                animator.SetBool("Running", false);
            }
        }
	}

    void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
