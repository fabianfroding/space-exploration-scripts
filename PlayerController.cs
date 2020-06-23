using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject planet;
    public GameObject playerPlaceholder;

    public float speed = 4;
    public float jumpHeight = 1.2f;

    float gravity = 100;
    bool onGround = false;

    float distanceToGround;
    Vector3 groundNormal;

    [SerializeField]
    private Camera cam;

    private Rigidbody rb;

    float roll;
    float pitch;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        roll = Input.GetAxisRaw("Horizontal");
        pitch = Input.GetAxisRaw("Vertical");
        transform.Rotate(Vector3.up * roll * 50f * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.right * -pitch * 50f * Time.deltaTime, Space.Self);

        if (Input.GetKey("space"))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // On-planet movement considering gravity.
        if (planet != null)
        {
            // Movement
            float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(0, 0, z);

            // Local rotation
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0, 150 * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0, -150 * Time.deltaTime, 0);
            }

            // Jump
            if (Input.GetKey(KeyCode.Tab))
            {
                rb.AddForce(transform.up * 40000 * jumpHeight * Time.deltaTime);
            }

            // Ground control
            RaycastHit hit; // = new RaycastHit();
            if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
            {
                distanceToGround = hit.distance;
                groundNormal = hit.normal;
                if (distanceToGround <= 0.1f)
                {
                    onGround = true;
                }
                else
                {
                    onGround = false;
                }
            }

            // Gravity and rotation
            Vector3 gravDirection = (transform.position - planet.transform.position).normalized;
            if (!onGround)
            {
                rb.AddForce(gravDirection * -gravity);
            }

            Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
            transform.rotation = toRotation;
        }

    }

    // Change Planet
    private void OnTriggerEnter(Collider other)
    {
        if (planet == null || other.transform != planet.transform)
        {
            Debug.Log("Entering planet");
            planet = other.transform.gameObject;
            Vector3 gravDirection = (transform.position - planet.transform.position).normalized;
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;
            transform.rotation = toRotation;
            rb.velocity = Vector3.zero;
            rb.AddForce(gravDirection * gravity);
            playerPlaceholder.GetComponent<PlayerPlaceholder>().NewPlanet(planet);
            speed = 4;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Left planet");
        planet = null;
        speed = 8;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
