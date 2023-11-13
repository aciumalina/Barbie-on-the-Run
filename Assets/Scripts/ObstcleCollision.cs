using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcleCollision : MonoBehaviour
{
    PlayerMovement playerMovement;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            playerMovement.Die();
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
