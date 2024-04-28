using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCheck : MonoBehaviour
{
    public GameObject[] off_attackButtons;
    public PlayerTB player;

    void Update()
    {
        if (player.energy < 50)
        {
            if (SceneManager.GetActiveScene().name == "TurnBased1_OWA")
            {
                off_attackButtons[1].SetActive(true);
            }
            else if (SceneManager.GetActiveScene().name == "TurnBased2_OWA")
            { 

            }
        }
        else if (player.energy < 25)
        {
            if (SceneManager.GetActiveScene().name == "TurnBased1_OWA")
            {
                off_attackButtons[3].SetActive(true);
            }
        }
        
    }
}

