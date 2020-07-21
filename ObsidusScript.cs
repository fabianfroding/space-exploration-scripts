using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsidusScript : PlanetScript
{
    [SerializeField]
    private GameObject obsidianRockRef;

    private float launchRocksCooldown = 20f;
    private int numRocks = 100;
    private float spawnDistance = 30f;

    private void Start()
    {
        Invoke("LaunchRocks", 2f);
    }

    private void LaunchRocks()
    {
        Debug.Log("Launching obisidian rocks");

        for (int i = 0; i < numRocks; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-spawnDistance, spawnDistance), 
                Random.Range(-spawnDistance, spawnDistance), 
                Random.Range(-spawnDistance, spawnDistance)
                );

            GameObject rock;
            rock = Instantiate(obsidianRockRef, position + this.transform.position, Quaternion.identity) as GameObject;
            rock.transform.parent = this.gameObject.transform;
        }

        Invoke("LaunchRocks", launchRocksCooldown);
    }
}
