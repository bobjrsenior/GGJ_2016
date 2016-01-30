using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    /// <summary>
    /// Is the door open?
    /// </summary>
    private bool open = false;

    /// <summary>
    /// Material to show when the door is open
    /// </summary>
    public Sprite openMat;

    /// <summary>
    /// Material to show when the door is closed
    /// </summary>
    public Sprite closedMat;

    /// <summary>
    /// The objects sprite render (used to change the material of the door)
    /// </summary>
    private new SpriteRenderer renderer;

    /// <summary>
    /// The objects collider (disabled when open)
    /// </summary>
    private new Collider2D collider;

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
            renderer.sprite = closedMat;
            collider.enabled = true;
        }//If closed, open the door and disable the collider
        else
        {
            open = true;
            renderer.sprite = openMat;
            collider.enabled = false;
        }
    }
}
