using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public GameObject source;

    private float speed = 25f;

    void Start()
    {
        Invoke("DestroySelf", 8f);

        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            speed = 30f;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            speed = 35f;
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
}
