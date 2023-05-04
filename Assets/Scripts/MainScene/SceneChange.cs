using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private int currentSceneIndex;

    // on trigger enter to change scene
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // saved Scene
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedScene", currentSceneIndex);

            // change scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene_TurnBattleSystem");

            // Visible Cursor
            Cursor.visible = true;
            
            // unLock Cursor
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
