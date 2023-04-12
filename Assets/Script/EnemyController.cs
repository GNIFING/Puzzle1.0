using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rigidbody2d; // Reference to the player's Rigidbody2D component
    public float time;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        if(time >= 3f)
        {
            int horizontal = Random.Range(-1, 2); 
            int vertical = Random.Range(-1, 2); 
            movement = new Vector2(horizontal, vertical);
            time = 0f;
        }
        rigidbody2d.velocity = movement * speed;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().MinusScore();
        }
    }
}
