using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float moveHorizontalDuration = 10.0f;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    float currentTime = 0;
    int horizontalMoveIndex = 0;
    Vector3 moveHorizontal = new Vector3(2.5f, 0, 0);
    float xFinalPosition;
    bool isAlive = true;

    Rigidbody rb;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive) { return; }
        MovePlayerZ();
        MovePlayerHorizontal();
        if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        if(transform.position.y <-5 || transform.position.y>5)
        {
            Die();
        }
    }

    void MovePlayerZ()
    {
        Vector3 forwardMove = transform.forward * speed *Time.deltaTime;
        transform.position=transform.position + forwardMove;
    }

    void MovePlayerHorizontal()
    {
        if(horizontalMoveIndex>0)
        {
            if(horizontalMoveIndex==1)
            {
                MoveLeftRight(moveHorizontal*(-1));

            }
            else
            {
                MoveLeftRight(moveHorizontal);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            horizontalMoveIndex = 1;
            xFinalPosition = transform.position.x + moveHorizontal.x*(-1);
            Debug.Log(xFinalPosition);
            
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            horizontalMoveIndex = 2;
            xFinalPosition = transform.position.x + moveHorizontal.x;
            Debug.Log(xFinalPosition);
        }
    }
    void MoveLeftRight(Vector3 moveHorizontal)
    {
        if (currentTime < moveHorizontalDuration)
        {
            transform.position = transform.position + moveHorizontal /(moveHorizontalDuration/Time.deltaTime);
            currentTime += Time.deltaTime;
        }
        if (moveHorizontalDuration < currentTime)
        {
            transform.position = new Vector3(xFinalPosition, transform.position.y, transform.position.z);
            currentTime = 0;
            horizontalMoveIndex = 0;
        }
    }

    public void Die()
    {
        isAlive = false;
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGround = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);

    }

}
