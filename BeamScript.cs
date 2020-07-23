using UnityEngine;

public class BeamScript : MonoBehaviour
{
    private float speed = 30f;

    void Start()
    {
        Invoke("DestroySelf", 2f);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        // TODO: Check collision
        // If planet tower, destroy self and tower.
        // If collide with harmful or planet, destroy self.
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
