using UnityEngine;

public class BeamScript : MonoBehaviour
{
    public GameObject source;

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
        DestroySelf();
    }
}
