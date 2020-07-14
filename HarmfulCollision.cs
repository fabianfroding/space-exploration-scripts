using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmfulCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // Also checking that the player object is active so it doesn't trigger this collision recursively.
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<MeshRenderer>().enabled)
        {
            other.gameObject.GetComponent<PlayerShip>().DestroySelf();
        }
    }
}
