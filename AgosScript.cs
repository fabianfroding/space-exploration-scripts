using System.Collections.Generic;
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
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            additionalAsteroids[1].gameObject.SetActive(false);
        }
    }
}
