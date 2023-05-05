using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private int currentSceneIndex;

    public string nextSceneName;
    public string lastSceneName;

    public static bool loaaad;
    public GameObject Hide_Panel;
    public GameObject Hide_Panel1;
    public GameObject Hide_Panel2;
    public GameObject Hide_Panel3;

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
            
            hide_gameobject();

            // Destroy GameObject
            Destroy(gameObject);

        }  
    }

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

        // inVisible Cursor
        Cursor.visible = false;
        // Lock Cursor
        Cursor.lockState = CursorLockMode.Locked;

        show_gameobject();
    }

    public void hide_gameobject()
    {
        if (Hide_Panel != null)
        {
            Hide_Panel.SetActive(false);
            Hide_Panel1.SetActive(false);
            Hide_Panel2.SetActive(false);
            Hide_Panel3.SetActive(false);
        }
    }

    public void show_gameobject()
    {
        if (Hide_Panel == null)
        {
            Hide_Panel.SetActive(true);
            Hide_Panel1.SetActive(true);
            Hide_Panel2.SetActive(true);
            Hide_Panel3.SetActive(true);
        }
    }

    void Start()
    {
        if (Hide_Panel == null)
        {
            Hide_Panel.SetActive(true);
            Hide_Panel1.SetActive(true);
            Hide_Panel2.SetActive(true);
            Hide_Panel3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Hide_Panel.SetActive(true);
            Hide_Panel1.SetActive(true);
            Hide_Panel2.SetActive(true);
            Hide_Panel3.SetActive(true);
        } 
    }
}
