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
        progressScoreText.text = "Progress: " + (PlayerPrefs.GetInt("PlanetsDiscovered") / 8.0) * 100.0 + "%";
        planetsDiscoveredText.text = "Planets Discovered: " + PlayerPrefs.GetInt("PlanetsDiscovered") + "/8";
    }

    public void BTNPlay_Click()
    {
        SceneManager.LoadScene("Level0");
    }

    public void BTNQuit_Click()
    {
        Application.Quit();
    }
}
