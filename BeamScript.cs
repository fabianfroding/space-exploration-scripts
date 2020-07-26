using UnityEngine;

public class BeamScript : MonoBehaviour
{
    public GameObject source;

    [SerializeField]
    private AudioSource deathSound;

    private float speed = 30f;

    void Start()
    {
        Invoke("DestroySelf", 2f);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Beam") && !collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke("DestroySelf");
            // Play death sound
            deathSound.Play();

            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;

            Invoke("DestroySelf", 1.3f);
        }
    }
}
