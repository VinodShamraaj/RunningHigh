using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // Reference to UI text that shows the score value
    [SerializeField]
    private Text scoreText;

    // Reference to UI text that shows the timer value
    [SerializeField]
    private Text timerText;

    private Rigidbody2D rigidBody;

    // Calculated distance value
    private Int16 score;
    private Int16 startpoint;

    private float secondsTimer;
    private float elapsedTime;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        startpoint = (Int16)Math.Round(rigidBody.position.x);
    }

    // Update is called once per frame
    private void Update()
    {
        // Add timer here
        elapsedTime += Time.deltaTime;
        Int16 minutes = (Int16)Mathf.FloorToInt(elapsedTime / 60);
        Int16 seconds = (Int16)Mathf.FloorToInt(elapsedTime % 60);


        // Calculate score every second instead of frame
        // Used delta time instead of Coroutine
        secondsTimer += Time.deltaTime;

        Int16 currentScore = (Int16)Mathf.FloorToInt(rigidBody.transform.position.x - startpoint);
        Int16 scoreByFifty = (Int16)(Mathf.FloorToInt(currentScore / 50) * 50);

        // Prevent lower score
        if (score < scoreByFifty)
        {
            // Display distance value via UI text
            scoreText.text = "SCORE: " + scoreByFifty.ToString();
            score = scoreByFifty;
        }

        while (secondsTimer >= 1f)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            secondsTimer -= 1f;
        }
    }

}
