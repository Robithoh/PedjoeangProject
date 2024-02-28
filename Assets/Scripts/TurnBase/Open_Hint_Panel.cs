using Discord;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Hint_Panel : MonoBehaviour
{
    public GameObject Hint_Panel;

    public void OpenHintPanel()
    {
        if (Hint_Panel != null)
        {
            Hint_Panel.SetActive(true);
        }
    }
}
