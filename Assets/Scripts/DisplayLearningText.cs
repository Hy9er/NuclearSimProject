using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayLearningText : MonoBehaviour
{
     [SerializeField]
     GameObject educationalText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!educationalText.gameObject.activeSelf && other.gameObject.CompareTag("Player")) {
            educationalText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(educationalText.gameObject.activeSelf && other.gameObject.CompareTag("Player"))
        {
            educationalText.SetActive(false);
        }
    }
}
