using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private Text progressScoreText;

    [SerializeField]
    private Text planetsDiscoveredText;

    [SerializeField]
    private Dropdown difficultyDropdown;

    private int numPlanets = 8;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlanetsDiscovered"))
        {
            progressScoreText.text = "Progress: " + (PlayerPrefs.GetInt("PlanetsDiscovered") / (float)numPlanets) * 100.0 + "%";
            planetsDiscoveredText.text = "Planets Discovered: " + PlayerPrefs.GetInt("PlanetsDiscovered") + "/" + numPlanets;
        }
        else
        {
            progressScoreText.text = "Progress: 0%";
            planetsDiscoveredText.text = "Planets Discovered: 0/" + numPlanets;
        }
    }

    public void BTNNewGame_Click()
    {
        progressScoreText.text = "Progress: 0%";
        planetsDiscoveredText.text = "Planets Discovered: 0/" + numPlanets;
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Difficulty", difficultyDropdown.options[difficultyDropdown.value].text);
        SceneManager.LoadScene("Level0");
    }

    public void BTNLoad_Click()
    {
        PlayerPrefs.SetString("Difficulty", difficultyDropdown.options[difficultyDropdown.value].text);
        SceneManager.LoadScene("Level0");
    }

    public void BTNQuit_Click()
    {
        Application.Quit();
    }
}
