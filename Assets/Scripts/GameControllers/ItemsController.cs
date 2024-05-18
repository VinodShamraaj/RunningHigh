using System;
using UnityEngine;

public class ItemsController : MonoBehaviour
{

    [SerializeField]
    private GameObject mobilePlatformPrefab;
    [SerializeField]
    private GameObject wrenchPrefab;
    [SerializeField]
    private GameObject bucketPrefab;
    [SerializeField]
    private GameObject rockPrefab;

    private GameObject platformRef;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool isHelmetActive = false;
    private bool isPlatformActive = false;

    private float startDelay = 2.0f;
    private float spawnInterval;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spawnInterval = UnityEngine.Random.Range(3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (startDelay > 0f)
        {
            startDelay -= Time.deltaTime;
        }
        else
        {
            if (spawnInterval > 0f)
            {
                spawnInterval -= Time.deltaTime;
            }
            else
            {
                SpawnHazard();
                spawnInterval = UnityEngine.Random.Range(3f, 5f);
            }
        }
    }

    public bool IsHelmetToggled()
    {
        return isHelmetActive;
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

    private void SpawnHazard()
    {
        Int16 randomSpawnSelect = (Int16)UnityEngine.Random.Range(0, 3);

        switch (randomSpawnSelect)
        {
            case 0:
                Instantiate(rockPrefab, new Vector2(transform.position.x, transform.position.y + 300f), Quaternion.identity);
                break;
            case 1:
                Instantiate(wrenchPrefab, new Vector2(transform.position.x, transform.position.y + 300f), Quaternion.identity);
                break;
            case 2:
                Instantiate(bucketPrefab, new Vector2(transform.position.x, transform.position.y + 300f), Quaternion.identity);
                break;
            default:
                Instantiate(rockPrefab, new Vector2(transform.position.x, transform.position.y + 300f), Quaternion.identity);
                break;
        }
    }
}
