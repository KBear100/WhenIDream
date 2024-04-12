using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject[] waypoints;
    [SerializeField] Animator animator;

    private bool runAway = false;
    private int waypointNum = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(runAway)
        {
            float vel = Time.deltaTime * speed;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointNum].transform.position, vel);
            animator.SetFloat("Speed", 1);
            if(transform.position == waypoints[waypointNum].transform.position )
            {
                runAway = false;
                animator.SetFloat("Speed", 0);
                waypointNum++;
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
}
