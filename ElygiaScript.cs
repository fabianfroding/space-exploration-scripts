using UnityEngine;

public class ElygiaScript : MonoBehaviour
{
    [SerializeField]
    private GameObject source;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject missileRef;

    private float missileCD = 4.5f;
    private bool missileOnCD = false;

    private void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            missileCD = 3.25f;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            missileCD = 2f;
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, source.transform.position) < 280 && !missileOnCD)
        {
            missileOnCD = true;

            GameObject missile = Instantiate(missileRef);
            missile.GetComponent<MissileScript>().source = source.gameObject;
            missile.transform.position = new Vector3(
                source.transform.position.x + source.transform.localScale.x + 5,
                source.transform.position.y + source.transform.localScale.y + 5,
                source.transform.position.z + source.transform.localScale.z + 5
                );
            missile.transform.LookAt(player.transform);

            Invoke("ResetMissileCD", missileCD);
        }
    }

    private void ResetMissileCD()
    {
        missileOnCD = false;
    }
}
