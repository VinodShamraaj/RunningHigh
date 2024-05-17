using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField]
    private bool isBackpackOpen = false;
    [SerializeField]
    private bool isHelmetActive = false;

    [SerializeField]
    private float helmetX;
    [SerializeField]
    private float helmetY;

    [SerializeField]
    private ScoreController scoreController;

    [SerializeField]
    private GameObject mobilePlatformPrefab;


    void Start()
    {
        scoreController = GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleHelmet()
    {
        isHelmetActive = !isHelmetActive;
    }

    public void SpawnMobilePlatform()
    {
        Instantiate(mobilePlatformPrefab, new Vector2(0, 0), Quaternion.identity);
    }
}
