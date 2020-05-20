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

    public bool objetiveDone;

    [SerializeField]
    private GameObject[] scenes;

    void Start()
    {
        _instance = this;
        objetiveDone = false;
    }

    void Update()
    {
        
    }
}
