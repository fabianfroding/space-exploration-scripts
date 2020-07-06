using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    [SerializeField]
    private GameObject orbitObject;

    [SerializeField]
    private float orbitSpeed = 0.01f; // In case forgetting to set individual speed in scene.

    private void Update()
    {
        transform.RotateAround(orbitObject.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
