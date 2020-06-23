using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject orbitObject;

    [SerializeField]
    private float speed = 1f;


    void Update()
    {
        transform.RotateAround(orbitObject.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
