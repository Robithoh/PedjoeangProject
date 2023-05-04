using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private int currentSceneIndex;

    public string nextSceneName;
    public static bool loaaad;
    public GameObject Hide_Panel;

    // on trigger enter to change scene
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !SceneManager.GetSceneByName(nextSceneName).isLoaded)
        {
            // change scene
            // UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("BattleScene1");

            // Visible Cursor
            Cursor.visible = true;
            
            // unLock Cursor
            Cursor.lockState = CursorLockMode.None;

            if (loaaad) {
                loaaad = false;
                return;
            }
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
            loaaad = true;
            
            // Hide Panel
            if (Hide_Panel != null)
            {
                Hide_Panel.SetActive(false);
            }

            // Destroy GameObject
            Destroy(gameObject);
        }
        
    }
}
