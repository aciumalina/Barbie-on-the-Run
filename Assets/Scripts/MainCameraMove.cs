using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour
{
    GameObject player;
    Vector3 offset;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset+player.transform.position;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
