using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity = 100f;

    [SerializeField]
    GameObject player;

    private float scrollSensitivity = 17f;
    private float minFOV = 50;
    private float maxFOV = 90;

    private void Update()
    {
        // Consider moving this if-statement to player controller instead.
        if (Input.GetMouseButton(1))
        {
            player.transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
            player.transform.Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity, 0, 0);
        }

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -scrollSensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }
}
