using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void InstructionsButton()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
