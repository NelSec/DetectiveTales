using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private static bool gameStoped = false;
    [SerializeField]
    private GameObject pauseMenu;

    void Update()
    {
        if (PlayerCollision.instance.crashed)
        {
            Crashed();

            if (Input.GetKeyDown(KeyCode.T))
                TryAgain();
            else if (Input.GetKeyDown(KeyCode.L))
                Leave();
        }
    }

    private void Crashed()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameStoped = true;
    }

    private void TryAgain()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameStoped = false;
        PlayerCollision.instance.crashed = false;
    }

    private void Leave()
    {
        Time.timeScale = 1f;
        gameStoped = false;
        PlayerCollision.instance.crashed = false;
        SceneManager.LoadScene("Menu");
    }
}
