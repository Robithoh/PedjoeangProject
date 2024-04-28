using Discord;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Hint_Panel : MonoBehaviour
{
    public GameObject Hint_Panel;
    public GameObject Panel_Anim;
    public GameObject Video_Loading;

    public void OpenHintPanel()
    {
        Video_Loading.SetActive(true);
        StartCoroutine(DelayDestroy(Video_Loading));
        if (Hint_Panel != null)
        {
            Hint_Panel.SetActive(true);
        }
        Panel_Anim.SetActive(false);
    }
    private IEnumerator DelayDestroy(GameObject gameObject)
    {
        yield return new WaitForSeconds(2.5f); // Menunda selama 2 detik
        gameObject.SetActive(false);
    }
}
