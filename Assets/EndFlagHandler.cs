using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlagHandler : MonoBehaviour
{
    private GameObject scoreHandler;
    private ScoreController scoreController;

    void OnTriggerEnter2D(Collider2D col)
    {
        scoreHandler = GameObject.Find("/ScoreHandler");
        scoreController = scoreHandler.GetComponent<ScoreController>();

        if (col.gameObject.name == "Player")
        {
            scoreController.SetGameEnded();
            SceneManager.LoadSceneAsync(4);
        }
    }
}
