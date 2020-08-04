using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;

    public bool updateOn;

    public static SceneController instance
    {
        get { return _instance; }
    }

    public int sceneNumber;
    public bool objetiveDone;

    [SerializeField]
    private GameObject[] scenes;
    [SerializeField]
    private GameObject warningText;

    void Awake()
    {
        _instance = this;
        objetiveDone = true;
        sceneNumber = 0;
        updateOn = true;
    }

    void Update()
    {
        if(objetiveDone && 
            updateOn == true /*&& Input.GetKeyDown("space")*/)
        {
            objetiveDone = false;
            if (sceneNumber == 0)
                scenes[sceneNumber].SetActive(true);
            else
            {
                scenes[sceneNumber].SetActive(true);
                scenes[sceneNumber - 1].SetActive(false);
            }
            sceneNumber++;
        }

        if (sceneNumber >= scenes.Length && Input.GetKeyDown("e"))
        {
            updateOn = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        /*if (objetiveDone)
            warningText.SetActive(true);
        else
            warningText.SetActive(false);*/
    }
}
