using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public GameObject Hint_Panel;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (sceneInfo.isGameRetried == true)
        {
            anim.SetBool("isRetry", true);
            // Hint_Panel.SetActive(true);
        }
    }

    public void TryAgain()
    {
        //sceneInfo.charPos = new Vector3(47.71f, 0.843f, -3.63f);
        //sceneInfo.isNextScene = false;
        //for (int i = 0; i < sceneInfo.listEnemy.Count; i++)
        //{
        //    sceneInfo.listEnemy[i] = false;
        //}

        //sceneInfo.OnEnable();
        //SceneManager.LoadScene("MainScene");

        sceneInfo.isGameRetried = true;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
    }

    public void ExitMainMenu()
    {
        sceneInfo.OnEnable();
        SceneManager.LoadScene("MainMenu");
    }
}
