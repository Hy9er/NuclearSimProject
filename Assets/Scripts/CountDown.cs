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

    public TMP_Text GameOver;
    public GameObject button;

    public PlayerCam playerCamera;
    public PlyaerMovement player;


    void Start()
    {
        
    }

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
            GameOver.gameObject.SetActive(true);
            button.SetActive(true);
            player.dead = true;
            playerCamera.dead = true;
            ShowTime(0);
        }

        void ShowTime(float time)
        {
            float minute = Mathf.FloorToInt(time / 60);
            float second = Mathf.FloorToInt(time % 60);

            timer.text = "Time Left: " + minute + ":" + second;
        }


    }
}
