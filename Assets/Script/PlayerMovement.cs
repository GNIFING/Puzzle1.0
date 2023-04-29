using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

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
    public int junkLossed = 0;

    // For set and update UI
    public GameBar staminaBar;
    public inGameScoreBoard scoreBoard;

    // Player entry position from each scene
    public Vector3 entryFromPrevScene;
    public Vector3 entryFromNextScene;

    // Player will not get minus score in invincible mode
    private bool isInvincible = false;
    public int invincibleCoolDown = 2;

    // Player is knocked back when got hit by an enemy
    private Vector2 knockBackDirection = Vector2.zero;

    // // Set magnet speed and radius
    // public float magnetSpeed = 5f;
    // public float magnetRadius = 5f;

    // Player will blink when got hit by an enemy
    public float minimum = 0.3f;
    public float maximum = 1.0f;
    private float a;
    private bool increasing = true;
    Color color;  
    private SpriteRenderer sr;

    public float transitionTime = 1f;

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

        // Set junk lossed record
        if(PlayerPrefs.HasKey("inGameJunkLossed"))
        {
            int inGameJunkLossed = PlayerPrefs.GetInt("inGameJunkLossed");
            this.junkLossed = inGameJunkLossed;
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

        sr = gameObject.GetComponent<SpriteRenderer>();
        color = sr.color;
        a = maximum;
    }

    private void Update()
    {
        // Get the horizontal and vertical axes input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        // Calculate the direction of movement
        Vector2 movement = new Vector2(horizontal, vertical);

        movement += knockBackDirection;

        // Set the velocity of the player's Rigidbody2D component
        rigidbody2d.velocity = movement * speed;

        // Set the animator's parameters for animate 
        animator.SetBool("walkUp", movement.y > 0.01 && movement.y > Mathf.Abs(movement.x) );
        animator.SetBool("walkDown", movement.y < -0.01 && Mathf.Abs(movement.y) > Mathf.Abs(movement.x));
        animator.SetBool("walkLeft", movement.x < -0.01 && !animator.GetBool("walkUp") && !animator.GetBool("walkDown"));
        animator.SetBool("walkRight", movement.x > 0.01 && !animator.GetBool("walkUp") && !animator.GetBool("walkDown"));

        // print("up:"+animator.GetBool("walkUp")+" down:"+animator.GetBool("walkDown")+" left:"+animator.GetBool("walkLeft")+" right:"+animator.GetBool("walkRight"));
        
        // Set the score and health
        scoreBoard.SetScore(score);

        // Check if player run out of stamina
        checkOutOfStamina();
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
        if(this.score > 0){
            score -= 1;
            scoreText.text = "score :" + score.ToString();
            junkLossed += 1;
        }
    }

    public float getStamina() 
    {
        return this.stamina;
    }

    public int getUsedStamina()
    {
        return (int) Math.Round(this.maxStamina - this.stamina);
    }

    public int getScore()
    {
        return this.score;
    }

    public int getJunkLossed()
    {
        return this.junkLossed;
    }

    public bool getIsInvincible()
    {
        return this.isInvincible;
    }

    public void setInvincible()
    {
        this.isInvincible = true;
        StartCoroutine(PlayerBlink());
        StartCoroutine(InvincibleCoolDown());
    }

    IEnumerator PlayerBlink() {
        while(isInvincible){
            if (a >= maximum) increasing = false;
            if (a <= minimum) increasing = true;
            a = increasing ? a += 0.2f: a -= 0.2f;
            color.a = a;
            sr.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator InvincibleCoolDown() {
        // wait for amount of time 
        yield return new WaitForSeconds(invincibleCoolDown);

        // set invincible back to false
        this.isInvincible = false;

        // set blinking back to normal
        color.a = 1f;
        sr.color = color;
    }


    public void KnockBack(Vector2 knockBackForce) {
        this.knockBackDirection = knockBackForce;
        StartCoroutine(KnockBackReduce());
    }

    IEnumerator KnockBackReduce() {
        while(this.knockBackDirection.magnitude > 0.2f)
        {
            this.knockBackDirection *= 0.5f;
            yield return new WaitForSeconds(0.1f);
        }
        this.knockBackDirection = Vector2.zero;
    }

    public void checkOutOfStamina() {
        // while(this.stamina > 0);
        if(this.stamina <= 0){
            PlayerPrefs.DeleteKey("inGameStamina");
            PlayerPrefs.DeleteKey("inGameScore");
            PlayerPrefs.DeleteKey("inGameJunkLossed");
            PlayerPrefs.DeleteKey("inGameLastLevel");
            PlayerPrefs.DeleteKey("Level1_isVisited");
            PlayerPrefs.DeleteKey("Level2_isVisited");
            PlayerPrefs.DeleteKey("Level3_isVisited");

            GameObject[] allTrashes = GameObject.FindGameObjectsWithTag("Trash");
            foreach (GameObject trashManager in allTrashes)
            {
                Destroy(trashManager);
            }

            SummaryReportController.AssignVariable(this.score, (int) Math.Round(this.maxStamina), this.junkLossed, (int) Math.Round((score*1)*0.5));

            SceneManager.LoadScene("Summary");
        }
    }
}
