using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    public float speed;
    public float moveHorizontalDuration;
    public float acceleration;
    public float jumpForce;
    private bool isAlive;
    private bool isGrounded;
    private float maxSpeed;
    private int frameSpeed;
    public LayerMask groundMask;
    private bool isJumping;
    float currentTime;
    int horizontalMoveIndex;
    Vector3 moveHorizontal;
    float xFinalPosition;
    private Vector3 previousPosition;



    void Start()
    {
        initilizeComponents();
        initialiseVariables();

    }

    void initilizeComponents()
    {
        animator = GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
    }

    void initialiseVariables()
    {
        acceleration = 0.000000002f;
        speed = 3.0f;
        isAlive = true;
        maxSpeed = 4.0f;
        frameSpeed = 100;
        jumpForce = 300f;
        isJumping = false;
        isGrounded = false;
        currentTime = 0;
        horizontalMoveIndex = 0;
        moveHorizontal = new Vector3(2.5f, 0, 0);
        moveHorizontalDuration = 0.5f;
        isAlive = true;
        previousPosition = transform.position;

    }

    void Update()
    {
        frameSpeed += 1;
        if (!isAlive)
        {
            return;
        }
        MovePlayerZ();
        MovePlayerY();
        MovePlayerX();
        previousPosition = transform.position;
    }

    void MovePlayerY()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            Jump();
        }
        else if (isJumping == true)
        {
            float verticalMovement = transform.position.y - previousPosition.y;
            float height = GetComponent<Collider>().bounds.size.y;
            bool isGround = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
            if (isGround == true && verticalMovement<0)
            {
                Debug.Log(1);
                animator.SetBool("isGround", true);
                animator.SetBool("Jumping", false);
                isJumping = false;
                isGrounded = true;
            }
        }
        else if (isGrounded == true)
        {
            Debug.Log(2);
            animator.SetBool("isGround", false);
            animator.SetBool("isMoving", true);
            isGrounded = false;
        }
    }

    void MovePlayerZ()
    {
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        transform.position= transform.position + forwardMove;
        float runSpeed = speed / 2.0f;
        animator.SetFloat("RunSpeed", runSpeed);
        if (speed < maxSpeed && frameSpeed==10)
        {
            speed = speed + acceleration;
        }
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGround = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        if (isGround)
        {
            rb.AddForce(Vector3.up * jumpForce);
            animator.SetBool("Jumping", true);
        }
    }
    void MovePlayerX()
    {
        if (horizontalMoveIndex > 0)
        {
            if (horizontalMoveIndex == 1)
            {
                MoveLeftRight(moveHorizontal * (-1));

            }
            else
            {
                MoveLeftRight(moveHorizontal);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            horizontalMoveIndex = 1;
            xFinalPosition = transform.position.x + moveHorizontal.x * (-1);
            Debug.Log(xFinalPosition);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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
            transform.position = transform.position + moveHorizontal / (moveHorizontalDuration / Time.deltaTime);
            currentTime += Time.deltaTime;
            animator.SetBool("LeftRight", true);

        }
        if (moveHorizontalDuration < currentTime)
        {
            transform.position = new Vector3(xFinalPosition, transform.position.y, transform.position.z);
            currentTime = 0;
            horizontalMoveIndex = 0;
            animator.SetBool("LeftRight", false);
        }
    }

    public void Die()
    {
        isAlive = false;
        animator.SetBool("isAlive", false);
        animator.SetFloat("RunSpeed", 0);
        Invoke("Restart",2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
