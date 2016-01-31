using UnityEngine;
using System.Collections;

public class HeavyPlatform : MonoBehaviour {

    /// <summary>
    /// Chould the platform continously fall?
    /// </summary>
    public bool alwaysFall = false;

    /// <summary>
    /// How fast the platform should fall in Units/Second
    /// </summary>
    public float fallSpeed = 2.0f;

    /// <summary>
    /// Using the RigidBody for movement plays nice with Unity's Physics
    /// Translating instead made the fall look jumpy
    /// </summary>
    private Rigidbody2D rigidbody;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (alwaysFall)
        {
            rigidbody.velocity = new Vector3(0, -fallSpeed, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (!alwaysFall && collider.gameObject.CompareTag("Player"))
        {
            rigidbody.velocity = new Vector3(0, -fallSpeed, 0);
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if (!alwaysFall && collider.gameObject.CompareTag("Player"))
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}
