using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void BTNPlay_Click()
    {
        SceneManager.LoadScene("Level0");
    }

    public void BTNQuit_Click()
    {
        Application.Quit();
    }
}
