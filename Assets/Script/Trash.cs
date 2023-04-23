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

    private Trash trashInstance;
    private string spawnedLevel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Scene scene = gameObject.scene;
        // spawnedLevel = scene.name;
        // if (PlayerPrefs.HasKey(spawnedLevel + "_isVisited") && PlayerPrefs.GetInt(spawnedLevel + "_isVisited") == 1){
        //     Destroy(gameObject);
        // } else {
        //     DontDestroyOnLoad(this);
        //     if (trashInstance == null){
        //         trashInstance = this;
        //     } else {
        //         Destroy(gameObject);
        //     }
        // }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().AddScore();
            Destroy(this.transform.parent.gameObject);
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
