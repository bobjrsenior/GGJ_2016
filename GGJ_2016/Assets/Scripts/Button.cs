using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    /// <summary>
    /// The door this button controls
    /// </summary>
    public Door door;

    /// <summary>
    /// Is the button pressed?
    /// </summary>
    private bool pressed = false;

    /// <summary>
    /// Sprite to show when the door is open
    /// </summary>
    public Sprite pressedSprite;

    /// <summary>
    /// Sprite to show when the door is closed
    /// </summary>
    public Sprite notpressedSprite;

    /// <summary>
    /// The objects sprite render (used to change the sprite of the button)
    /// </summary>
    private new SpriteRenderer renderer;

    public void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")){
            door.toggle();
            if (pressed)
            {
                pressed = false;
                renderer.sprite = notpressedSprite;
            }
            else
            {
                pressed = true;
                renderer.sprite = pressedSprite;
            }
        }
    }
}
