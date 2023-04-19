using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private FieldOfView fieldOfView;
    public TextMeshProUGUI scoreText;
    public float speed = 5f; // The speed at which the player moves
    private Rigidbody2D rigidbody2d; // Reference to the player's Rigidbody2D component
    
    // Score and stamina
    public int score = 0;
    public float maxStamina = 100;
    public float stamina = 100;
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
        staminaBar.SetMax(Mathf.RoundToInt(maxStamina));
        staminaBar.Set(Mathf.RoundToInt(stamina));

        // Start Drain Stamina
        StartCoroutine("StaminaDrain");
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

        // fieldOfView.SetOrigin(transform.position);
        // fieldOfView.SetAimDirection(movement.normalized);
    }

    IEnumerator StaminaDrain()
    {
        while (true)
        {
            if (stamina < maxStamina && stamina > 0)
            {
                stamina -= 1.1f;
            }
            // if player move
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (stamina > 2)
                {
                    stamina -= 0.5f;
                }
            }
            staminaBar.Set(Mathf.RoundToInt(stamina));
            yield return new WaitForSeconds(1f);
        }
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
