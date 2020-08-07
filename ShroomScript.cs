using UnityEngine;

public class ShroomScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject sporeRef;

    private float cooldown = 8f;
    private int numProjectiles = 2;
    private float spawnDistance = 1f;

    private void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            cooldown = 6;
            numProjectiles = 3;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            cooldown = 4;
            numProjectiles = 4;
        }

        Invoke("LaunchSpores", 2f);
    }

    private void LaunchSpores()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 280) {
            for (int i = 0; i < numProjectiles; i++)
            {
                Vector3 position = new Vector3(
                    Random.Range(-spawnDistance, spawnDistance),
                    Random.Range(-spawnDistance, spawnDistance),
                    Random.Range(-spawnDistance, spawnDistance)
                    );

                GameObject spore;
                spore = Instantiate(sporeRef, position + this.transform.position, Quaternion.identity) as GameObject;
                Vector3 randomDirection = new Vector3(Random.value * 360, Random.value * 360, Random.value * 360);
                spore.transform.Rotate(randomDirection);
                spore.transform.parent = this.gameObject.transform;
            }
        }

        Invoke("LaunchSpores", cooldown);
    }
}
