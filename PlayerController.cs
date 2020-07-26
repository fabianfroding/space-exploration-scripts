using System.Collections;
using UnityEngine;

/*
 * This class is responsible for the movement of the player/ship.
 */
public class PlayerController : MonoBehaviour
{
    public float speed = 12;

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
                transform.position += transform.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
                transform.position += transform.up * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
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
                Vector3 vel = GetComponent<Rigidbody>().velocity;
                if (vel.x > 0 || vel.y > 0 || vel.z > 0)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                transform.Translate(Vector3.forward * speed * boostSpeed * Time.deltaTime);
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

    private bool IsDead()
    {
        return !GetComponent<MeshRenderer>().enabled;
    }

}
