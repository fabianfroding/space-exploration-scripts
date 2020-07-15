using UnityEngine;

public class AgosScript : PlanetScript
{
    [SerializeField]
    private GameObject asteroidRef;

    public void Start()
    {
        int additionalAsteroids = 0;
        
        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            additionalAsteroids = 2;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            additionalAsteroids = 4;
        }

        for (int i = 0; i < additionalAsteroids; i++)
        {
            int randomDir = Random.Range(0, 3);
            Vector3 dir;
            Vector3 orbitDir;
            if (randomDir == 0)
            {
                dir = new Vector3(Random.Range(1.5f, 3), 0, 0);
                orbitDir = Vector3.right;
            }
            else if (randomDir == 1)
            {
                dir = new Vector3(0, Random.Range(1.5f, 3), 0);
                orbitDir = Vector3.up;
            }
            else
            {
                dir = new Vector3(0, 0, Random.Range(1.5f, 3));
                orbitDir = Vector3.forward;
            }
            GameObject asteroid = Instantiate(asteroidRef, transform.position + dir, transform.rotation, transform);
            asteroid.GetComponent<OrbitScript>().orbitObject = this.gameObject;
            asteroid.GetComponent<OrbitScript>().orbitDirection = orbitDir;
        }
    }
}
