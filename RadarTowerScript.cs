using UnityEngine;

public class RadarTowerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;

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
            lineRenderer.SetPosition(0, transform.position);

            Vector3 fromPosition = transform.position;
            Vector3 toPosition = sun.transform.position;
            Vector3 direction = toPosition - fromPosition;

            if (Physics.Raycast(transform.position, direction, out RaycastHit hit))
            {
                if (hit.collider)
                {
                    lineRenderer.SetPosition(1, hit.point);
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

            collision.gameObject.GetComponent<BeamScript>().
                source.gameObject.GetComponent<PlayerScanner>().planetsDiscoveredText.text
                = "Planets Discovered: " + planetsDiscovered.ToString() + "/" + numPlanets;
        }
    }
}
