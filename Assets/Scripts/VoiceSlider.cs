using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Set the slider's initial value to the audio source's volume
        volumeSlider.value = audioSource.volume;

        // Add a listener to the slider to call the ChangeVolume function when the value changes
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    // This function is called when the slider value changes
    void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
