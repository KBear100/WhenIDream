using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChildGameManager : MonoBehaviour
{
    [SerializeField] RunAway adam;
    [SerializeField] DialogSystem dialogSystem;
    [SerializeField] float transitionTimer;

    private bool transition = false;

    void Start()
    {
        StartCoroutine(dialogSystem.ShowDialog("You can't catch me!"));
    }

    void Update()
    {
        if (adam.waypointNum == adam.waypoints.Length && !transition)
        {
            StartCoroutine(dialogSystem.ShowDialog("We'll be best friends forever right?"));
            transition = true;
        }

        if (transition)
        {
            transitionTimer -= Time.deltaTime;
            if (transitionTimer < 0) SceneManager.LoadSceneAsync("TeenDream");
        }
    }
}
