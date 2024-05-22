using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyCollectables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            BabyGameManager.collectables++;
            Destroy(this.gameObject);
        }
    }
}
