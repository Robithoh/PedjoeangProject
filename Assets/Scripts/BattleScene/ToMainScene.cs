using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScene : MonoBehaviour
{
    private int sceneToContinue;

    public void ContinueMainScene()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if (sceneToContinue != 0)
            SceneManager.LoadScene(sceneToContinue);
        else
            return;
    }
}
