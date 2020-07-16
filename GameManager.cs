using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    public List<GameObject> planets;

    private void Start()
    {
        PlayerPrefsManager.LoadPlayerLocation(player);
        PlayerPrefsManager.LoadPlanetsStatuses(planets);
        PlayerPrefsManager.LoadPlanetsLocations(planets);
        PlayerPrefsManager.LoadCameraFOV();

        if (!PlayerPrefs.HasKey("Difficulty"))
        {
            PlayerPrefs.SetString("Difficulty", "Easy");
        }
        Debug.Log("Difficulty: " + PlayerPrefs.GetString("Difficulty"));

        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefsManager.StorePlayerLocation(player);
            PlayerPrefsManager.StorePlanetStatuses(planets);
            PlayerPrefsManager.StorePlanetLocations(planets);
            PlayerPrefsManager.StoreCameraFOV();
            Cursor.visible = true;
            SceneManager.LoadScene("MainMenu");
        }
    }
    
}
