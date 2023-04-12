using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inGameScoreBoard : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    public void SetScore(int score)
    {
        scoreText.text = "x " + score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
