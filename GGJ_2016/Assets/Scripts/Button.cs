using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    /// <summary>
    /// The door this button controls
    /// </summary>
    public Door door;

    /// <summary>
    /// A generic object that can be toggled off and on
    /// </summary>
    public GameObject generic;

    /// <summary>
    /// Is the button pressed?
    /// </summary>
    public bool pressed = false;

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
            //If opening a door
            if (generic == null)
            {
                door.toggle();
            }
            if (pressed)
            {
                pressed = false;
                renderer.sprite = notpressedSprite;

                //If not opening a door
                if (generic != null)
                {
                    generic.SetActive(false);
                }
            }
            else
            {
                pressed = true;
                renderer.sprite = pressedSprite;

                //If not opening a door
                if (generic != null)
                {
                    generic.SetActive(true);
                }
            }
        }
    }
}
