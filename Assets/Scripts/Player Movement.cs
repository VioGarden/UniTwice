using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Script to move player
public class PlayerMovement : MonoBehaviour
{
    public PlayerStats stats;
    //public Stats stats;

    private Vector2 movement;

    private Rigidbody2D rb; // reference anya

    private Animator animator; // reference animator

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        if (PauseMenu.isPaused) return;
        movement = value.Get<Vector2>();

        // give info to animator to play correct movement animations
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);

            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

    }

    private void FixedUpdate()
    {
        if (PauseMenu.isPaused) return;
        // movement type 1
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        // movement type 2
        //if (movement.x != 0 || movement.y != 0)
        //{
        //    rb.velocity = movement * speed;
        //}

        // movement type 3
        rb.AddForce(movement * stats.speed);

    }
}
