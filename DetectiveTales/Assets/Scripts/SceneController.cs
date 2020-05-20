using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;

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
    }

    void Update()
    {
        if(objetiveDone && Input.GetKeyDown("e"))
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

        if (objetiveDone)
            warningText.SetActive(true);
        else
            warningText.SetActive(false);
    }
}
