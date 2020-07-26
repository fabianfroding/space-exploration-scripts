using UnityEngine;

public class AgosScript : PlanetScript
{
    [SerializeField]
    public GameObject[] additionalAsteroids;

    public void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            additionalAsteroids[0].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            additionalAsteroids[0].gameObject.SetActive(false);
            additionalAsteroids[1].gameObject.SetActive(false);
        }
    }
}
