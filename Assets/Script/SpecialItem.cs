using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialItem : MonoBehaviour
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

    private string spawnedLevel;

    public GameObject textPanel;

    private void OpenPanel()
    {
        if (textPanel != null)
        {
            textPanel.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OpenPanel();
            PlayerPrefs.SetInt("specialItemFound", 1);
            Time.timeScale = 0;
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
    }
}
