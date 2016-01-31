using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuBrick : MonoBehaviour {


    private float rot = 0.0f;

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collider)
    {
        Camera.main.transform.Rotate(0, 0, 150.0f * Time.deltaTime);
        rot += 150.0f * Time.deltaTime;
        if(rot >= 360)
        {
            SceneManager.LoadScene("Speed_Test"); ;
        }
    }
}
