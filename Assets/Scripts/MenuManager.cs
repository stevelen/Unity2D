using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void backToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void acchiMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
