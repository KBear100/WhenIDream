using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3;

    void Start()
    {
        
    }

    void Update()
    {
        float direction = Input.GetAxis("Vertical");
        float movement = direction * speed * Time.deltaTime;


    }
}
