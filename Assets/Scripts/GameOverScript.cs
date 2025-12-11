using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    public GameObject valve;

    [SerializeField]
    public GameObject reactor;

    [SerializeField]
    public GameObject turbine;

    [SerializeField]
    public TextMeshProUGUI warningText;

    [SerializeField]
    public GameObject gameOverCanvas;

    [SerializeField]
    public GameObject endlessCanvas;

    [SerializeField]
    public GameObject wavesCanvas;

    [SerializeField]
    public GameObject uiCanvas;

    [SerializeField]
    public GameObject victoryCanvas;

    private float countdown;

    private Coroutine countdownCoroutine;

    void Start()
    {
        warningText.gameObject.SetActive(false);
        countdown = 60.0f;
    }

    void Update()
    {
        if (valve.GetComponent<CoolantMalfunction>().coolantMalfunction || !reactor.GetComponent<ReactorMalfunction>().malfunctionFixed || !turbine.GetComponent<Repair>().isFanActive)
        {
            if (countdownCoroutine == null)
            {
                countdownCoroutine = StartCoroutine(CountdownCoroutine());
            }
            return;
        }

        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
            warningText.gameObject.SetActive(false);
            countdown = 60f;
        }
    }

    IEnumerator CountdownCoroutine()
    {
        while (countdown > 1f)
        {
            countdown -= 1f; 
            UpdateUI(countdown);
            yield return new WaitForSeconds(1f);
        }

        countdownCoroutine = null;
        initiateGameOver();
    }

    void UpdateUI(float sec)
    {
        int seconds = Mathf.FloorToInt(sec % 60f);
        warningText.gameObject.SetActive(true);
        warningText.text = $"WARNING:\nMALFUNCTION DETECTED\nFIX WITHIN\n{seconds}s";
    }

    void initiateGameOver()
    {
        warningText.gameObject.SetActive(false);
        wavesCanvas.SetActive(false);
        endlessCanvas.SetActive(false);
        uiCanvas.SetActive(false);

        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        this.GetComponent<PauseManager>().gameOver = true;
    }

    public void initiateVictory()
    {
        warningText.gameObject.SetActive(false);
        wavesCanvas.SetActive(false);
        endlessCanvas.SetActive(false);
        uiCanvas.SetActive(false);

        victoryCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        this.GetComponent<PauseManager>().gameOver = true;
    }


    public void onRetryClick()
    {
        SceneManager.LoadScene("ReactorScene");
    }

    public void onQuickClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
