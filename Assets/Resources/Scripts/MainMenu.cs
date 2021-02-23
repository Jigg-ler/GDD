using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool isPaused = false;
    bool isMuted;

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
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

    public void PauseGame()
    {
        if (isPaused) {
            Time.timeScale = 1;
            isPaused = false;
        } else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
    }

    public void Muted()
    {
        isMuted =! isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }
}
