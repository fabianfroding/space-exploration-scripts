﻿using UnityEngine;

public class EruptScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject eruptProjectile;

    [SerializeField]
    private AudioSource eruptSound;

    private float eruptCooldown = 12.5f;
    private int numProjectiles = 100;
    private float spawnDistance = 30f;

    private void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            eruptCooldown = 10;
            numProjectiles = 175;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            eruptCooldown = 7.5f;
            numProjectiles = 250;
        }

        Invoke("Erupt", 2f);
    }

    private void Erupt()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 300)
        {
            eruptSound.Play();

            for (int i = 0; i < numProjectiles; i++)
            {
                Vector3 position = new Vector3(
                    Random.Range(-spawnDistance, spawnDistance),
                    Random.Range(-spawnDistance, spawnDistance),
                    Random.Range(-spawnDistance, spawnDistance)
                    );

                GameObject rock;
                rock = Instantiate(eruptProjectile, position + this.transform.position, Quaternion.identity) as GameObject;
                Vector3 randomDirection = new Vector3(Random.value * 360, Random.value * 360, Random.value * 360);
                rock.transform.Rotate(randomDirection);
                rock.transform.parent = this.gameObject.transform;
            }
        }

        Invoke("Erupt", eruptCooldown);
    }
}
