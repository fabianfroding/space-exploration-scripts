using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    private AudioSource engineSound;

    [SerializeField]
    private AudioSource boostSound;

    [SerializeField]
    private TrailRenderer trailRenderer;
    
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
                if (!boostSound.isPlaying)
                {
                    boostSound.Play();
                    trailRenderer.time = 0.5f / 3f;
                    Invoke("ResetTrailRenderer", boostSound.clip.length);
                }
            }
        }
        else
        {
            engineSound.Stop();
        }
    }

    private void ResetTrailRenderer()
    {
        trailRenderer.time = 0.5f;
    }
}
