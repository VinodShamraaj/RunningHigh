using UnityEngine;

public class ItemsController : MonoBehaviour
{

    [SerializeField]
    private GameObject mobilePlatformPrefab;

    private GameObject platformRef;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool isHelmetActive = false;
    private bool isPlatformActive = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleHelmet()
    {
        animator.SetBool("IsHat", !isHelmetActive);
        isHelmetActive = !isHelmetActive;
    }

    public void SpawnMobilePlatform()
    {
        if (!isPlatformActive)
        {
            if (transform.localScale.x > 0)
                platformRef = Instantiate(mobilePlatformPrefab, new Vector2(transform.position.x + 150f, transform.position.y + 20f), Quaternion.identity);
            else
                platformRef = Instantiate(mobilePlatformPrefab, new Vector2(transform.position.x - 150f, transform.position.y + 20f), Quaternion.identity);
            isPlatformActive = true;
        }
        else
        {
            if (platformRef != null)
            {
                isPlatformActive = false;
                Destroy(platformRef);
            }

        }

    }
}
