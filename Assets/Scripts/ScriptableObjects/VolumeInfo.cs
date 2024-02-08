using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VolumeInfo", menuName = "AudioControl")]
public class VolumeInfo : ScriptableObject
{
    [Range(0.0f, 1.0f)] // Menambahkan atribut Range untuk membatasi nilai volume antara 0 dan 1
    public float volumeLevel;

    // Metode untuk mengatur volume dari luar objek
    public void SetVolume(float newVolume)
    {
        // Batasi nilai volume antara 0 dan 1
        volumeLevel = Mathf.Clamp01(newVolume);
    }
}
