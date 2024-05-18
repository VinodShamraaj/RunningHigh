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

    [SerializeField]
    private GameObject playerObject;

    private Rigidbody2D rigidBody;

    // Calculated distance value
    private Int16 score;
    private Int16 negativeScore = 0;
    private Int16 startpoint;

    private bool negativeScoreSet = false;
    private bool isGameEnded = false;

    private float secondsTimer;
    private float elapsedTime;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {

        rigidBody = playerObject.GetComponent<Rigidbody2D>();
        if (rigidBody != null)
            startpoint = (Int16)Math.Round(rigidBody.position.x);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isGameEnded)
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
            if (score < scoreByFifty || negativeScoreSet)
            {
                // Display distance value via UI text
                scoreText.text = "SCORE: " + (scoreByFifty - negativeScore).ToString();
                score = scoreByFifty;

                negativeScoreSet = false;
            }

            while (secondsTimer >= 1f)
            {
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                secondsTimer -= 1f;
            }
        }
    }

    public void DecreaseScore(Int16 scoreDecrease)
    {
        negativeScore += scoreDecrease;
        negativeScoreSet = true;
    }

    public int GetScore()
    {
        return score - negativeScore;
    }

    public void SetGameEnded()
    {
        isGameEnded = true;
    }
}
