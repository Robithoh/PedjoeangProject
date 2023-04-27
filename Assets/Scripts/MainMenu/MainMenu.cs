using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public void Main_Menu()
    {
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
        SceneManager.LoadScene("MainScene");
    }
    public void Exit(){
        Application.Quit();
    }
    // 
}
