using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Method that manages Level transitions depending on the scene name
    public void NextLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    // Method that quits application. Works only when game is build.
    public void QuitGame()
    {
        Application.Quit();
    }

}
