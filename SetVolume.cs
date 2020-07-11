using UnityEngine;
using UnityEngine.Audio;

/*
 * This class manages the audio volume that the player controls from the Options menu by using Mixers.
 */
public class SetVolume : MonoBehaviour
{
    [SerializeField]
    private AudioMixer musicMixer;

    [SerializeField]
    private AudioMixer soundMixer;

    /*
     * These two methods uses a logarithmic slider value range to reflect the exact volume adjustment.
     * This is because the standard slider value range is linear and the Mixer-fader range is logarithmic.
     * This causes problems in terms of reflecting the exact intended volume.
     * This approach fixes that issue.
     */
    public void SetLevel(float sliderValue)
    {
        musicMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSoundLevel(float sliderValue)
    {
        soundMixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
    }
}
