using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private FieldOfView fieldOfView;
    public TextMeshProUGUI scoreText;
    public float speed = 5f; // The speed at which the player moves
    private Rigidbody2D rigidbody2d; // Reference to the player's Rigidbody2D component
    
    public Animator animator;

    // Score and stamina
    public int score = 0;
    public float maxStamina = 100;
    public float stamina = 100;
    // For set and update UI
    public GameBar staminaBar;
    public inGameScoreBoard scoreBoard;
    public Vector3 entryFromPrevScene;
    public Vector3 entryFromNextScene;

    // // Set magnet speed and radius
    // public float magnetSpeed = 5f;
    // public float magnetRadius = 5f;

    private void Awake()
    {
        // Get reference to the Rigidbody2D component
        rigidbody2d = GetComponent<Rigidbody2D>();
        if(PlayerPrefs.HasKey("inGameLastLevel")){
            int lastLevelIndex = PlayerPrefs.GetInt("inGameLastLevel");
            int thisLevelIndex = SceneManager.GetActiveScene().buildIndex;
            if (lastLevelIndex - thisLevelIndex == -1){
                transform.position = entryFromPrevScene;
            } else {
                transform.position = entryFromNextScene;
            }
        } else {
            transform.position = entryFromPrevScene;
        }
    }

    private void Start()
    {
        // Set the score
        if(PlayerPrefs.HasKey("inGameScore"))
        {
            int inGameScore = PlayerPrefs.GetInt("inGameScore");
            this.score = inGameScore;
            scoreBoard.SetScore(inGameScore);
        } else {
            scoreBoard.SetScore(score);
        }

        // Set the stamina 
        staminaBar.SetMax(Mathf.RoundToInt(maxStamina));
        if(PlayerPrefs.HasKey("inGameStamina"))
        {
            float inGameStamina = PlayerPrefs.GetFloat("inGameStamina");
            this.stamina = inGameStamina;
            staminaBar.Set(Mathf.RoundToInt(inGameStamina));
        } else {
            staminaBar.Set(Mathf.RoundToInt(stamina));
        }

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

        // Set the animator's parameters for animate 
        animator.SetBool("walkUp", movement.y > 0.01 && movement.y > Mathf.Abs(movement.x) );
        animator.SetBool("walkDown", movement.y < -0.01 && Mathf.Abs(movement.y) > Mathf.Abs(movement.x));
        animator.SetBool("walkLeft", movement.x < -0.01 && !animator.GetBool("walkUp") && !animator.GetBool("walkDown"));
        animator.SetBool("walkRight", movement.x > 0.01 && !animator.GetBool("walkUp") && !animator.GetBool("walkDown"));

        print("up:"+animator.GetBool("walkUp")+" down:"+animator.GetBool("walkDown")+" left:"+animator.GetBool("walkLeft")+" right:"+animator.GetBool("walkRight"));
        
        
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

    public float getStamina() 
    {
        return this.stamina;
    }

    public int getScore()
    {
        return this.score;
    }
}
