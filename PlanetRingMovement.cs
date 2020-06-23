using UnityEngine;

public class PlanetRingMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject orbitObject;

    [SerializeField]
    private float speed = 1f;


    void Update()
    {
        transform.RotateAround(orbitObject.transform.position, Vector3.right, speed * Time.deltaTime);
    }
}
