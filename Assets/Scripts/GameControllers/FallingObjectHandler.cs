using UnityEngine;

public class FallingObjectHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreHandler;

    private ScoreController scoreController;
    private ItemsController itemsController;

    private void Start()
    {
        scoreHandler = GameObject.Find("/ScoreHandler");
        scoreController = scoreHandler.GetComponent<ScoreController>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            itemsController = col.gameObject.GetComponent<ItemsController>();

            if (!itemsController.IsHelmetToggled())
            {
                scoreController.DecreaseScore(50);
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
