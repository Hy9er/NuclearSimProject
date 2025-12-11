using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class EndlessLogic : MonoBehaviour
{
    [SerializeField]
    public GameObject valve;

    [SerializeField]
    public GameObject reactor;

    [SerializeField]
    public GameObject turbine;

    public bool isPaused;

    private float timeSurvived;
    private float lastSec;

    private float malfuncProb;

    [SerializeField]
    GameObject endlessUI;

    [SerializeField]
    GameObject dangerUI;


    [SerializeField]
    TextMeshProUGUI timer;

    void Start()
    {
        timeSurvived = 0f;
        isPaused = false;
        malfuncProb = .05f;
        StartCoroutine(CallEvery15Seconds());
        endlessUI.SetActive(true);
    }

    void Update()
    {
        if (isPaused) 
        {
            endlessUI.SetActive(false);
            dangerUI.SetActive(false);
        }

        if (!isPaused)
        {
            endlessUI.SetActive(true);
            dangerUI.SetActive(true);
            timeUpdater();

        }
    }

    private void timeUpdater()
    {
        timeSurvived += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeSurvived / 60);
        int seconds = Mathf.FloorToInt(timeSurvived % 60);

        if (seconds != lastSec)
        {
            lastSec = seconds;
            rollMalfunc();
        }

        timer.text = $"{minutes:00}:{seconds:00}";
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

    IEnumerator CallEvery15Seconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f); 
            
            if (malfuncProb <= .20f)
            {
                malfuncProb += .01f;
            }
        }
    }

}
