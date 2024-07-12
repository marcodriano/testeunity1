using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class moverjogador : MonoBehaviour
{
    public float movespeed = 5f;
    private Rigidbody2D rb;
    private float moveInput;
    private float position = 1;
    private Animator animator;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            isRunning = true;
        }
        else 
        { 
            isRunning = false;
        }

        animator.SetBool("isRunning", isRunning);

    }
    void FixedUpdate()
    {

        rb.velocity = new Vector2(moveInput * movespeed, rb.velocity.y);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            position = 1f;

        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            position = -1f;

        }
        else
        {
            transform.localScale = new Vector3(position, 1f, 1f);
        }
    }
}
