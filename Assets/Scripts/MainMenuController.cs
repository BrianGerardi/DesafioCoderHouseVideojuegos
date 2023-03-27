using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Juegoprincipal");
    }

    public void OpenSettings()
    {
    }

    public void OpenCredits()
    {
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}