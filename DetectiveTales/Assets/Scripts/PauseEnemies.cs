using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseEnemies : MonoBehaviour
{

    private static bool gameStoped = false;
    [SerializeField]
    private GameObject pauseMenu;

    void Update()
    {
        if (RayCast.instance.timeLeft <= 0.1f && !RayCast.instance.allKilled)
        {
            Died();

            if (Input.GetKeyDown(KeyCode.T))
                TryAgain();
            else if (Input.GetKeyDown(KeyCode.L))
                Leave();
        }
    }

    private void Died()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameStoped = true;
    }

    private void TryAgain()
    {
        RayCast.instance.timeLeft = 10f;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameStoped = false;
    }

    private void Leave()
    {
        Time.timeScale = 1f;
        gameStoped = false;
        SceneManager.LoadScene("Menu");
    }
}