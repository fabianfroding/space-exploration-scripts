using UnityEngine;

/*
 * This class is responsible for behaviour in the player/ship that is unrelated to the movement of the ship.
 */
public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    private GameObject beamRef;

    [SerializeField]
    private AudioSource engineSound;

    [SerializeField]
    private AudioSource boostSound;

    [SerializeField]
    private TrailRenderer trailRenderer;

    [SerializeField]
    private Canvas crossHairCanvas;

    [SerializeField]
    private GameObject playerExplosion;

    private bool boost = false;
    private bool beamOnCD = false;

    private Vector3 respawnPos = new Vector3(235, 14, -750);
    private Vector3 respawnRot = new Vector3(5, -17.5f, 0);


    public void DestroySelf()
    {
        // Disable player
        GetComponent<MeshRenderer>().enabled = false; // TODO: NOT WORKING
        GetComponent<PlayerController>().enabled = false;
        trailRenderer.enabled = false;
        crossHairCanvas.enabled = false;


        // Play explosion SFX
        GameObject tmp = Instantiate(playerExplosion, transform.position, transform.rotation);
        Destroy(tmp, 2);

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
        trailRenderer.enabled = true;
        crossHairCanvas.enabled = true;

        GetComponent<Rigidbody>().velocity = Vector3.zero; // Reset velocity from collision of harmful objects.
    }

    private void FixedUpdate()
    {
        if (!IsDead() &&
            Input.GetKey(KeyCode.Space) ||
            (Input.GetMouseButton(1) && (Input.GetAxisRaw("Horizontal")!= 0 || Input.GetAxisRaw("Vertical") != 0))

            )
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsDead() && !beamOnCD)
        {
            beamOnCD = true;
            Debug.Log("Shoot beam!");

            GameObject beam = Instantiate(beamRef);
            beam.GetComponent<BeamScript>().source = this.gameObject;
            beam.transform.position = transform.position + transform.forward;
            beam.transform.forward = transform.forward; // Make beam point to where player is looking.

            Invoke("ResetBeam", 0.1f);
        }
    }

    private void ResetBoost()
    {
        trailRenderer.time = 0.5f;
        boost = false;
    }

    private void ResetBeam()
    {
        beamOnCD = false;
    }

    private bool IsDead()
    {
        return !GetComponent<MeshRenderer>().enabled;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Harmful") && !IsDead())
        {
            DestroySelf();
        }
    }
}
