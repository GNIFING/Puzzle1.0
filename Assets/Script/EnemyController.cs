using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rigidbody2d; // Reference to the player's Rigidbody2D component
    public float time;
    public Vector2 movement;

    // specify how many points will be deducted from the player if this enemy hit the player
    public int damage = 1;
    
    protected Transform lastSeenPosition;
    private UnityEngine.AI.NavMeshAgent enemy;

    [SerializeField] private FieldOfView fieldOfView;
    protected bool canSeePlayer;
    private bool isAlerted;

    public Vector3 spotOne;
    public Vector3 spotTwo;
    private bool spotOneReached;
    private bool spotTwoReached;

    // Animation
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        // time = 0f;

        // player = GameObject.FindGameObjectWithTag("Player").transform;

        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemy.updateRotation = false;
        enemy.updateUpAxis = false;

        canSeePlayer = false;
        isAlerted = false;
        spotOneReached = true;
        spotTwoReached = false;

        enemy.SetDestination(spotTwo);
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = this.speed;

        // enemy.SetDestination(player.position);
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetAimDirection(enemy.desiredVelocity.normalized);
        if(canSeePlayer || isAlerted){
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

        // update animation
        Vector3 movementVector = enemy.velocity.normalized;

        animator.SetFloat("Horizontal", movementVector.x);
        animator.SetFloat("Vertical", movementVector.y);
        animator.SetFloat("Speed", movementVector.magnitude);

        // set facing direction  can customize the threshold
        if (movement.magnitude > 0.1f)
        {
            animator.SetFloat("FacingHorizontal", movement.x);
            animator.SetFloat("FacingVertical", movement.y);
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
                collision.gameObject.GetComponent<PlayerMovement>().MinusScore(damage);
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

    public virtual void SetCanSeePlayer(bool b)
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

    public void setIsAlert(bool alert)
    {
        this.isAlerted = alert;
    }
}
