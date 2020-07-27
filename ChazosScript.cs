using UnityEngine;

public class ChazosScript : PlanetScript
{
    [SerializeField]
    private GameObject mineRef;

    private int numMines = 1200;
    private float spawnDistance = 60f;

    void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            numMines += 500;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            numMines += 1000;
        }

        for (int i = 0; i < numMines; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-spawnDistance, spawnDistance),
                Random.Range(-spawnDistance, spawnDistance),
                Random.Range(-spawnDistance, spawnDistance)
                );

            GameObject mine;
            mine = Instantiate(mineRef, position + this.transform.position, Quaternion.identity) as GameObject;
            mine.transform.rotation = Random.rotation;
            mine.transform.parent = this.gameObject.transform;
        }
    }
}
