using UnityEngine;

public class PlayerPlaceholder : MonoBehaviour
{
    public GameObject player;
    public GameObject planet;

    void Update()
    {
        // Smooth

        // Position
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.1f);
        Vector3 gravDirection = (transform.position - planet.transform.position).normalized;

        // Rotation
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.1f);
    }

    public void NewPlanet(GameObject newPlanet)
    {
        planet = newPlanet;
    }
}
