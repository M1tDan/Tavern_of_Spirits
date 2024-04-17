using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadNextDay()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToWork()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
