using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject archer;
    [SerializeField] GameObject heraklios;
    [SerializeField] GameObject parasite;
    [SerializeField] GameObject survivor;
    // Start is called before the first frame updat
    void Start()
    {
        GameObject prefabObject = Instantiate(zombie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
