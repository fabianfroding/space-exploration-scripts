using System.Collections.Generic;
using UnityEngine;

public class SolarSystemScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;

    [SerializeField]
    List<GameObject> planets;

    void Start()
    {
        float distance = 250f;
        foreach (GameObject planet in planets)
        {
            distance += 150f;
        }
    }

    private void Update()
    {
        foreach (GameObject planet in planets)
        {
            float planetSpeed = planet.gameObject.GetComponent<PlanetScript>().speed;
            planet.transform.RotateAround(sun.transform.position, Vector3.up, planetSpeed * Time.deltaTime);
        }
    }

}
