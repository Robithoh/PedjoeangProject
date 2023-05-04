using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private int currentSceneIndex;

    // on trigger enter to change scene
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // change scene
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("BattleScene1");

            // Visible Cursor
            Cursor.visible = true;
            
            // unLock Cursor
            Cursor.lockState = CursorLockMode.None;

            // saved Scene
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedScene", currentSceneIndex);

            Debug.Log("Scene Saved: " + currentSceneIndex);

            // Destroy GameObject
            Destroy(gameObject);
        }
        
    }
}
