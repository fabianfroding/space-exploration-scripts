using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    private AudioSource engineSound;
    
    private void FixedUpdate()
    {
        if (Input.GetKey("space"))
        {
            if (!engineSound.isPlaying)
            {
                engineSound.Play();
            }
        }
        else
        {
            engineSound.Stop();
        }
    }
}
