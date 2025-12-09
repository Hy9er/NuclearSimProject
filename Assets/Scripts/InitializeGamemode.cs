using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGamemode : MonoBehaviour
{
    [SerializeField]
    GameObject gamemodeHolder;



    void Start()
    {
        gamemodeHolder = GameObject.Find("GamemodeHolder");
    }

    private void initializeGamemode()
    {

    }

    void Update()
    {
        
    }
}
