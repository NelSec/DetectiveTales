using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue()
    {
        if (DataManagement.datamanagement.levelTwo)
        {
            SceneManager.LoadScene("Chapter2");
            Debug.Log("clicked continue");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ExitGame");
    }

}
