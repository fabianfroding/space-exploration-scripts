using UnityEngine;

public class StalkerScript : MonoBehaviour
{
    public GameObject target;

    private float speed = 10f;

    void Start()
    {
        float timedLife = 30f;
        

        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            speed = 11.5f;
            timedLife = 35f;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            speed = 13f;
            timedLife = 40f;
        }

        Invoke("DestroySelf", timedLife);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.LookAt(target.transform);
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
