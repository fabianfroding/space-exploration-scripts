using UnityEngine;

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
