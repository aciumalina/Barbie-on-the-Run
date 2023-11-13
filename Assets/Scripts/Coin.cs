using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            Destroy(gameObject);
            return; 
        }
        if(collision.gameObject.tag != "Player")
        {
            return;
        }
        GameManager.instance.IncreaseScore();
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed*Time.deltaTime);
    }
}
