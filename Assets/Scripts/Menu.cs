using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Menu : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject gamemodeSelect;



    public void OnPlayButton()
    {
        titleScreen.SetActive(false);
        gamemodeSelect.SetActive(true);
    }

    public void onCreditButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void onQuitButton()
    {
        Application.Quit();
    }

    public void creditsGoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onWavesClick()
    {

    }

    public void onEndlessClick()
    {

    }

    public void onTutorialClick()
    {

    }

    public void onGamemodeSelectBackClick()
    {
        gamemodeSelect.SetActive(false);
        titleScreen.SetActive(true);
    }

}
