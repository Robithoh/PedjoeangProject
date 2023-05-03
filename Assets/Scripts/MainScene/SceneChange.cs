using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    // on trigger enter to change scene
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // change scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene_TurnBattleSystem");
        }
    }
}
