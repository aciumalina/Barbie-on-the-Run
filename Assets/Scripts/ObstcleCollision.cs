using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcleCollision : MonoBehaviour
{
    PlayerMove playerMovement;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            playerMovement = collision.gameObject.GetComponent<PlayerMove>();
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
