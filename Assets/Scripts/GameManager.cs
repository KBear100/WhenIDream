using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text collectablesTxt;

    public static int collectables = 0;

    void Start()
    {
        
    }

    void Update()
    {
        collectablesTxt.text = "Toys Collected: " + collectables;
    }
}
