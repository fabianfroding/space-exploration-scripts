using UnityEngine;

public class MinesScript : MonoBehaviour
{
    [SerializeField]
    private GameObject mineRef;

    private int numMines = 1200;
    private float spawnDistance = 60f;

    void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            numMines = 1800;
            spawnDistance = 65f;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            numMines = 2400;
            spawnDistance = 70f;
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
