using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public float time;
    public TMP_Text timer;

    public bool active;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active && time > 0) 
        {
            time -= Time.deltaTime;
            ShowTime(time);
        }
        else if (time <= 0)
        {
            //gameover



        }

        void ShowTime(float time)
        {
            float minute = Mathf.FloorToInt(time / 60);
            float second = Mathf.FloorToInt(time % 60);

            timer.text = "Time Left: " + minute + ":" + second;


        }


    }
}
