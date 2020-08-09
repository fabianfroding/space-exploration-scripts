using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject planet;

    [SerializeField]
    private GameObject nova;

    [SerializeField]
    private GameObject portalDestination;

    [SerializeField]
    private AudioSource portalSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nova.gameObject.GetComponent<SphereCollider>().isTrigger = true;

            portalSound.Play();

            other.transform.position = portalDestination.gameObject.transform.position;
            other.transform.LookAt(planet.transform);
        }
    }
}
