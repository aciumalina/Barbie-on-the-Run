using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCharactersList : MonoBehaviour
{
    public GameObject charactersList;
    public GameObject chooseCharcaterBtn;
    // Start is called before the first frame update
    void Start()
    {
        onClick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        charactersList.SetActive(false);
        chooseCharcaterBtn.SetActive(true);
    }
}


