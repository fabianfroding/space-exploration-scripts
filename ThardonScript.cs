using UnityEngine;

public class ThardonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject stalkerRef;

    private float stalkerCD = 30f;
    private bool stalkerOnCD = false;

    private void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            stalkerCD = 25f;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            stalkerCD = 20f;
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 350 && !stalkerOnCD)
        {
            stalkerOnCD = true;

            GameObject stalker = Instantiate(stalkerRef);
            stalker.GetComponent<StalkerScript>().target = player;
            stalker.transform.position = new Vector3(
                transform.position.x + transform.localScale.x / 2,
                transform.position.y + transform.localScale.y / 2,
                transform.position.z + transform.localScale.z / 2
                );
            stalker.transform.LookAt(player.transform);

            Invoke("ResetStalkerCD", stalkerCD);
        }
    }

    private void ResetStalkerCD()
    {
        stalkerOnCD = false;
    }
}
