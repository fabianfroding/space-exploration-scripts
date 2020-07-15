using System.Collections;
using UnityEngine;

/*
 * This class is responsible for the movement of the player/ship.
 */
public class PlayerController : MonoBehaviour
{
    public GameObject planet;
    public GameObject playerPlaceholder;

    public float speed = 12;
    public float jumpHeight = 1.2f;

    float gravity = 100;
    bool onGround = false;

    float distanceToGround;
    Vector3 groundNormal;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    float mouseSensitivity = 100f;

    private Rigidbody rb;

    private bool boost = false;
    private float boostSpeed = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // To prevent collision with other object from adding force to the ship.
    }

    private void Update()
    {
        if (!IsDead())
        {
            if (Input.GetMouseButton(1))
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
                transform.Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity, 0, 0);
            }
            else
            {
                transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * 45f * Time.deltaTime, Space.Self);
                transform.Rotate(Vector3.right * -Input.GetAxisRaw("Vertical") * 45f * Time.deltaTime, Space.Self);
            }

            if (Input.GetKey("space"))
            {
                transform.Translate(Vector3.forward * speed * boostSpeed * Time.deltaTime);
            }

            // On-planet movement considering gravity.

            if (planet != null)
            {
                // Movement
                //float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

                //transform.Translate(0, 0, z);

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
    }

    private void FixedUpdate()
    {
        if (!IsDead())
        {
            if (!boost && Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.Q))
            {
                boostSpeed = 3;
                StartCoroutine("FadeBoostSpeed");
            }
        }
    }

    IEnumerator FadeBoostSpeed()
    {
        boost = true;
        while (boost)
        {
            if (boostSpeed > 1)
            {
                boostSpeed -= 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                boostSpeed = 1;
                boost = false;
            }
        }
        boost = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsDead())
        {
            if (other.CompareTag("Planet"))
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!IsDead())
        {
            if (other.CompareTag("Planet"))
            {
                Debug.Log("Left planet");
                planet = null;
                speed = 8;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    private bool IsDead()
    {
        return !GetComponent<MeshRenderer>().enabled;
    }

}
