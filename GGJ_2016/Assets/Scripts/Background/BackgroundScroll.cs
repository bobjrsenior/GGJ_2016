using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    /// <summary>
    /// The transform of the player to position near it
    /// </summary>
    public Transform player;

    /// <summary>
    /// The players rigidbody in order to know which way the player is going
    /// </summary>
    public Rigidbody2D playerRB;

    /// <summary>
    /// The minimum distance before swapping sides (Distance in order to keep a clean loop)
    /// </summary>
    public float minDistance;



	// Update is called once per frame
	void Update () {
        //Is the background too far away?
	    if(Mathf.Abs(player.position.x - transform.position.x) > minDistance)
        {
            //Swap sides to the side the player is going to the nearest minDistance (keeps clean loop)
            if(playerRB.velocity.x > 0) {
                transform.position = new Vector2(player.position.x - (player.position.x % minDistance) + minDistance, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(player.position.x - (player.position.x % minDistance) - minDistance, transform.position.y);
            }
        }
	}
}
