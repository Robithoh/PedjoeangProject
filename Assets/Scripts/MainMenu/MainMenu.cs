using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public GameObject Loading_Screen;
    public Animator Loading;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            Loading.SetBool("isEnd", true);
            // MusicManager.Instance.ChangeMusic();
            StartCoroutine(DelayDestroy(Loading_Screen));
        }
    }
    public void Main_Menu()
    {
        //sceneInfo.OnEnable();
        SceneManager.LoadScene("MainMenu");
    }
    public void PedjoeangSelection()
    {
        SceneManager.LoadScene("PedjoeangSelection");
    }
    public void Pengaturan()
    {
        SceneManager.LoadScene("Pengaturan");
    }
    public void Tentang()
    {
        SceneManager.LoadScene("Tentang");
    }
    public void MainScene()
    {
        StartCoroutine(DelayedSceneLoad("MainScene"));
        
        Loading_Screen.SetActive(true);
        Loading.SetBool("isStart", true);
        // MusicManager.Instance.ChangeMusic();
    }
    public void Exit(){
        Application.Quit();
    }
    private IEnumerator DelayedSceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(2.5f); // Menunda selama 2 detik

        SceneManager.LoadScene(sceneName);
    }
    private IEnumerator DelayDestroy(GameObject gameObject)
    {
        yield return new WaitForSeconds(2.5f); // Menunda selama 2 detik
        gameObject.SetActive(false);
    }
}
