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

    [SerializeField]
    GameObject gamemodeHolder;


    private void Start()
    {
        gamemodeHolder = GameObject.Find("GamemodeHolder");
    }

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
        SceneManager.LoadScene("ReactorScene");
        gamemodeHolder.GetComponent<GamemodeHolder>().waves = true;
    }

    public void onEndlessClick()
    {
        SceneManager.LoadScene("ReactorScene");
        gamemodeHolder.GetComponent<GamemodeHolder>().endless = true;


    }

    public void onTutorialClick()
    {
        SceneManager.LoadScene("ReactorScene");
        gamemodeHolder.GetComponent<GamemodeHolder>().tutorial = true;

    }

    public void onGamemodeSelectBackClick()
    {
        gamemodeSelect.SetActive(false);
        titleScreen.SetActive(true);
    }

}
