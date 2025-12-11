using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject tutorialText;
    public GameObject turbineText;
    public GameObject primaryLoopText;
    public GameObject coolantText;
    public GameObject controlRodText;

    public GameObject LearningStands;

    void Start()
    {
        
    }

    private void Awake()
    {
        tutorialText.SetActive(false);
        turbineText.SetActive(false);
        primaryLoopText.SetActive(false);
        coolantText.SetActive(false);
        controlRodText.SetActive(false);
    }

    void Update()
    {
       
    }

    public void setTutorialText()
    {
        if (tutorialText.activeSelf)
        {
            tutorialText.SetActive(false);
        }
        else
        {
            tutorialText.SetActive(true);
        }
    }

    public void setTurbineText()
        {
            if (turbineText.activeSelf)
            {
                turbineText.SetActive(false);
            }
            else
            {
                turbineText.SetActive(true);
            }
        }

    public void setCoolantText()
        {
                if (coolantText.activeSelf)
                {
                    coolantText.SetActive(false);
                }
                else
                {
                    coolantText.SetActive(true);
                }
        }

    public void setPrimaryLoopText()
        {
            if (primaryLoopText.activeSelf)
            {
                primaryLoopText.SetActive(false);
            }
            else
            {
                primaryLoopText.SetActive(true);
            }
        }

    public void setControlRodText()
    {
        if (controlRodText.activeSelf)
        {
            controlRodText.SetActive(false);
        }
        else
        {
            controlRodText.SetActive(true);
        }
    }

}
