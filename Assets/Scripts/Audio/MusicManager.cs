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
    
    // public void ChangeMusic()
    // {
    //     for (int i = 0; i < musicClips.Length; i++)
    //     {
    //         if (i == SceneManager.GetActiveScene().buildIndex)
    //         {   
    //             audioMusic.Stop();
    //             audioMusic.clip = musicClips[i];
    //             audioMusic.Play();
    //             break;
    //         }
    //     }
    // }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeMusic(scene.name); // atau ChangeMusic(scene.buildIndex);
    }

    public void ChangeMusic(string sceneName)
    {
        AudioClip selectedClip = null;

        // Pemilihan klip musik berdasarkan nama scene
        if (sceneName == "MainMenu" || sceneName == "PedjoeangSelection")
        {
            selectedClip = musicClips[0]; // Ganti dengan indeks atau nama yang sesuai
        }
        else if (sceneName == "MainScene")
        {
            selectedClip = musicClips[1]; // Ganti dengan indeks atau nama yang sesuai
        }
        else if (sceneName == "TurnBased1" || sceneName == "TurnBased2" || sceneName == "TurnBased3" || sceneName == "TurnBased1_OWA"|| sceneName == "TurnBased2_OWA"|| sceneName == "TurnBased3_OWA")
        {
            selectedClip = musicClips[2]; // Ganti dengan indeks atau nama yang sesuai
        }
        // Tambahkan if statements untuk scene lain jika diperlukan
        // ...

        // Jika tidak ada pemilihan khusus, gunakan klip musik sesuai indeks scene
        if (selectedClip == null)
        {
            int sceneIndex = SceneManager.GetSceneByName(sceneName).buildIndex;
            if (sceneIndex >= 0 && sceneIndex < musicClips.Length)
            {
                selectedClip = musicClips[sceneIndex];
            }
        }

        if (selectedClip != null)
        {
            audioMusic.Stop();
            audioMusic.clip = selectedClip;
            audioMusic.Play();
        }
    }
}
