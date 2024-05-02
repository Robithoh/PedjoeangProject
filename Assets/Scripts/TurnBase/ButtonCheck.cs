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
        if (player.energy < player.energyCost_Skill1)
        {
            off_attackButtons[0].SetActive(true);
        }
        if (player.energy < player.energyCost_Skill2)
        {
            off_attackButtons[1].SetActive(true);
        }
        if (player.energy < player.energyCost_Skill3)
        {
            off_attackButtons[2].SetActive(true);
        }
        if (player.energy < player.energyCost_Skill4)
        {
            off_attackButtons[3].SetActive(true);
        }
        if (player.energy < player.energyCost_Skill5)
        {
            off_attackButtons[4].SetActive(true);
        }
        if (player.energy < player.energyCost_Skill6)
        {
            off_attackButtons[5].SetActive(true);
        }
        
    }
}

