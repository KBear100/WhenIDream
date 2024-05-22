using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] public GameObject[] waypoints;
    [SerializeField] Animator animator;

    [HideInInspector] public int waypointNum = 0;
    private bool runAway = false;
    private bool faceRight = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(runAway)
        {
            if (waypointNum != waypoints.Length)
            {
                float vel = Time.deltaTime * speed;
                transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointNum].transform.position, vel);
                animator.SetFloat("Speed", 1);
                if(transform.position.x - waypoints[waypointNum].transform.position.x > 0 && faceRight) FlipSprite();
                if(transform.position.x - waypoints[waypointNum].transform.position.x < 0 && !faceRight) FlipSprite();
                if(transform.position == waypoints[waypointNum].transform.position )
                {
                    runAway = false;
                    animator.SetFloat("Speed", 0);
                    waypointNum++;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            runAway = true;
        }
    }

    private void FlipSprite()
    {
        faceRight = !faceRight;
        spriteRenderer.flipX = !faceRight;
    }
}
