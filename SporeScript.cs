using UnityEngine;

public class SporeScript : MonoBehaviour
{
    private float speed = 3f;

    void Start()
    {
        Invoke("DestroySelf", 20f);

        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            speed = 4f;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            speed = 5f;
        }
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerShip>().DestroySelf();
        }
    }
}
