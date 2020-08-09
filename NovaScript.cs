using UnityEngine;

public class NovaScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        GetComponent<SphereCollider>().isTrigger = false;
    }
}
