using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void Shop()
    {
        SceneManager.LoadScene(2);
    }

    public void Settings()
    {
        SceneManager.LoadScene(3);
    }
    
    public void Credits()
    {
        SceneManager.LoadScene(4);
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1f;
    }


    void Start()
    {

    }
}
