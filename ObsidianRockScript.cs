using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsidianRockScript : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(Random.value, Random.value, Random.value) * 900f);

        Invoke("DestroySelf", 15f);
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
