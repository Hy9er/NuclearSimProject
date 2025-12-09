using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitializeGamemode : MonoBehaviour
{
    [SerializeField]
    GameObject gamemodeHolder;

    public bool tutorial;

    public bool endless;

    public bool waves;

    [SerializeField]
    GameObject learningStands;

    [SerializeField]
    TextMeshProUGUI waveText;

    //Endless fields
    [SerializeField]
    TextMeshProUGUI temperatureText;

    [SerializeField]
    GameObject reactor;



    private float malfuncProb;


    //Waves fields



    void Start()
    {
        malfuncProb = 0f;

        gamemodeHolder = GameObject.Find("GamemodeHolder");

        tutorial = gamemodeHolder.GetComponent<GamemodeHolder>().tutorial;
        endless = gamemodeHolder.GetComponent<GamemodeHolder>().endless;
        waves = gamemodeHolder.GetComponent<GamemodeHolder>().waves;

        if (!tutorial)
        {
            learningStands.SetActive(false);
        }
    }
    
    void Update()
    {
        if (endless)
        {

        }

        if (waves)
        {

        }
    }

    private void initializeGamemode()
    {

    }
}
