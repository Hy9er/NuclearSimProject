using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    GameObject resumeButton;

    [SerializeField]
    GameObject QuitButton;

    [SerializeField]
    GameObject QuitUnconfirm;

    [SerializeField]
    GameObject QuitConfirm;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject cam;

    [SerializeField]
    GameObject uiElements;

    public bool gameOver;

    void Start()
    {
        resume();
        pauseMenu.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            togglePause();
        }
    }

    private void togglePause()
    {
        if (isPaused)
        {
            resume();
        }
        else
        {
            pause();
        }
    }

    private void resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        player.GetComponent<PlyaerMovement>().enabled = true;
        cam.GetComponent<PlayerCam>().enabled = true;
        uiElements.SetActive(true);
        transform.GetComponent<EndlessLogic>().isPaused = false;
        transform.GetComponent<WavesLogic>().isPaused = false;
    }

    private void pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
        resumeButton.SetActive(true);
        QuitButton.SetActive(true);
        QuitUnconfirm.SetActive(false);
        QuitConfirm.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<PlyaerMovement>().enabled = false;
        cam.GetComponent<PlayerCam>().enabled = false;
        text.text = "Game Paused";
        uiElements.SetActive(false);
        transform.GetComponent<EndlessLogic>().isPaused = true;
        transform.GetComponent<WavesLogic>().isPaused = true;

    }

    public void onResumeClick()
    {
        resume();
    }

    public void onQuitClick()
    {
        text.text = "Are you sure?";
        resumeButton.SetActive(false);
        QuitButton.SetActive(false);
        QuitUnconfirm.SetActive(true);
        QuitConfirm.SetActive(true);
    }

    public void onUnconfirmClick()
    {
        text.text = "Game Paused";
        resumeButton.SetActive(true);
        QuitButton.SetActive(true);
        QuitUnconfirm.SetActive(false);
        QuitConfirm.SetActive(false);
    }

    public void onConfirmClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
