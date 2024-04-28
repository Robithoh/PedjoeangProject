using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public GameObject Hint_Panel;
    public Animator anim;
    public Animator panel_transition;
    public GameObject Transition;

    void Start()
    {
        panel_transition.SetBool("isEnd", true);
        //anim = GetComponent<Animator>();
        if (sceneInfo.isGameRetried == true)
        {
            anim.SetBool("isBlink", true);
            sceneInfo.isGameRetried = false;
        }
        StartCoroutine(DelayDestroy(Transition));
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

    private IEnumerator DelayDestroy(GameObject gameObject)
    {
        yield return new WaitForSeconds(2f); // Menunda selama 2 detik
        gameObject.SetActive(false);
    }
}
