using UnityEngine;
using System.Collections;

public class ButtonPresser : MonoBehaviour {

    /// <summary>
    /// What this object wants to touch
    /// </summary>
    public Transform target;

    /// <summary>
    /// Where this object began
    /// </summary>
    private Vector2 origin;

    /// <summary>
    /// This objects rigid body in order to access velocity
    /// </summary>
    private Rigidbody2D rigidbody;

    /// <summary>
    /// The rate at which this object moves in Units/Second
    /// </summary>
    private float movementSpeed = 2.0f;

    /// <summary>
    /// The minimum waiting period before going after target again
    /// </summary>
    public float minWait = 1.0f;

    /// <summary>
    /// How long the object has currently waited to go after target
    /// </summary>
    private float waitTimer = 0.0f;

    /// <summary>
    /// How much extra time wil the object wait before attacking
    /// </summary>
    private float waitFluff = 0.0f;

    /// <summary>
    /// 0 = Wait
    /// 1 = Attack
    /// 2 = Retreat
    /// </summary>
    private int state = 0;

    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        origin = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Wait State
        if (state == 0)
        {
            waitTimer += Time.fixedDeltaTime;
            if (waitTimer > minWait + waitFluff)
            {
                waitTimer = 0;
                state = 1;
            }
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }//Attack state
        else if(state == 1)
        {
            //Get the direction of the target and move that way
            Vector2 velocity = rigidbody.velocity;
            float dist = target.position.x - transform.position.x;
            velocity.x = Mathf.Sign(dist) * movementSpeed;
            //If close enough, begin retreat
            if(Mathf.Abs(dist) < 0.1f)
            {
                state = 2;
                return;
            }
            rigidbody.velocity = velocity;
        }//Retreat State
        else if (state == 2)
        {
            Vector2 velocity = rigidbody.velocity;
            //Get the direction of the origin and move that way
            float dist = origin.x - transform.position.x;
            velocity.x = Mathf.Sign(dist) * movementSpeed;
            //If close enough, start waiting again
            if (Mathf.Abs(dist) < 0.1f)
            {
                state = 0;
                velocity.x = 0;
                //Add random fluff to wait (adds suspense)
                waitFluff = Random.Range(0.0f, 5.0f);
            }
            rigidbody.velocity = velocity;
        }
    }
}
