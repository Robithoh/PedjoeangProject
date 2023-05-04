using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScene : MonoBehaviour
{
    public string lastSceneName;

    public void ContinueMainScene()
    {
        // sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        // Debug.Log("Scene to continue: " + sceneToContinue);

        // if (sceneToContinue != 2)
        //     SceneManager.LoadSceneAsync(sceneToContinue);
        // else
        //     return;

        if (SceneManager.GetSceneByName(lastSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(lastSceneName);
        }
    }
}
