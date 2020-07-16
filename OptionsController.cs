using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/*
 * This class manages the settings in the Options menu.
 */
public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer musicMixer;

    [SerializeField]
    private AudioMixer soundMixer;

    [SerializeField]
    private Dropdown difficultyDropdown;

    public void Start()
    {
        if (!PlayerPrefs.HasKey("Difficulty"))
        {
            SetDifficulty(difficultyDropdown.options[difficultyDropdown.value].text);
        }
    }

    /*
     * These two methods uses a logarithmic slider value range to reflect the exact volume adjustment.
     * This is because the standard slider value range is linear and the Mixer-fader range is logarithmic.
     * This causes problems in terms of reflecting the exact intended volume.
     * This approach fixes that issue.
     */
    public void SetMusicLevel(float sliderValue)
    {
        musicMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSoundLevel(float sliderValue)
    {
        soundMixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetDifficulty(string difficulty)
    {
        PlayerPrefs.SetString("Difficulty", difficultyDropdown.options[difficultyDropdown.value].text);
    }
}
