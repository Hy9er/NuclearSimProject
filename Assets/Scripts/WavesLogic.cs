using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WavesLogic : MonoBehaviour
{
    [SerializeField]
    GameObject wavesUI;

    [SerializeField]
    GameObject dangerUI;

    [SerializeField]
    GameObject victoryUI;

    [SerializeField]
    TextMeshProUGUI timer;

    [SerializeField]
    TextMeshProUGUI waveNum;

    [SerializeField]
    public GameObject valve;

    [SerializeField]
    public GameObject reactor;

    [SerializeField]
    public GameObject turbine;

    private float malfuncProb;

    private float lastSec;

    public bool isPaused;

    private float timeLeft;

    private int roundNum;

    private Coroutine countdownCoroutine;



    void Start()
    {
        roundNum = 1;
        malfuncProb = .02f;
        wavesUI.SetActive(true);
        timeLeft = 15f;
    }

    void Update()
    {
        if (isPaused)
        {
            wavesUI.SetActive(false);
            dangerUI.SetActive(false);
        }

        if (!isPaused)
        {
            wavesUI.SetActive(true);
            dangerUI.SetActive(true);
        }

        if (countdownCoroutine == null) 
        {
            countdownCoroutine = StartCoroutine(CountdownCoroutine());
        }

    }

    
    private void UpdateUI(float time, int waveNum)
    {
        if (time != lastSec)
        {
            lastSec = time;
            rollMalfunc();
        }

        timer.text = $"Time Left: {time:00}";
        this.waveNum.text = $"Wave: {waveNum}";
    }

    IEnumerator CountdownCoroutine()
    {
        while (timeLeft > 1f)
        {
            timeLeft -= 1f;
            rollMalfunc();
            UpdateUI(timeLeft, roundNum);
            yield return new WaitForSeconds(1f);
        }

        countdownCoroutine = null;
        rollRoundOver();
    }

    private void rollMalfunc()
    {
        float roll = Random.value;

        if (roll < malfuncProb)
        {
            float roll2 = Random.value;

            if (roll2 < .33f && !valve.GetComponent<CoolantMalfunction>().coolantMalfunction)
            {
                valve.GetComponent<CoolantMalfunction>().startMalfunction();
            }
            else if (roll2 > .66f && reactor.GetComponent<ReactorMalfunction>().malfunctionFixed)
            {
                reactor.GetComponent<ReactorMalfunction>().startMalfunction();
            }
            else if (turbine.GetComponent<Repair>().isFanActive)
            {
                turbine.GetComponent<Repair>().malfunctionStart();
            }
        }

    }


    void rollRoundOver()
    {
        roundNum++;
        if (roundNum > 10)
        {
            this.GetComponent<GameOverScript>().initiateVictory();
            wavesUI.SetActive(false);
        }
        timeLeft = 15f;
        malfuncProb = .02f;
        UpdateUI(timeLeft, roundNum);
    }
 }