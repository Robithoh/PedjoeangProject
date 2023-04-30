using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    private Slider musicSlider;

    // slider from other scene with tag slider

    private void Start()
    {
        SetMusicVolume();
        
    }

    private void Awake()
    {
        musicSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }
}
