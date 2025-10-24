using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public string NextSceneName;


    public void OnPlayButton()
    {
        if(NextSceneName != "Quit")
        {
            SceneManager.LoadScene(NextSceneName);
        }
        else
        {
            Application.Quit();    
        }
       

    }
}
