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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Planet"))
            {
                scanTextPlanet.text = hit.transform.name;
                scanTextDistance.text = "Distance: " + (int)Vector3.Distance(hit.transform.position, transform.position);
            }
            else
            {
                scanTextPlanet.text = "";
                scanTextDistance.text = "";
            }
        }
    }
}
