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


    void Start()
    {
        gamemodeHolder = GameObject.Find("GamemodeHolder");

        tutorial = gamemodeHolder.GetComponent<GamemodeHolder>().tutorial;
        endless = gamemodeHolder.GetComponent<GamemodeHolder>().endless;
        waves = gamemodeHolder.GetComponent<GamemodeHolder>().waves;

        if (!tutorial)
        {
            learningStands.SetActive(false);
        }

        if (waves)
        {
            this.GetComponent<WavesLogic>().enabled = true;
        }
        if (endless)
        {
            this.GetComponent<EndlessLogic>().enabled = true;
        }

    }
    
    void Update()
    {
        

    }

}
