using UnityEngine;
using System.Collections;

public class MenuBrick : MonoBehaviour {

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collider)
    {
        Camera.main.transform.Rotate(0, 0, 150.0f * Time.deltaTime);
    }
}
