using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float jumpHeight = 3;
    [SerializeField, Range(1, 5)] float fallRateMultiplier;
    [SerializeField] Animator animator;
    [SerializeField] bool jump = false;
    [Header("Ground")]
    [SerializeField] Transform groundTransform;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] float groundRadius;

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
        bool onGround = false;
        if(jump) onGround = UpdateGroundCheck() && (vel.y <= 0);

        vel.x = Input.GetAxis("Horizontal") * speed;
        if (!jump) vel.y = Input.GetAxis("Vertical") * speed;
        else
        {
            if (onGround)
            {
                if (vel.y < 0) vel.y = 0;
                if (Input.GetButtonDown("Jump"))
                {
                    vel.y += Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
                }
            }
        }

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

        if(jump)
        {
            float gravityMultiplier = 1;
            if (!onGround && vel.y < 0) gravityMultiplier = fallRateMultiplier;
            Debug.Log(onGround);
            vel.y += Physics.gravity.y * Time.deltaTime;
        }

        rb.velocity = vel;
    }

    private bool UpdateGroundCheck()
    {
        // check if the character is on the ground
        Collider2D collider = Physics2D.OverlapCircle(groundTransform.position, groundRadius, groundLayerMask);
        if (collider != null)
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(groundTransform.position, Vector2.down, groundRadius, groundLayerMask);
            if (raycastHit.collider != null)
            {
                // get the angle of the ground (angle between up vector and ground normal)
                float groundAngle = Vector2.SignedAngle(Vector2.up, raycastHit.normal);
                Debug.DrawRay(raycastHit.point, raycastHit.normal, Color.red);
            }
        }

        return (collider != null);
    }

    private void FlipSprite()
    {
        faceRight = !faceRight;
        spriteRenderer.flipX = !faceRight;
    }
}
