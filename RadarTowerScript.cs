using UnityEngine;

public class RadarTowerScript : MonoBehaviour
{   
    private int numPlanets = 8;

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
