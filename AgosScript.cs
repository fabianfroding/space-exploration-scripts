using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgosScript : PlanetScript
{
    [SerializeField]
    private List<GameObject> asteroids;

    public void Start()
    {
        asteroids = new List<GameObject>();
        
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {

        }
    }
}
