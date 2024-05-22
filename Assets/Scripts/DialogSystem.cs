using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] TMP_Text dialogText;
    [SerializeField] GameObject dialogBackground;
    [SerializeField] float speed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public IEnumerator ShowDialog(string dialog)
    {
        dialogBackground.SetActive(true);
        foreach (char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(speed);
        }

        yield return new WaitForSeconds(1.5f);
        dialogText.text = "";
        dialogBackground.SetActive(false);
    }
}
