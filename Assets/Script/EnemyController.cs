using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rigidbody2d; // Reference to the player's Rigidbody2D component
    public float time;
    public Vector2 movement;
    
    private Transform lastSeenPosition;
    private UnityEngine.AI.NavMeshAgent enemy;

    [SerializeField] private FieldOfView fieldOfView;
    private bool canSeePlayer;

    public Vector3 spotOne;
    public Vector3 spotTwo;
    private bool spotOneReached;
    private bool spotTwoReached;

    // Start is called before the first frame update
    void Start()
    {
        // time = 0f;

        // player = GameObject.FindGameObjectWithTag("Player").transform;

        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemy.updateRotation = false;
        enemy.updateUpAxis = false;

        canSeePlayer = false;
        spotOneReached = true;
        spotTwoReached = false;

        enemy.SetDestination(spotTwo);
    }

    // Update is called once per frame
    private void Update()
    {
        // time += Time.deltaTime;
        // if(time >= 3f)
        // {
        //     int horizontal = Random.Range(-1, 2); 
        //     int vertical = Random.Range(-1, 2);
        //     while (horizontal == 0 && vertical == 0)
        //     { 
        //         horizontal = Random.Range(-1, 2); 
        //         vertical = Random.Range(-1, 2);
        //     }
        //     movement = new Vector2(horizontal, vertical);
        //     time = 0f;
        // }
        // rigidbody2d.velocity = movement * speed;

        // enemy.SetDestination(player.position);
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetAimDirection(enemy.desiredVelocity.normalized);

        if(canSeePlayer){
            enemy.speed = 3f;
            enemy.SetDestination(lastSeenPosition.position);
        } else {
            enemy.speed = 1.5f;
            if (spotOneReached) {
                if (reachDestination()) {
                    enemy.SetDestination(spotOne);
                    spotTwoReached = true;
                    spotOneReached = false;
                }
            } else if (spotTwoReached) {
                if (reachDestination()) {
                    enemy.SetDestination(spotTwo);
                    spotOneReached = true;
                    spotTwoReached = false;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Knock a player back
            Vector3 force = collision.collider.transform.position - collision.otherCollider.transform.position;
            force.z = 0;
            force.Normalize();
            collision.gameObject.GetComponent<PlayerMovement>().KnockBack(force * 5);

            bool isInvincible = collision.gameObject.GetComponent<PlayerMovement>().getIsInvincible();
            if(!isInvincible){
                collision.gameObject.GetComponent<PlayerMovement>().MinusScore();
                collision.gameObject.GetComponent<PlayerMovement>().setInvincible();
            } else {
                Physics2D.IgnoreCollision(collision.collider, collision.otherCollider, false);
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
    }

    public void SetCanSeePlayer(bool b)
    {
        this.canSeePlayer = b;
    }

    public void SetLastSeenPosition(Transform t)
    {
        this.lastSeenPosition = t;
    }

    private bool reachDestination() 
    {
        if ( Vector3.Distance( enemy.destination, enemy.transform.position) <= 1) {
            return true;
        }
        return false;
    }
}
