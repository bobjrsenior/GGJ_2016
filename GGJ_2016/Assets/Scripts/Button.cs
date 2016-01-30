using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    /// <summary>
    /// The door this button controls
    /// </summary>
    public Door door;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")){
            door.toggle();
        }
    }
}
