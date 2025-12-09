using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemodeHolder : MonoBehaviour
{
    private static GamemodeHolder instance;

    [SerializeField]
    public bool tutorial;

    [SerializeField]
    public bool endless;

    [SerializeField]
    public bool waves;


    void Start()
    {
        tutorial = false;
        waves = false;
        tutorial = false;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            tutorial = false;
            waves = false;
            tutorial = false;
        }
    }



    void Update()
    {
        
    }

}
