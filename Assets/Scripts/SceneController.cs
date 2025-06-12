using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ARScene()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void Feedback()
    {
        SceneManager.LoadScene("Feedback");
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
