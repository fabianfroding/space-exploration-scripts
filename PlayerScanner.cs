using UnityEngine;
using UnityEngine.UI;

public class PlayerScanner : MonoBehaviour
{
    public Text planetsDiscoveredText;

    [SerializeField]
    private Text scanTextPlanet;

    [SerializeField]
    private Text scanTextDistance;

    [SerializeField]
    private Text victoryText;

    [SerializeField]
    private AudioSource logOpenSound;

    [SerializeField]
    private AudioSource logCloseSound;

    private float range = 2000f;

    private void Start()
    {
        planetsDiscoveredText.text = "Planets Discovered: " + PlayerPrefs.GetInt("PlanetsDiscovered").ToString();
        victoryText.enabled = false;
    }

    private void FixedUpdate()
    {
        // Planets LayerMask is used to prevent objects in front of planets from interfering with the raycast,
        // such as bullets, environments etc.
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range, 1 << LayerMask.NameToLayer("Planets")))
        {
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Planet"))
                {
                    float dist = Vector3.Distance(hit.transform.position, transform.position);
                    bool planetDiscovered = hit.transform.gameObject.GetComponent<PlanetScript>().discovered;

                    if (dist < hit.transform.localScale.x + 25)
                    {
                        scanTextDistance.text = "Distance: -";
                    }
                    else
                    {
                        scanTextDistance.text = "Distance: " + dist.ToString("F2");
                    }

                    if (planetDiscovered)
                    {
                        scanTextPlanet.text = hit.transform.name;
                    }
                    else
                    {
                        scanTextPlanet.text = "Unknown Planet";
                    }
                }
                else
                {
                    scanTextPlanet.text = "";
                    scanTextDistance.text = "";
                }
            }
            else
            {
                scanTextPlanet.text = "";
                scanTextDistance.text = "";
            }
        }
        else
        {
            scanTextPlanet.text = "";
            scanTextDistance.text = "";
        }
    }

    public void ShowVictoryText()
    {
        Invoke("UpdateVictoryText", 1.2f);
    }

    private void UpdateVictoryText()
    {
        victoryText.enabled = true;
        logOpenSound.Play();
        Invoke("ResetVictoryText", 5f);
    }

    private void ResetVictoryText()
    {
        logCloseSound.Play();
        victoryText.enabled = false;
    }
}
