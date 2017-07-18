using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            GameControl.instance.Bird1Scored();
            Destroy(gameObject);
        }
        else if(other.GetComponent<Bird2>() != null)
        {
            GameControl.instance.Bird2Scored();
            Destroy(gameObject);
        }
    }
}
