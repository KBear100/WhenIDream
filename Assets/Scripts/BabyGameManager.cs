using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BabyGameManager : MonoBehaviour
{
    [SerializeField] TMP_Text collectablesTxt;
    [SerializeField] DialogSystem dialogSystem;
    [SerializeField] float transitionTimer;

    public static int collectables = 0;
    private bool transition = false;

    void Update()
    {
        collectablesTxt.text = "Toys Collected: " + collectables;
        if(collectables == 5)
        {
            collectablesTxt.gameObject.SetActive(false);
            collectables = 0;
            StartCoroutine(dialogSystem.ShowDialog("Thank you for cleaning up honey!"));
            transition = true;
        }

        if(transition)
        {
            transitionTimer -= Time.deltaTime;
            if (transitionTimer < 0) SceneManager.LoadSceneAsync("ChildDream");
        }
    }
}
