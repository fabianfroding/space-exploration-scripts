using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    [SerializeField]
    private GameObject orbitObject;

    [SerializeField]
    private float orbitSpeed = 4f;

    private void Update()
    {
        transform.RotateAround(orbitObject.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
