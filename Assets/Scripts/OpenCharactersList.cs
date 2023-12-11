using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCharactersList : MonoBehaviour
{
    public GameObject charactersList;
    public GameObject chooseCharcaterBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        charactersList.SetActive(true);
        chooseCharcaterBtn.SetActive(false);
    }

}
