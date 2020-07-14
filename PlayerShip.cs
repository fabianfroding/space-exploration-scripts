﻿using UnityEngine;

/*
 * This class is responsible for behaviour in the player/ship that is unrelated to the movement of the ship.
 */
public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    private AudioSource engineSound;

    [SerializeField]
    private AudioSource boostSound;

    [SerializeField]
    private TrailRenderer trailRenderer;

    private bool boost = false;

    private Vector3 respawnPos = new Vector3(235, 14, -750);
    private Vector3 respawnRot = new Vector3(5, -17.5f, 0);


    public void DestroySelf()
    {
        // Disable player
        GetComponent<MeshRenderer>().enabled = false; // TODO: NOT WORKING
        GetComponent<PlayerController>().enabled = false;


        // Play explosion SFX

        // Call respawn
        Invoke("Respawn", 3.5f);
    }

    private void Respawn()
    {
        // Move player to respawn loc.
        transform.position = respawnPos;
        transform.rotation = Quaternion.Euler(respawnRot);

        // Enable player
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<PlayerController>().enabled = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!engineSound.isPlaying)
            {
                engineSound.Play();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!boost)
                {
                    boost = true;
                    boostSound.Play();
                    trailRenderer.time = 0.5f / 3f;
                    Invoke("ResetBoost", 2.33f); // 2~ sec is the same duration as the speed boost in PlayerController.
                }
            }
        }
        else
        {
            engineSound.Stop();
        }
    }

    private void ResetBoost()
    {
        trailRenderer.time = 0.5f;
        boost = false;
    }
}
