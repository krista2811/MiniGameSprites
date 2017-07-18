using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPen : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            GameController.instance.hits1 += 5;
            Destroy(gameObject);
        }
        else if(collision.GetComponent<Player2>())
        {
            GameController.instance.hits2 += 5;
            Destroy(gameObject);
        }
    }
}
