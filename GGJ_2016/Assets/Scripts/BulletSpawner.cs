using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

    /// <summary>
    /// Prefab that represents a bullet
    /// </summary>
    public GameObject bulletPrefab;

    /// <summary>
    /// Transform of the player in order to spawn bullets offscreen
    /// </summary>
    private Transform player;

    /// <summary>
    /// The average speed of bullets
    /// </summary>
    public float bulletSpeed = 5.0f;


    /// <summary>
    /// The possible variation from the average speed bullets can have
    /// </summary>
    public float bulletVariance = 1.0f;

    /// <summary>
    /// Average time between spawns
    /// </summary>
    public float spawnRate = 2.0f;

    private float timer = 0.0f;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(Random.Range(0, (spawnRate * 0.5f) + timer) > spawnRate)
        {
            timer = 0.0f;
            GameObject obj = Instantiate(bulletPrefab, new Vector2(player.position.x + Random.Range(12.0f, 17.0f), Random.Range(-5.0f, 5.0f)), Quaternion.identity) as GameObject;
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-Random.Range(bulletSpeed - bulletVariance, bulletSpeed + bulletVariance), 0);
        }
	}
}
