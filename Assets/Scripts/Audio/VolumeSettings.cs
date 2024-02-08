using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private VolumeInfo volumeInfo;
    private Slider musicSlider;

    private void Start()
    {
        musicSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            musicSlider.value = savedVolume;
            SetMusicVolume(savedVolume);
        }
        else
        {
            musicSlider.value = volumeInfo.volumeLevel;
        }
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();

        volumeInfo.SetVolume(volume);
    }
}