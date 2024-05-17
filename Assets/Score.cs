using System;
using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour
{
    private int startpoint;
    float scoreCounter;


    // Reference to UI text that shows the score value
    [SerializeField]
    private Text scoreText;
    private GameObject playerObj = null;

    // Calculated distance value
    private float score;

    // Reference to UI text that shows the score value
    [SerializeField]
    private Text timerText;
    private float elapsedTime;

        private void Start()
    {
        startpoint = 354;
        //If you want to find it by NAME. For this you have to make sure you only have 1 object named "Player".
        if (playerObj == null)
            playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        // Add timer here
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime/60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Calculate score every second instead of frame
        // Used delta time instead of Coroutine
        scoreCounter += Time.deltaTime;

        while(scoreCounter >= 1f) {
            // Calculate distance value between character and startpoint
            score = (float)Math.Round(playerObj.transform.position.x - startpoint);

            // Prevent negative
            if (score < 0)
                score  = 0;

            // Display distance value via UI text
            scoreText.text = "Score: " + score.ToString();
            scoreCounter -= 1f;
        }
    }

}
