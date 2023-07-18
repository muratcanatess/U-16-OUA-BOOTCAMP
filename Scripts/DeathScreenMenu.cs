using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenMenu : MonoBehaviour
{
    public void DeathMenuButton(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
