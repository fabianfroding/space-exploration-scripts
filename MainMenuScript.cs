using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private Text progressScoreText;

    [SerializeField]
    private Text planetsDiscoveredText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlanetsDiscovered"))
        {
            progressScoreText.text = "Progress: " + (PlayerPrefs.GetInt("PlanetsDiscovered") / 8.0) * 100.0 + "%";
            planetsDiscoveredText.text = "Planets Discovered: " + PlayerPrefs.GetInt("PlanetsDiscovered") + "/8";
        }
        else
        {
            progressScoreText.text = "Progress: 0%";
            planetsDiscoveredText.text = "Planets Discovered: 0/8";
        }
    }

    public void BTNNewGame_Click()
    {
        progressScoreText.text = "Progress: 0%";
        planetsDiscoveredText.text = "Planets Discovered: 0/8";
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level0");
    }

    public void BTNLoad_Click()
    {
        SceneManager.LoadScene("Level0");
    }

    public void BTNQuit_Click()
    {
        Application.Quit();
    }
}
