using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject target;
    public float xSpeed = 3.5f;

    private Camera cam;

    float sensitivity = 17f;
    float minFov = 35;
    float maxFov = 100;

    private Vector3 previousPosition;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        /*Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Lerp: Linear interpolation (from pos, to pos, time 0-1).
        transform.position = smoothPosition;*/
    }

    void Update()
    {
        // Determine type of camera control if player is on planet or in space.
        // Tried checking 'onGround' at first, but always returned false.
        // Found workaround by checking if 'planet' is null instead, which serves the same purpose for this condition.

        // The reason we don't want the same "sphere-orbit" camera for on-planet navigation is becuase it allows the player
        // to turn the camera to inside the planet, which looks bad and gives impression of poor camera system.
        /*if (target.GetComponent<PlayerController>().planet == null)
        {
            // Use camera for space navigation.
            if (Input.GetMouseButtonDown(1))
            {
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(1))
            {
                Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);
                cam.transform.position = target.transform.position;
                cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
                cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
                cam.transform.Translate(new Vector3(0, 0, -10));
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }
            
        }
        else
        {
            // Use camera for planet navigation.
            if (Input.GetMouseButton(1))
            {
                transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * xSpeed);
                transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse Y") * xSpeed);
            }
        }*/

        // Zoom
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
