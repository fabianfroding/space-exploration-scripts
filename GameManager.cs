using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private List<GameObject> planets;

    private void Start()
    {
        PlayerPrefsManager.LoadPlayerLocation(player);
        PlayerPrefsManager.LoadPlanetsStatuses(planets);
        PlayerPrefsManager.LoadPlanetsLocations(planets);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefsManager.StorePlayerLocation(player);
            PlayerPrefsManager.StorePlanetStatuses(planets);
            PlayerPrefsManager.StorePlanetLocations(planets);
            SceneManager.LoadScene("MainMenu");
        }
    }
    
}
