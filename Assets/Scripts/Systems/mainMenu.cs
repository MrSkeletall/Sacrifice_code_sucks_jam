using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }

    public void leaveGame()
    {
        Application.Quit();
    }
}