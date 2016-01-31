using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    /// <summary>
    /// Is the door open?
    /// </summary>
    private bool open = false;

    /// <summary>
    /// Sprite to show when the door is open
    /// </summary>
    public Sprite openSprite;

    /// <summary>
    /// Sprite to show when the door is closed
    /// </summary>
    public Sprite closedSprite;

    /// <summary>
    /// The objects sprite render (used to change the sprite of the door)
    /// </summary>
    private SpriteRenderer renderer;

    /// <summary>
    /// The objects collider (disabled when open)
    /// </summary>
    private Collider2D collider;

    public void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }


	public void toggle()
    {
        //If already opened, close the door and enable the collider
        if (open)
        {
            open = false;
            renderer.sprite = closedSprite;
            collider.enabled = true;
        }//If closed, open the door and disable the collider
        else
        {
            open = true;
            renderer.sprite = openSprite;
            collider.enabled = false;
        }
    }
}
