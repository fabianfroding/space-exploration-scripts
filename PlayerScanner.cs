using UnityEngine;
using UnityEngine.UI;

public class PlayerScanner : MonoBehaviour
{
    [SerializeField]
    private Text scanTextPlanet;

    [SerializeField]
    private Text scanTextDistance;

    private float range = 2000f;

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range))
        {
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Planet"))
                {
                    float dist = Vector3.Distance(hit.transform.position, transform.position);
                    bool planetDiscovered = hit.transform.gameObject.GetComponent<PlanetScript>().discovered;

                    // TODO: Consider planet scale/sphere radius
                    if (dist < 50)
                    {
                        scanTextDistance.text = "Distance: -";
                        if (!planetDiscovered)
                        {
                            hit.transform.gameObject.GetComponent<PlanetScript>().discovered = true;
                        }
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
}
