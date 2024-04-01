using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3;

    Vector2 vel = Vector2.zero;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    bool faceRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        vel.x = Input.GetAxis("Horizontal") * speed;
        vel.y = Input.GetAxis("Vertical") * speed;

        if (vel.x < 0 && !faceRight) FlipSprite();
        if (vel.x > 0 && faceRight) FlipSprite();

        rb.velocity = vel;
    }

    private void FlipSprite()
    {
        faceRight = !faceRight;
        spriteRenderer.flipX = !faceRight;
    }
}
