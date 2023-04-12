using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float speed = 5f; // The speed at which the player moves
    private Rigidbody2D rigidbody2d; // Reference to the player's Rigidbody2D component
    
    // Score and health(or stamina)
    public int score = 0;
    public int maxHealth = 100;
    public int health = 100;
    // For set and update UI
    public HealthBar healthbar;
    public inGameScoreBoard scoreBoard;

    private void Awake()
    {
        // Get reference to the Rigidbody2D component
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get the horizontal and vertical axes input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the direction of movement
        Vector2 movement = new Vector2(horizontal, vertical);

        // Set the velocity of the player's Rigidbody2D component
        rigidbody2d.velocity = movement * speed;

        // Set the score and health
        scoreBoard.SetScore(score);

        // Set max health 
        healthbar.SetMaxHealth(maxHealth);

        // Set the health 
        healthbar.SetHealth(health);

    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "score :" + score.ToString();
    }

    public void MinusScore()
    {
        score -= 1;
        scoreText.text = "score :" + score.ToString();
    }
}
