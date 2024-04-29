using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] Animator animator;
    [SerializeField] bool jump = false;

    Vector2 vel = Vector2.zero;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    bool faceRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        vel.x = Input.GetAxis("Horizontal") * speed;
        if(!jump) vel.y = Input.GetAxis("Vertical") * speed;

        if (vel.x > 0 && !faceRight) FlipSprite();
        if (vel.x < 0 && faceRight) FlipSprite();

        if (vel.x != 0 || vel.y != 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        rb.velocity = vel;
    }

    private void FlipSprite()
    {
        faceRight = !faceRight;
        spriteRenderer.flipX = !faceRight;
    }
}
