using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance {get; set;}

    public AudioSource audioMusic;
    public AudioClip[] musicClips;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void ChangeMusic()
    {
        for (int i = 0; i < musicClips.Length; i++)
        {
            if (i == SceneManager.GetActiveScene().buildIndex)
            {   
                audioMusic.Stop();
                audioMusic.clip = musicClips[i];
                audioMusic.Play();
                break;
            }
        }
    }
}
