using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeControl : MonoBehaviour
{
    public AudioSource musicSource; // Audio source
    public Slider volumeSlider; // Volume slider

    void Start()
    {
        // Set the initial value of the slider to match the current volume
        volumeSlider.value = musicSource.volume;
    }

    public void SetVolume()
    {
        // Update the volume of the music source based on the slider's value
        musicSource.volume = volumeSlider.value;
    }
}
