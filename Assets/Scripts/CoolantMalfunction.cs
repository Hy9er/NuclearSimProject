using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoolantMalfunction : MonoBehaviour
{
    public GameObject interactPrompt;
    public Boolean pumpOn;
    public Boolean coolantMalfunction;
    public ParticleSystem coolantLeak;
    
    // Start is called before the first frame update
    void Start()
    {
        interactPrompt.SetActive(false);
        coolantLeak.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        { 
            coolantLeak.Play();
            pumpOn = true;
            coolantMalfunction = true;
        }

        if (coolantMalfunction)
        {
            if (interactPrompt.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                TextMeshProUGUI interactText = interactPrompt.GetComponent<TextMeshProUGUI>();
                if (pumpOn)
                {
                    interactText.text = "Press E to Turn On the Coolant";
                    pumpOn = false;
                   coolantLeak.Stop(coolantLeak);
                }
                else{
                    pumpOn = true;
                    interactText.text = "Press E to Turn Off the Coolant";
                    if (coolantMalfunction)
                    {
                        coolantLeak.Play();
                    }
                }
               
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        TextMeshProUGUI interaction = interactPrompt.GetComponent<TextMeshProUGUI>();
        if (coolantMalfunction && other.gameObject.CompareTag("Player"))
        {
             interactPrompt.SetActive(true);
            
            if (!pumpOn)
            {
                interaction.text = "Press E to Turn on the Coolant";
            }
            else
            {
                interaction.text = "Press E to Turn off the Coolant";
            }
               

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (coolantMalfunction && other.gameObject.CompareTag("Player"))
        {
            interactPrompt.SetActive(false);
        }
    }
}
