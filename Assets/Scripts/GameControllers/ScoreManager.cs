using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int inputScore;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private InputField inputName;

    private GameObject scoreHandler;
    private ScoreController scoreController;

    public UnityEvent<string, int> submitScoreEvent;

    private void Start()
    {
        scoreHandler = GameObject.Find("/ScoreHandler");
        scoreController = scoreHandler.GetComponent<ScoreController>();

        inputScore = scoreController.GetScore();
        scoreText.text = inputScore.ToString();
    }
    public void SubmitScore()
    {
        // Getting reference to input score and input name for now
        submitScoreEvent.Invoke(inputName.text, inputScore);
    }


}
