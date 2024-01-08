using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject archer;
    [SerializeField] GameObject heraklios;
    [SerializeField] GameObject parasite;
    [SerializeField] GameObject survivor;
    private void Awake()
    {
        GameObject runner = Instantiate(survivor);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
