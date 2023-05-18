using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trash : MonoBehaviour
{    

    Rigidbody2D rb;
    
    bool hasTarget;
    Vector3 targetPosition;
    float speed = 5f;

    // lazy moveable trash
    private float flipSpeed = 100f; // adjust this value to control the speed of the flip
    private float amplitude = 0.005f; // adjust this value to control the height of the coin's movement
    private float frequency = 2f; // adjust this value to control the frequency of the coin's movement
    private float elapsedTime = 0f;

    public int score = 1;

    private Trash trashInstance;
    private string spawnedLevel;

    public Sprite[] spriteArray;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private AudioSource playTrashSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        int rdnInt = Random.Range(0, spriteArray.Length);
        spriteRenderer.sprite = spriteArray[rdnInt]; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playTrashSound = gameObject.GetComponent<AudioSource>();
            playTrashSound.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<PlayerMovement>().AddScore(score);
            Destroy(this.transform.parent.gameObject, 1f);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
    }

    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector2 direction = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x , direction.y) * speed;
        }

        // calculate the y-position based on a sine wave
        float yPos = Mathf.Sin(elapsedTime * frequency) * amplitude;

        // calculate the flip angle based on the elapsed time and flip speed
        float flipAngle = elapsedTime * flipSpeed;

        // apply the flip and position changes to the coin transform
        transform.rotation = Quaternion.Euler(0f, flipAngle, 0f);
        transform.position = transform.position + new Vector3(0f, yPos, 0f);

        elapsedTime += Time.deltaTime;
    }

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
        hasTarget = true;
    }

    public string GetSpawnedLevel() {
        return this.spawnedLevel;
    }

    private void Update() {
        // string activeLevel = SceneManager.GetActiveScene().name;
        // Debug.Log("activeLevel " + activeLevel);
        // Debug.Log("spawnedLevel " + spawnedLevel);
        // Debug.Log(" ");
        // if(spawnedLevel == activeLevel){
        //     this.gameObject.SetActive(true);
        // } else {
        //     this.gameObject.SetActive(false);
        // }
    }
}
