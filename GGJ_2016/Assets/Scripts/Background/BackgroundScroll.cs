using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    public Transform player;

    public Rigidbody2D playerRB;

    public float minDistance;



	// Update is called once per frame
	void Update () {
	    if(Mathf.Abs(player.position.x - transform.position.x) > minDistance)
        {
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
