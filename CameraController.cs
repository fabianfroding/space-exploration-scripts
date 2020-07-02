using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float scrollSensitivity = 17f;
    private float minFOV = 50;
    private float maxFOV = 90;

    private void Update()
    {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -scrollSensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }
}
