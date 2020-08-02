using UnityEngine;
using UnityEngine.UI;

public class RadarTowerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;

    [SerializeField]
    private GameObject rayPoint;

    [SerializeField]
    private AudioSource discoverPlanetSound;

    private LineRenderer lineRenderer;

    private int numPlanets = 8;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (transform.parent.gameObject.GetComponent<PlanetScript>().discovered)
        {
            lineRenderer.SetPosition(0, rayPoint.transform.position);

            Vector3 fromPosition = rayPoint.transform.position;
            Vector3 toPosition = sun.transform.position;
            Vector3 direction = toPosition - fromPosition;

            if (Physics.Raycast(rayPoint.transform.position, direction, out RaycastHit hit))
            {
                if (hit.collider)
                {
                    lineRenderer.SetPosition(1, hit.point);
                    if (hit.collider.gameObject.CompareTag("Player") &&
                        !hit.collider.gameObject.GetComponent<PlayerShip>().IsDead())
                    {
                        hit.collider.gameObject.GetComponent<PlayerShip>().DestroySelf();
                    }
                }
            }
            else
            {
                lineRenderer.SetPosition(1, toPosition);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Beam") && !transform.parent.gameObject.GetComponent<PlanetScript>().discovered)
        {
            transform.parent.gameObject.GetComponent<PlanetScript>().discovered = true;

            int planetsDiscovered = PlayerPrefs.GetInt("PlanetsDiscovered") + 1;

            PlayerPrefs.SetInt("PlanetsDiscovered", planetsDiscovered);

            GameObject source = collision.gameObject.GetComponent<BeamScript>().source;

            source.gameObject.GetComponent<PlayerScanner>().planetsDiscoveredText.text
                = "Planets Discovered: " + planetsDiscovered.ToString() + "/" + numPlanets;

            discoverPlanetSound.Play();

            if (PlayerPrefs.GetInt("PlanetsDiscovered") >= 8)
            {
                source.gameObject.GetComponent<PlayerScanner>().ShowVictoryText();
            }
        }
    }

    
}
