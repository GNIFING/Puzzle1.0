using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private FieldOfView fieldOfView;
    public TextMeshProUGUI scoreText;
    public float speed = 5f; // The speed at which the player moves
    private Rigidbody2D rigidbody2d; // Reference to the player's Rigidbody2D component
    
    // Score and stamina
    public int score = 0;
    public int maxStamina = 100;
    public int stamina = 100;
    // For set and update UI
    public GameBar staminaBar;
    public inGameScoreBoard scoreBoard;

    // // Set magnet speed and radius
    // public float magnetSpeed = 5f;
    // public float magnetRadius = 5f;

    private void Awake()
    {
        // Get reference to the Rigidbody2D component
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Set the score and health
        scoreBoard.SetScore(score);

        // Set the stamina 
        staminaBar.SetMax(maxStamina);
        staminaBar.Set(stamina);
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

        // Set the stamina 
        staminaBar.Set(stamina);

        // fieldOfView.SetOrigin(transform.position);
        // fieldOfView.SetAimDirection(movement.normalized);

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
