using UnityEngine;

public class MobilePlatformHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject wholeObject;
    [SerializeField]
    private GameObject baseObject;
    [SerializeField]
    private GameObject beamObject;

    [SerializeField]
    private float extension;

    [SerializeField]
    private float increments;

    private Transform beamTransform;
    private Rigidbody2D wholeRigidBody;
    private Rigidbody2D platformRigidBody;
    private Rigidbody2D baseRigidBody;

    private bool isInitialSet = false;
    private bool isCollide = false;
    private Vector2 topPos;
    private Vector2 bottomPos;


    void Start()
    {
        if (beamObject != null)
            beamTransform = beamObject.GetComponent<Transform>();

        if (wholeObject != null)
            wholeRigidBody = wholeObject.GetComponent<Rigidbody2D>();

        if (baseObject != null)
            baseRigidBody = baseObject.GetComponent<Rigidbody2D>();

        platformRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInitialSet && wholeRigidBody.velocity.y == 0)
        {
            Debug.Log("hit bottom");
            baseRigidBody.gravityScale = 0;
            platformRigidBody.gravityScale = 0;
            wholeRigidBody.gravityScale = 0;

            wholeRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            baseRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;

            bottomPos = transform.position;
            topPos = new Vector2(transform.position.x, transform.position.y + extension);

            isInitialSet = true;
        }
        if (isInitialSet)
        {

            if (isCollide && transform.position.y < topPos.y)
            {
                MoveUp();
            }
            if (!isCollide && transform.position.y > bottomPos.y)
            {
                MoveDown();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            isCollide = true;
            col.gameObject.transform.SetParent(transform);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            isCollide = false;
            col.gameObject.transform.SetParent(null);
        }
    }

    private void MoveUp()
    {
        Debug.Log("move up");
        platformRigidBody.MovePosition(transform.position + Vector3.up * increments * Time.deltaTime);
        beamTransform.localScale.Set(beamTransform.localScale.x, beamTransform.localScale.y + (increments / 2 * Time.deltaTime), beamTransform.localScale.z);
        beamTransform.position.Set(beamTransform.position.x, beamTransform.position.y + (increments * Time.deltaTime), 0);
    }

    private void MoveDown()
    {
        platformRigidBody.MovePosition(transform.position + Vector3.down * increments * Time.deltaTime);
        beamTransform.localScale.Set(beamTransform.localScale.x, beamTransform.localScale.y - (increments / 2 * Time.deltaTime), beamTransform.localScale.z);
        beamTransform.position.Set(beamTransform.position.x, beamTransform.position.y - (increments * Time.deltaTime), 0);
    }
}
