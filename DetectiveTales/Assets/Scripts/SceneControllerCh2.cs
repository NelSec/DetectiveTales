using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerCh2 : MonoBehaviour
{
    private static SceneControllerCh2 _instance;

    public bool updateOn;

    public static SceneControllerCh2 instance
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
        if(//objetiveDone && 
            updateOn == true && Input.GetKeyDown("l"))
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

        if (sceneNumber >= scenes.Length)
        {
            updateOn = false;
        }

        if (objetiveDone)
            warningText.SetActive(true);
        else
            warningText.SetActive(false);
    }
}
