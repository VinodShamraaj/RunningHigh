using System;
using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour
{
    private int startpoint;

    // Reference to UI text that shows the distance value
    [SerializeField]
    private Text scoreText;
    private GameObject playerObj = null;

    // Calculated distance value
    private float score;

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
        // Calculate distance value between character and startpoint
        score = (float)Math.Round(playerObj.transform.position.x - startpoint);

        // Prevent negative
        if (score < 0)
            score  = 0;

        // Display distance value via UI text
        scoreText.text = "Score: " + score.ToString();
    }

}
