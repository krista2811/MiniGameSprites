using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird2>() != null)
        {
            if (other.GetComponent<Bird2>().tag == "Player2")
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                other.GetComponent<Animator>().SetTrigger("die");
                GameControl.instance.Bird2Died();
            }
        }
        if (other.GetComponent<Bird>() != null)
        {
            for (int i = 0; i < 10; i++)
            {
                GameControl.instance.Bird1Scored();
            }

        }
    }
}